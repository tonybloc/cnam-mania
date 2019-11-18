using cnam_mania.Settings;
using cnam_mania.VisualNovelGame.Exceptions;
using cnam_mania.VisualNovelGame.Model.Episodes;
using cnam_mania.Service.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using cnam_mania.VisualNovelGame.Model.Characters;

namespace cnam_mania.VisualNovelGame.Manager.Episodes
{
    public class EpisodeManager
    {
        // Unique instance of manager
        private static EpisodeManager _instance;


        #region Variables

        #region Bindable Attributes
        public Episode CurrentEpisode
        {
            get { return _currentEpisode; }
            private set
            {
                if (_currentEpisode != value)
                {
                    _currentEpisode = value;                    
                }
            }
        }
        public Story CurrentStory
        {
            get { return _currentStory; }
            private set
            {
                if (_currentStory != value)
                {
                    _currentStory = value;
                }
            }
        }
        private Serie Serie
        {
            get { return _serie; }
            set
            {
                if (_serie != value)
                {
                    _serie = value;
                }
            }
        }
        #endregion 


        #region Variable (private)
        private Serie _serie { get; set; }
        private Episode _currentEpisode { get; set; }
        private Story _currentStory { get; set; }
        #endregion

        #endregion

        #region Constructor / Instance

        /// <summary>
        /// Create new instance of EpisodeManager
        /// </summary>
        private EpisodeManager()
        {
            try
            {
                this.Serie = XmlDataAccess.XMLDeserializeObject<Serie>(Config.filePath_XmlStory);
                this.CurrentEpisode = this.Serie.Episodes[0];
                this.CurrentStory = this.CurrentEpisode.Stories[0];
            }
            catch (Exception exp)
            {
                Console.WriteLine(string.Format("Une erreur est survenu lors de la déserialisation ! {0}", exp.Message));
                this.CurrentEpisode = null;
                this.CurrentStory = null;
            }

        }

        /// <summary>
        /// Get unique instance of manager
        /// </summary>
        public static EpisodeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EpisodeManager();
                }
                return _instance;
            }
        }

        #endregion

        #region Episodes behavior
        /// <summary>
        /// Set current epsiode
        /// </summary>
        /// <param name="episode">episode</param>
        public void SetCurrentEpsiode(Episode episode)
        {
            this.CurrentEpisode = episode;
            this.CurrentStory = GetStory(this.CurrentEpisode.EpisodeId, 0);
        }
        
        /// <summary>
        /// Get next story
        /// </summary>
        public bool NextStory(Choice choice, Character character)
        {
            if ((this.CurrentEpisode != null) && (this.CurrentStory != null))
            {
                // Define if we can skip stories in episode

                if (FindEndEpisodeAccordingCharacterAttributes(character))
                    return false;

                if (!choice.NextStoryCurrentEpisode)
                {
                    // Find next story in next episode                    
                    this.CurrentEpisode = GetEpisode(choice.NextEpisodeId);
                    this.CurrentStory = GetStory(choice.NextEpisodeId, 0);
                    return true; ;
                }


                // If exist next story in episode - switch. Else next epsiode
                if (HasNextStoryInEpsiode(this.CurrentEpisode, this.CurrentStory))
                {
                    this.CurrentStory = this.CurrentEpisode.Stories[GetStoryIndex(this.CurrentEpisode, this.CurrentStory) + 1];
                    return true;
                }
                else
                {
                    this.CurrentEpisode = this.GetEpisode(choice.NextEpisodeId);
                    this.CurrentStory = GetStory(choice.NextEpisodeId, 0);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find last episode of story board according character attributes
        /// </summary>
        /// <param name="character">character</param>
        /// <returns></returns>
        private bool FindEndEpisodeAccordingCharacterAttributes(Character character)
        {
            if(character.Intellect <= 0)
            {
                this.CurrentEpisode = this.Serie.Episodes.Single((e) => e.Stories[0].Choices[0].SmartPoints == -100);
                this.CurrentStory = this.CurrentEpisode.Stories[0];
                return true;
            }
            else if (character.Popularity <= 0)
            {
                this.CurrentEpisode = this.Serie.Episodes.Single((e) => e.Stories[0].Choices[0].PopularityPoints == -100);
                this.CurrentStory = this.CurrentEpisode.Stories[0];
                return true;
            }
            else if (character.Food <= 0)
            {
                this.CurrentEpisode = this.Serie.Episodes.Single((e) => e.Stories[0].Choices[0].FoodPoints == -100);
                this.CurrentStory = this.CurrentEpisode.Stories[0];
                return true;
            }
            else if (character.Money <= 0)
            {
                this.CurrentEpisode = this.Serie.Episodes.Single((e) => e.Stories[0].Choices[0].WealthyPoints == -100);
                this.CurrentStory = this.CurrentEpisode.Stories[0];
                return true;
            }

            return false;
        }

        /// <summary>
        /// Define if episode exist
        /// </summary>
        /// <param name="episodeId">Episode id</param>
        /// <returns></returns>
        private bool EpisodeExist(int episodeId)
        {
            return this.Serie.Episodes.Exists((item) => item.EpisodeId == episodeId);
        }

        /// <summary>
        /// Define if story exist
        /// </summary>
        /// <param name="storyId">Story id</param>
        /// <returns></returns>
        private bool StoryExist(int episodeId, int storyId)
        {
            Episode episode = GetEpisode(episodeId);
            if (episode != null)
                return episode.Stories.Exists((item) => item.Id == storyId);

            return false;
        }

        /// <summary>
        /// Find index of epsiode in list
        /// </summary>
        /// <param name="episodeId">episode id</param>
        /// <param name="episodes">list of episode</param>
        /// <returns>index of epsiode</returns>
        private int GetEpsiodeIndex(Episode episode, List<Episode> episodes)
        {
            return episodes.IndexOf(episode);
        }

        /// <summary>
        /// Find index of story in epsiode
        /// </summary>
        /// <param name="episodeId">episode id</param>
        /// <param name="storyId">story id</param>
        /// <returns>Inde of story</returns>
        private int GetStoryIndex(Episode episode, Story story)
        {
            return episode.Stories.IndexOf(story);
        }


        /// <summary>
        /// Check if it exist next story in epsiode
        /// </summary>
        /// <param name="episodeId"></param>
        /// <param name="storyId"></param>
        /// <returns></returns>
        private bool HasNextStoryInEpsiode(Episode episode, Story story)
        {
            return (GetStoryIndex(episode, story) < episode.Stories.Count() - 1);

        }

        /// <summary>
        /// Find episode with specifique id
        /// </summary>
        /// <param name="episodeId">episode id</param>
        /// <returns></returns>
        private Episode GetEpisode(int episodeId)
        {
            if (EpisodeExist(episodeId))
            {
                return this.Serie.Episodes.Single((item) => item.EpisodeId == episodeId);
            }
            return null;
        }

        /// <summary>
        /// Find history with specifique id
        /// </summary>
        /// <param name="episodeId">episode id</param>
        /// <returns></returns>
        private Story GetStory(int episodeId, int storyId)
        {
            if (StoryExist(episodeId, storyId))
            {
                return GetEpisode(episodeId).Stories.Single((item) => item.Id == storyId);
            }
            return null;
        }
        #endregion

        /// <summary>
        /// Clear manager data
        /// </summary>
        public static void Clear()
        {
            _instance = null;
        }
    }
}
