using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Memento
{
    public interface IOriginator
    {
        /// <summary>
        /// Create new instance of memento
        /// </summary>
        /// <returns>Memento</returns>
        IMemento Save();
    }
}
