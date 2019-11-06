using cnam_mania.Game;
using cnam_mania.VisualNovelGame.Manager.Episode;
using cnam_mania.VisualNovelGame.Model.Levels;
using cnam_mania.VisualNovelGame.Model.Characters; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cnam_mania.VisualNovelGame.Model.Episodes;

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
             // chooses the Character according to user's choice
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
           
            // chooses the game mode according to user's choice
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

        public void SaveGame()
        {

        }

        public void CreateCharacter()
        {
            // TODO 

        }

        public void CheckVictory()
        {
            // TODO 
        }

        public void SwitchEpisode()
        {
            // TODO 
        }

    }
}
