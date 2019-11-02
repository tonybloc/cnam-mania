using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Memento
{
    public interface IMemento
    {
        /// <summary>
        /// Used to retrieve the memento's data.
        /// </summary>
        /// <returns></returns>
        SavingPoint GetSavingPoint();
    }
}
