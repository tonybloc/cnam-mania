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
        protected Character Character { get; set; }
        #endregion

        #region Methodes
        /// <summary>
        /// Creates a new Character. 
        /// </summary>
        public CharacterBuilder()
        {
            this.Character = new Character();
            SetFoodAttribute();
            SetPopularityAttribute();
            SetMoneyAttribute();
            SetIntelligenceAttribute();
        }
        
        /// <summary>
        /// Retrieves the Character built.
        /// </summary>
        /// <returns></returns>
        public Character GetCharacter()
        {   
            return this.Character;
        }


        /// <summary>
        /// Update the food attribute of character
        /// </summary>
        protected abstract void SetFoodAttribute();
        /// <summary>
        /// Update the popularity attribute of character
        /// </summary>
        protected abstract void SetPopularityAttribute();
        /// <summary>
        /// Update the money attribute of character
        /// </summary>
        protected abstract void SetMoneyAttribute();
        /// <summary>
        /// Update the intelligence attribute of character
        /// </summary>
        protected abstract void SetIntelligenceAttribute();
        #endregion

    }
}
