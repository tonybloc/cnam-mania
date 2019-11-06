using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Memento
{
    public class SavingPointMemento : IMemento
    {
        /// <summary>
        /// Saving point to save and restore
        /// </summary>
        private SavingPoint _state;

        /// <summary>
        /// Class constructor 
        /// </summary>
        /// <param name="state"></param>
        public SavingPointMemento(SavingPoint state)
        {
            _state = state;
        }

        /// <summary>
        /// Originator uses this method when restoring its state.
        /// </summary>
        /// <returns></returns>
        public SavingPoint GetSavingPoint()
        {
            return this._state; 
        }
    }
}
