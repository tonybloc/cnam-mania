using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Characters
{
    public class PopularCharacterBuilder : CharacterBuilder
    {
        /// <summary>
        /// Create new instance of PopularCharacterBuidler
        /// </summary>
        public PopularCharacterBuilder() : base() { }

        public override void SetFoodAttribute()
        {
            base.Character.Food = 50;
        }

        public override void SetIntelligenceAttribute()
        {
            base.Character.Intellect = 40;
        }

        public override void SetMoneyAttribute()
        {
            base.Character.Money = 50;
        }

        public override void SetPopularityAttribute()
        {
            base.Character.Popularity = 70;
        }
    }
}
