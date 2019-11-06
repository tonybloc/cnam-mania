using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Characters
{
    public class Character
    {
        #region Attributes
        #region (Public) Attributes
        public int Intellect { get; set; }
        public int Food { get; set; }
        public int Popularity { get; set; }
        public int Money { get; set; }
        #endregion
        #endregion

        /// <summary>
        /// Create new instance of 'character' class.
        /// </summary>
        public Character() { }

        /// <summary>
        /// Create new instance of 'character' class.
        /// </summary>
        /// <param name="intel">Value of initial intelligence</param>
        /// <param name="food">Value of initial food</param>
        /// <param name="popularity">Value of inital popularity</param>
        /// <param name="money">Value of initial money</param>
        public Character(int intel, int food, int popularity, int money)
        {
            this.Intellect = intel;
            this.Food = food;
            this.Popularity = popularity;
            this.Money = money;
        }
    }
}
