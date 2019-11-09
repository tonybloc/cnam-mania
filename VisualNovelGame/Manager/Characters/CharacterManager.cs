using cnam_mania.VisualNovelGame.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Manager
{
    public class CharacterManager
    {
        // Unique instance of class.
        private static CharacterManager _instance = null;

        /// <summary>
        /// Character builder.
        /// </summary>
        public CharacterBuilder CharacterBuilder { get; private set; }

        /// <summary>
        /// Create new instance of CharacterManager.
        /// </summary>
        private CharacterManager()
        {
        }

        /// <summary>
        /// Instance of a CharacterManager
        /// </summary>
        public static CharacterManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CharacterManager();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Determines the character builder choosen.
        /// </summary>
        /// <param name="characterBuilder"></param>
        public void SetCharacterBuilder(CharacterBuilder characterBuilder)
        {
            this.CharacterBuilder = characterBuilder;
        }

        /// <summary>
        /// Creates a character regarding of the builder choosen.
        /// </summary>
        public void CreateCharacter()
        {
            this.CharacterBuilder.SetFoodAttribute();
            this.CharacterBuilder.SetIntelligenceAttribute();
            this.CharacterBuilder.SetMoneyAttribute();
            this.CharacterBuilder.SetPopularityAttribute();
        }
    }
}
