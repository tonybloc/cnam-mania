using cnam_mania.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Manager.Characters
{
    public class CharacterManager
    {
        // Unique instance of class.
        private CharacterManager _instance = null;

        /// <summary>
        /// Create new instance of CharacterManager.
        /// </summary>
        private CharacterManager() {}

        /// <summary>
        /// Get unique instance of CharacterManager
        /// </summary>
        /// <returns>Unique instance of class</returns>
        public CharacterManager GetInstance()
        {
            if (this._instance == null)
            {
                this._instance = new CharacterManager();
            }

            return this._instance;
        }

        /// <summary>
        /// Create new SmartCharacter.
        /// </summary>
        /// <returns>Smart Character</returns>
        public Character CreateSmartCharacter()
        {
            return new SmartCharacterBuilder().Character;
        }

        /// <summary>
        /// Create new RichCharacter.
        /// </summary>
        /// <returns>Rich Character</returns>
        public Character CreateRichCharacter()
        {
            return new RichCharacterBuilder().Character;
        }

        /// <summary>
        /// Create new PopularCharacter.
        /// </summary>
        /// <returns>Popular Character</returns>
        public Character CreatePopularCharacter()
        {
            return new PopularCharacterBuilder().Character;
        }

        /// <summary>
        /// Create new GreedyCharacter.
        /// </summary>
        /// <returns>Greedy Character</returns>
        public Character CreateGreedyCharacter()
        {
            return new GreedyCharacterBuilder().Character;
        }
    }
}
