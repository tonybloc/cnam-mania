using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Episodes
{
    public class Story
    {
        /// <summary>
        /// Current choice made.
        /// </summary>
        private Choice CurrentChoice { get; set; }

        /// <summary>
        /// Choices available for a story.
        /// </summary>
        private List<Choice> Choices { get; } = new List<Choice>(); 

        /// <summary>
        /// Defines if a story is crucial or not.
        /// </summary>
        private bool IsCrucial { get; set; }

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
