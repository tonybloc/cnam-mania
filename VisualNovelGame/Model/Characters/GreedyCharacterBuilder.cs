using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Characters
{
    public class GreedyCharacterBuilder : CharacterBuilder
    {
        /// <summary>
        /// Create new instance of GreedyCharacterBuilder
        /// </summary>
        public GreedyCharacterBuilder() : base() {}

        protected override void SetFoodAttribute()
        {
            base.Character.Food = 70;
        }

        protected override void SetIntelligenceAttribute()
        {
            base.Character.Intellect = 60;
        }

        protected override void SetMoneyAttribute()
        {
            base.Character.Money = 40;
        }

        protected override void SetPopularityAttribute()
        {
            base.Character.Popularity = 40;
        }
    }
}
