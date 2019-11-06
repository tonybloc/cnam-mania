using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Characters
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
            this.Character = new Character();
            SetFoodAttribute();
            SetPopularityAttribute();
            SetIntelligenceAttribute();
            SetMoneyAttribute();
        }


        #region Methodes
        /// <summary>
        /// Update the food attribute of character
        /// </summary>
        public abstract void SetFoodAttribute();
        /// <summary>
        /// Update the popularity attribute of character
        /// </summary>
        public abstract void SetPopularityAttribute();
        /// <summary>
        /// Update the money attribute of character
        /// </summary>
        public abstract void SetMoneyAttribute();
        /// <summary>
        /// Update the intelligence attribute of character
        /// </summary>
        public abstract void SetIntelligenceAttribute();
        #endregion

    }
}
