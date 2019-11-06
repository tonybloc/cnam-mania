using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cnam_mania.VisualNovelGame.Model.Episodes
{
    [Serializable]
    [XmlRoot("Choice")]
    public class Choice
    {
        #region Attributes
        [XmlElement("Description")]
        public string Description { get; set; }
        /// <summary>
        /// Smartness points. 
        /// </summary>
        [XmlElement("Smart")]
        public int SmartPoints { get; set; }

        /// <summary>
        /// Popularity points. 
        /// </summary>
        [XmlElement("Popularity")]
        public int PopularityPoints { get; set; }

        /// <summary>
        /// Money points. 
        /// </summary>
        [XmlElement("Money")]
        public int WealthyPoints { get; set; }

        /// <summary>
        /// Food points. 
        /// </summary>
        [XmlElement("Food")]
        public int FoodPoints { get; set; }

        /// <summary>
        /// Defines if the episode will be continued or not.
        /// </summary>
        [XmlElement("NextStoryCurrentEpisode")]
        public bool NextStoryCurrentEpisode { get; set; }

        /// <summary>
        /// Id of the next episode. 
        /// </summary>
        [XmlElement("NextEpisodeId")]
        public int NextEpisodeId { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Class constructor
        /// </summary>
        public Choice()
        {

        }

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
        #endregion
    }
}
