using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Game
{

    public abstract class AbsGameManager
    {

        private string name { get; set; }


        // Main Method 
        public abstract void Play();

    }
}