using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Episodes
{
    public class Episode
    {
        /// <summary>
        /// Identifie the episode.
        /// </summary>
        private int EpisodeId { get; set; }

        /// <summary>
        /// Current story of the episode.
        /// </summary>
        private Story CurrentStory { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="episodeId"></param>
        /// <param name="currentStory"></param>
        public Episode(int episodeId, Story currentStory)
        {
            EpisodeId = episodeId;
            CurrentStory = currentStory;
        }


    }
}
