using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Characters
{
    public abstract class CharacterBuilder
    {
        #region Attributes
        public Character Character { get; private set; }
        #endregion

        /// <summary>
        /// Create new instance of "CharacterBuilder" class
        /// </summary>
        public CharacterBuilder()
        {
            this.Character = null;
        }


        #region Methodes
        /// <summary>
        /// Update the food attribute of character
        /// </summary>
        /// <param name="value"></param>
        public abstract void SetFoodAttribute(int value);
        /// <summary>
        /// Update the popularity attribute of character
        /// </summary>
        /// <param name="value">value to set</param>
        public abstract void SetPopularity(int value);
        /// <summary>
        /// Update the money attribute of character
        /// </summary>
        /// <param name="value">value to set</param>
        public abstract void SetMoney(int value);
        /// <summary>
        /// Update the intelligence attribute of character
        /// </summary>
        /// <param name="value">value to set</param>
        public abstract void SetIntelligence(int value);
        #endregion

    }
}
