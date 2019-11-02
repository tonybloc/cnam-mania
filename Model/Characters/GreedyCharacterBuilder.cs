using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Characters
{
    public class GreedyCharacterBuilder : CharacterBuilder
    {
        /// <summary>
        /// Create new instance of GreedyCharacterBuilder
        /// </summary>
        public GreedyCharacterBuilder() : base() {}

        public override void SetFoodAttribute()
        {
            this.Character.Food = 70;
        }

        public override void SetIntelligenceAttribute()
        {
            this.Character.Intellect = 60;
        }

        public override void SetMoneyAttribute()
        {
            this.Character.Money = 40;
        }

        public override void SetPopularityAttribute()
        {
            this.Character.Popularity = 40;
        }
    }
}
