using cnam_mania.Settings;
using cnam_mania.VisualNovelGame.Exceptions;
using cnam_mania.VisualNovelGame.Model.Episodes;
using cnam_mania.VisualNovelGame.Service.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Manager.Episodes
{
    public class EpisodeManager
    {

        // Unique instance of manager
        private static EpisodeManager _instance;

        #region Variables
        #region Variables (public)
        public Episode CurrentEpisode { get; set; }
        public Story CurrentStory { get; private set; }
        #endregion 

        #region Variable (private)
        private Serie Serie { get; set; }
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

        /// <summary>
        /// Get next story
        /// </summary>
        public void NextStory(Choice choice)
        {            
            if( (this.CurrentEpisode != null) && (this.CurrentStory != null) )
            {
                // Get index of currentEpisode.
                int IndexCurrentEpisode =  this.Serie.Episodes.FindIndex((item) => item.EpisodeId == CurrentEpisode.EpisodeId);

                // Get index of currentStory.
                int IndexCurrentStory = this.CurrentEpisode.Stories.FindIndex((item) => item.Id == CurrentStory.Id);

                // Define if we can skip storys in episode
                if (this.CurrentStory.IsCrucial)
                {
                    if(!choice.NextStoryCurrentEpisode)
                    {
                        // Find next story in next episode                    
                        this.CurrentEpisode = GetEpisode(choice.NextEpisodeId);
                        this.CurrentStory = GetStory(choice.NextEpisodeId, 0);
                        return;
                    }
                }
                
                // If exist next story in episode - switch. Else next epsiode
                if (HasNextStoryInEpsiode(this.CurrentEpisode.EpisodeId, this.CurrentStory.Id) )
                {
                    this.CurrentStory = this.CurrentEpisode.Stories[GetEpsiodeIndex(this.CurrentEpisode.EpisodeId, this.Serie.Episodes)+1];
                    return;
                }
                else
                {
                    this.CurrentEpisode = this.GetEpisode(choice.NextEpisodeId);
                    this.CurrentStory = GetStory(choice.NextEpisodeId, 0);
                    return;
                }                
            }
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
        private int GetEpsiodeIndex(int episodeId, List<Episode> episodes)
        {
            return episodes.FindIndex((item) => item.EpisodeId == episodeId);
        }

        /// <summary>
        /// Find index of story in epsiode
        /// </summary>
        /// <param name="episodeId">episode id</param>
        /// <param name="storyId">story id</param>
        /// <returns>Inde of story</returns>
        private int GetStoryIndex(int episodeId, int storyId)
        {
            return GetEpisode(episodeId).Stories.FindIndex((item) => item.Id == storyId);
        }

        /// <summary>
        /// Check if it exist next story in epsiode
        /// </summary>
        /// <param name="episodeId"></param>
        /// <param name="storyId"></param>
        /// <returns></returns>
        private bool HasNextStoryInEpsiode(int episodeId, int storyId)
        {
            return ( GetStoryIndex(episodeId, storyId) < GetEpisode(episodeId).Stories.Count() -1);

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

    }
}
