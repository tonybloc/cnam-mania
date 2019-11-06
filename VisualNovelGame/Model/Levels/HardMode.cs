using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cnam_mania.VisualNovelGame.Model.Characters;

namespace cnam_mania.VisualNovelGame.Model.Episodes
{
    public class HardMode : IModeStrategy
    {
        // Define
        private static int coeff = 3;

        /// <summary>
        /// Create new instance of class
        /// </summary>
        public HardMode() { }

        public void ExecuteChoice(Character character, Choice choice)
        {
            character.Food += choice.FoodPoints * coeff;
        }
    }
}
