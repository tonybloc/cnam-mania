using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Exceptions
{
    public class EpisodeNotFound : Exception
    {

        public EpisodeNotFound() : base("Epsiode not found !") { }
        public EpisodeNotFound(int id) : base(string.Format("Epsiode {0} was not found ! ", id)) {}
    }
}
