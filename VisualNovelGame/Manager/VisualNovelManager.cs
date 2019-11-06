using cnam_mania.Game;
using cnam_mania.VisualNovelGame.Manager.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Creation of the VisualNovelManager
        /// </summary>
        private VisualNovelManager()
        {
            this.episodeManager = EpisodeManager.Instance;
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
    }
}
