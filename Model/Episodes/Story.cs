using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cnam_mania.Model.Episodes
{
    [Serializable]
    [XmlRoot("Story")]
    public class Story
    {
        /// <summary>
        /// Identify the story
        /// </summary>
        [XmlElement("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Current choice made.
        /// </summary>
        private Choice CurrentChoice { get; set; }

        /// <summary>
        /// Choices available for a story.
        /// </summary>
        [XmlElement("Choice")]
        public List<Choice> Choices { get; set; }

        /// <summary>
        /// Defines if a story is crucial or not.
        /// </summary>
        [XmlElement("IsCrucial")]
        public bool IsCrucial { get; set; }

        /// <summary>
        /// Title of the story
        /// </summary>
        [XmlElement("Title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Story()
        {
            Choices = new List<Choice>();
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="currentChoice"></param>
        /// <param name="choices"></param>
        /// <param name="isCrucial"></param>
        public Story(Choice currentChoice, List<Choice> choices, bool isCrucial)
        {
            CurrentChoice = currentChoice;
            Choices = choices;
            IsCrucial = isCrucial;
        }
    }
}
