using cnam_mania.Game;
using cnam_mania.VisualNovelGame.Model.Levels;
using cnam_mania.VisualNovelGame.Model.Characters; 
using cnam_mania.VisualNovelGame.Manager.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cnam_mania.VisualNovelGame.Model.Episodes;
using cnam_mania.VisualNovelGame.Model.Memento;
using cnam_mania.VisualNovelGame.Enumeration;

namespace cnam_mania.VisualNovelGame.Manager
{
    public class VisualNovelManager : AbsGameManager
    {
        #region Variables
        /// <summary>
        /// VisualNovelManager instance
        /// </summary>
        private static VisualNovelManager _instance = null;

        /// <summary>
        /// Game history 
        /// </summary>
        public List<SavingPointMemento> history;
        
        /// <summary>
        /// EpisodeManager instance
        /// </summary>
        public EpisodeManager EpisodeManager;

        /// <summary>
        /// CharacterManager instance
        /// </summary>
        public CharacterManager CharacterManager;

        /// <summary>
        /// SavingPoint instance
        /// </summary>
        public SavingPointOriginator SavingPointOriginator;

        /// <summary>
        /// Game mode choosen by the user
        /// </summary>
        public IModeStrategy GameModeStrategy { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Creation of the VisualNovelManager
        /// </summary>
        private VisualNovelManager()
        {
            this.EpisodeManager = EpisodeManager.Instance;
            this.CharacterManager = CharacterManager.Instance;
            SavingPointOriginator = new SavingPointOriginator();
            this.history = new List<SavingPointMemento>();
        }

        /// <summary>
        /// Reset instance
        /// </summary>
        public static void Reset()
        {
            _instance = null;
        }

        /// <summary>
        /// Return visual novel manager instance
        /// </summary>
        public static VisualNovelManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VisualNovelManager();
                }
                return _instance;
            }
        }
        #endregion

        public override void Play()
        {

        }

        /// <summary>
        /// Initialize the game items. 
        /// </summary>
        public void InitGame(PlayerType character, GameMode gameMode)
        {
            CreateCharacter(character);
            SetGameMode(gameMode);
        }

        /// <summary>
        /// Create new saving point
        /// </summary>
        /// <param name="character">character state</param>
        /// <param name="episode">epsiode state</param>
        public void CreateSavingPoint(Character character, Episode episode)
        {
            // Originator instanciates saving point 
            SavingPointOriginator.SetCharacterState(character);
            SavingPointOriginator.SetEpisodeState(episode);

            // add generated memento in history 
            this.history.Add((SavingPointMemento)SavingPointOriginator.Save());
           
        }
        
        /// <summary>
        /// Retrieves last game state saved.
        /// </summary>
        /// <param name="lastEpisode"></param>
        /// <returns></returns>
        public void RestorSavingPoint(int index)
        {
            SavingPointMemento memento = (SavingPointMemento)this.history.ElementAt(index);
            memento.Restore();

            // not good !!!
            this.EpisodeManager.CurrentEpisode = SavingPointOriginator.GetEpisodeState();
            this.CharacterManager.CharacterBuilder.GetCharacter().Food = SavingPointOriginator.GetCharacterState().Food;
            this.CharacterManager.CharacterBuilder.GetCharacter().Popularity = SavingPointOriginator.GetCharacterState().Popularity;
            this.CharacterManager.CharacterBuilder.GetCharacter().Money = SavingPointOriginator.GetCharacterState().Money;
            this.CharacterManager.CharacterBuilder.GetCharacter().Intellect = SavingPointOriginator.GetCharacterState().Intellect;
        }

        /// <summary>
        /// Creates a character based on user's choice.
        /// </summary>
        /// <param name="character">Character type</param>
        public void CreateCharacter(PlayerType character)
        {
            // chooses the Character
            switch (character)
            {
                case PlayerType.SMART:
                    this.CharacterManager.SetCharacterBuilder(new SmartCharacterBuilder());
                    this.CharacterManager.CreateCharacter();
                    break;
                case PlayerType.GREEDY:
                    this.CharacterManager.SetCharacterBuilder(new GreedyCharacterBuilder());
                    this.CharacterManager.CreateCharacter();
                    break;
                case PlayerType.POPULAR:
                    this.CharacterManager.SetCharacterBuilder(new PopularCharacterBuilder());
                    this.CharacterManager.CreateCharacter();
                    break;
                case PlayerType.RICH:
                    this.CharacterManager.SetCharacterBuilder(new RichCharacterBuilder());
                    this.CharacterManager.CreateCharacter();
                    break;
                default:
                    break;

            }
        }

        /// <summary>
        /// Sets the Game Mode based on user's choice.
        /// </summary>
        /// <param name="gameMode"></param>
        public void SetGameMode(GameMode gameMode)
        {
            // chooses the game mode
            switch (gameMode)
            {
                case GameMode.EASY:
                    this.GameModeStrategy = new EasyMode();
                    break;
                case GameMode.MEDIUM:
                    this.GameModeStrategy = new MediumMode();
                    break;
                case GameMode.HARD:
                    this.GameModeStrategy = new HardMode();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checks if Game is finished
        /// </summary>
        public void EndGame()
        {
            // TODO 
        }

        /// <summary>
        /// After user's choice, chains the stories. 
        /// </summary>
        /// <param name="choice">selected choice</param>
        public bool SwitchStory(Choice choice)
        {
            Episode episode = this.EpisodeManager.CurrentEpisode;

            if (choice != null)
            {
                this.GameModeStrategy.ExecuteChoice(this.CharacterManager.CharacterBuilder.GetCharacter(), choice);

                this.EpisodeManager.NextStory(choice);

                if ( (episode == null) || (episode.EpisodeId != this.EpisodeManager.CurrentEpisode.EpisodeId) )
                    CreateSavingPoint(this.CharacterManager.CharacterBuilder.GetCharacter(), this.EpisodeManager.CurrentEpisode);
                
                return true; 
            }
            return false;
        }

    }
}
