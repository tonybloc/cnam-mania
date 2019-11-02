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
    }
}
