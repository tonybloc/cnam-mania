using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Episodes
{
    public class EpisodeManager
    {
        /// <summary>
        /// Current Episode id.
        /// </summary>
        private int CurrentEpisode { get; set; }

        /// <summary>
        /// Next episode id.
        /// </summary>
        private int NextEpisode { get; set; }

        /// <summary>
        /// List of available episodes. 
        /// </summary>
        private List<Episode> Episodes { get; } = new List<Episode>();

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="currentEpisode"></param>
        /// <param name="nextEpisode"></param>
        /// <param name="episodes"></param>
        public EpisodeManager(int currentEpisode, int nextEpisode, List<Episode> episodes)
        {
            CurrentEpisode = currentEpisode;
            NextEpisode = nextEpisode;
            Episodes = episodes;
        }

        public void SwitchEpisode()
        {

        }
    }
}
