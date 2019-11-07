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
        public EpisodeManager episodeManager;

        /// <summary>
        /// CharacterManager instance
        /// </summary>
        public CharacterManager characterManager;

        /// <summary>
        /// Game mode choosen by the user
        /// </summary>
        public IModeStrategy GameMode { get; set; }

        /// <summary>
        /// Creation of the VisualNovelManager
        /// </summary>
        private VisualNovelManager()
        {
            this.episodeManager = EpisodeManager.Instance;
            this.characterManager = CharacterManager.Instance;
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
        public void InitGame(String character, String gameMode)
        {

        }

        public void SaveGame()
        {
            // retrieves current game state 
            SavingPoint savingPoint = new SavingPoint(this.characterManager.CharacterBuilder.GetCharacter(), this.episodeManager.CurrentEpisode);
            // Originator will creates and stores states in Memento
            Originator originator = new Originator();
            // Originator instanciates saving point 
            originator.SetSavingPoint(savingPoint);
            // add generated memento in history 
            this.history.Add(originator.Save());
           
        }
        /// <summary>
        /// Retrieves last game state saved.
        /// </summary>
        /// <param name="lastEpisode"></param>
        /// <returns></returns>
        public SavingPointMemento getSavingPointMemento(int lastEpisode)
        {
            return this.history.ElementAt(lastEpisode);
        }

        /// <summary>
        /// Resets items state at a given time.
        /// </summary>
        public void backToSavingPoint()
        {
            // retrieve savingPoint
            SavingPointMemento savingPointMemento = getSavingPointMemento(this.history.Count-1);

            // if there is a saving point
            if (savingPointMemento != null)
            { 
                // reset character's data 
                this.characterManager.CharacterBuilder.Character.Food = savingPointMemento.GetSavingPoint().CharacterState.Food;
                this.characterManager.CharacterBuilder.Character.Intellect = savingPointMemento.GetSavingPoint().CharacterState.Intellect;
                this.characterManager.CharacterBuilder.Character.Money = savingPointMemento.GetSavingPoint().CharacterState.Money;
                this.characterManager.CharacterBuilder.Character.Popularity = savingPointMemento.GetSavingPoint().CharacterState.Popularity;
                // back to last episode saved
                this.episodeManager.CurrentEpisode = savingPointMemento.GetSavingPoint().EpisodeState;
            } 
        }

        /// <summary>
        /// Creates a character based on user's choice.
        /// </summary>
        /// <param name="character">Character type</param>
        public void CreateCharacter(String character)
        {
            // chooses the Character
            switch (character)
            {
                case "SMART":
                    this.characterManager.SetCharacterBuilder(new SmartCharacterBuilder());
                    break;
                case "GREEDY":
                    this.characterManager.SetCharacterBuilder(new GreedyCharacterBuilder());
                    break;
                case "POPULAR":
                    this.characterManager.SetCharacterBuilder(new PopularCharacterBuilder());
                    break;
                case "RICH":
                    this.characterManager.SetCharacterBuilder(new RichCharacterBuilder());
                    break;
                default:
                    break;

            }
        }

        /// <summary>
        /// Sets the Game Mode based on user's choice.
        /// </summary>
        /// <param name="gameMode"></param>
        public void SetGameMode(String gameMode)
        {
            // chooses the game mode
            switch (gameMode)
            {
                case "EASY":
                    this.GameMode = new EasyMode();
                    break;
                case "MEDIUM":
                    this.GameMode = new MediumMode();
                    break;
                case "HARD":
                    this.GameMode = new HardMode();
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
        /// <param name="choice"></param>
        public void SwitchEpisode(Choice choice)
        {
            if (choice != null)
                this.episodeManager.nextStory(choice); 

            //TODO : add exceptions
        }

    }
}
