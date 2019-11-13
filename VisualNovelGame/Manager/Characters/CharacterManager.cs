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
        /// Current character of visual novel game
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// Character builder.
        /// </summary>
        public CharacterBuilder CharacterBuilder { get; private set; }


        /// <summary>
        /// Create new instance of CharacterManager.
        /// </summary>
        private CharacterManager()
        {
            // Default character
            this.Character = null;
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
            this.Character = this.CharacterBuilder.GetCharacter();
        }

        /// <summary>
        /// Clear manager data
        /// </summary>
        public static void Clear()
        { 
            _instance = null;
        }
    }
}
