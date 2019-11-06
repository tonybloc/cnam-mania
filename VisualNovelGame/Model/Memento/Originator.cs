using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Memento
{
    public class Originator
    {
        /// <summary>
        /// Saving point.
        /// </summary>
        private SavingPoint SavingPoint;
        
        /// <summary>
        /// Initialize the saving point.
        /// </summary>
        /// <param name="savingPoint"></param>
        public void SetSavingPoint(SavingPoint savingPoint)
        {
            this.SavingPoint = savingPoint; 
        }
        /// <summary>
        /// Retrieves the saving point.
        /// </summary>
        /// <returns></returns>
        public SavingPoint GetSavingPoint()
        {
            return this.SavingPoint;
        }
        /// <summary>
        /// Save the current SavingPoint state inside a memento.
        /// </summary>
        /// <returns></returns>
        public SavingPointMemento Save()
        {
            return new SavingPointMemento(this.SavingPoint);
        }

        /// <summary>
        /// Restore the originator state from a memento object.
        /// </summary>
        /// <param name="memento"></param>
        public void Restore(SavingPointMemento memento)
        {
            this.SavingPoint = memento.GetSavingPoint();
        }
    }
}
