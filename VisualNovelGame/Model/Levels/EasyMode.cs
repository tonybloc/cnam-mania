using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cnam_mania.VisualNovelGame.Model.Characters;
using cnam_mania.VisualNovelGame.Model.Episodes;

namespace cnam_mania.VisualNovelGame.Model.Levels
{
    public class EasyMode : IlevelStrategy
    {
        // Define
        private static int coeff = 1;

        /// <summary>
        /// Create new instance of class
        /// </summary>
        public EasyMode() { }

        public void ExecuteChoice(Character character, Choice choice)
        {
            character.Food += choice.FoodPoints * coeff;
        }
    }
}
