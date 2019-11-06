using cnam_mania.Settings;
using cnam_mania.VisualNovelGame.Model.Episodes;
using cnam_mania.VisualNovelGame.Service.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Manager.Episode
{
    public class EpisodeManager
    {
        #region Variables
        private static EpisodeManager _instance;

        /// <summary>
        /// Current Episode id.
        /// </summary>
        private int CurrentEpisode { get; set; }

        /// <summary>
        /// Next episode id.
        /// </summary>
        private int NextEpisode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Serie Serie { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        public EpisodeManager()
        {
            this.Serie = XmlDataAccess.XMLDeserializeObject<Serie>(Config.filePath_XmlStory);
        }

        /// <summary>
        /// Return episode manager instance
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

        public void SwitchEpisode()
        {

        }

        #endregion
    }
}
