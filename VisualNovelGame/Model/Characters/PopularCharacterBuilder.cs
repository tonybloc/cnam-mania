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
            this.Character.Food = 50;
        }

        public override void SetIntelligenceAttribute()
        {
            this.Character.Intellect = 40;
        }

        public override void SetMoneyAttribute()
        {
            this.Character.Money = 50;
        }

        public override void SetPopularityAttribute()
        {
            this.Character.Popularity = 70;
        }
    }
}
