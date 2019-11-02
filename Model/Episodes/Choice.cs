using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Episodes
{
    class Choice
    {
        /// <summary>
        /// Smartness points. 
        /// </summary>
        private int SmartPoints { get; set; }

        /// <summary>
        /// Popularity points. 
        /// </summary>
        private int PopularityPoints { get; set; }

        /// <summary>
        /// Money points. 
        /// </summary>
        private int WealthyPoints { get; set; }

        /// <summary>
        /// Food points. 
        /// </summary>
        private int FoodPoints { get; set; }

        /// <summary>
        /// Defines if the episode will be continued or not.
        /// </summary>
        private bool NextStoryCurrentEpisode { get; set;  }

        /// <summary>
        /// Id of the next episode. 
        /// </summary>
        private int NextEpisodeId { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="smartPoints"></param>
        /// <param name="popularityPoints"></param>
        /// <param name="wealthyPoints"></param>
        /// <param name="foodPoints"></param>
        /// <param name="nextStoryCurrentEpisode"></param>
        /// <param name="nextEpisodeId"></param>
        public Choice(int smartPoints, int popularityPoints, int wealthyPoints, int foodPoints, bool nextStoryCurrentEpisode, int nextEpisodeId)
        {
            this.SmartPoints = smartPoints;
            this.PopularityPoints = popularityPoints;
            this.WealthyPoints = wealthyPoints;
            this.FoodPoints = foodPoints;
            this.NextStoryCurrentEpisode = nextStoryCurrentEpisode;
            this.NextEpisodeId = nextEpisodeId;
        }
    }
}
