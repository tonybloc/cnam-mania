using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Characters
{
    public class SmartCharacterBuilder : CharacterBuilder
    {
        /// <summary>
        /// Create new instance of PopularCharacterBuidler
        /// </summary>
        public SmartCharacterBuilder() : base() { }

        public override void SetFoodAttribute()
        {
            this.Character.Food = 40;
        }

        public override void SetIntelligenceAttribute()
        {
            this.Character.Intellect = 70;
        }

        public override void SetMoneyAttribute()
        {
            this.Character.Money = 60;
        }

        public override void SetPopularityAttribute()
        {
            this.Character.Popularity = 40;
        }
    }
}
