using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Game
{

    public abstract class AbsGameManager
    {

        /// <summary>
        /// Create new instance of class
        /// </summary>
        public AbsGameManager()
        {
        }
 
        /// <summary>
        /// Start Game
        /// </summary>
        public abstract void Play();

    }
}