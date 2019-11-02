using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cnam_mania.Model.Characters;
using cnam_mania.Model.Episodes;

namespace cnam_mania.Model.Levels
{
    public class MediumMode : IlevelStrategy
    {
        // Define
        private static int coeff = 2;

        /// <summary>
        /// Create new instance of class
        /// </summary>
        public MediumMode() { }

        public void ExecuteChoice(Character character, Choice choice)
        {
            character.Food += choice.FoodPoints * coeff;
        }
    }
}
