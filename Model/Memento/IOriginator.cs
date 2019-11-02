using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Memento
{
    public interface IOriginator
    {
        /// <summary>
        /// Save the current SavingPoint state inside a memento.
        /// </summary>
        /// <returns></returns>
        IMemento Save();

        /// <summary>
        /// Restore the originator state from a memento object.
        /// </summary>
        /// <param name="memento"></param>
        void Restore(IMemento memento);
    }
}
