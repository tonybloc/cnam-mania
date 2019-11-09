using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cnam_mania.VisualNovelGame.Model.Episodes
{
    [Serializable]
    [XmlRoot("Episode")]
    public class Episode
    {
        /// <summary>
        /// Identifie the episode.
        /// </summary>
        [XmlElement("Id")]
        public int EpisodeId { get; set; }
        
        /// <summary>
        /// List of stories
        /// </summary>
        [XmlElement("Story")]
        public List<Story> Stories { get; set; }

        /// <summary>
        /// Create new instance of class
        /// </summary>
        public Episode()
        {
            Stories = new List<Story>();
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="episodeId"></param>
        /// <param name="currentStory"></param>
        public Episode(int episodeId)
        {
            EpisodeId = episodeId;
        }


        public override string ToString()
        {
            return string.Format("Episode {0} avec {1} histoire", this.EpisodeId, this.Stories.Count());
        }

    }
}
