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
            character.Food += (choice.FoodPoints < 1) ? Math.Abs(choice.FoodPoints) * coeff * (-1) : choice.FoodPoints * coeff;
            character.Intellect += (choice.SmartPoints < 1) ? Math.Abs(choice.SmartPoints) * coeff * (-1) : choice.SmartPoints * coeff;
            character.Popularity += (choice.PopularityPoints < 1) ? Math.Abs(choice.PopularityPoints) * coeff * (-1) : choice.PopularityPoints * coeff;
            character.Money += (choice.WealthyPoints < 1) ? Math.Abs(choice.WealthyPoints) * coeff * (-1) : choice.WealthyPoints * coeff;
        }
    }
}
