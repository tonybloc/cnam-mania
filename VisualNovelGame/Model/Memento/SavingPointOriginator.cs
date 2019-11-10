using cnam_mania.VisualNovelGame.Model.Characters;
using cnam_mania.VisualNovelGame.Model.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Memento
{
    public class SavingPointOriginator : IOriginator
    {
        /// <summary>
        /// Character to save
        /// </summary>
        private Character _characterState { get; set; }

        /// <summary>
        /// Episode to save
        /// </summary>
        private Episode _episodeState { get; set; }


        #region Constructor
        /// <summary>
        /// Create new instance of SavingPointOriginator
        /// </summary>
        public SavingPointOriginator()
        {
            this._characterState = null;
            this._episodeState = null;
        }
        #endregion


        /// <summary>
        /// Update origin character state
        /// </summary>
        /// <param name="state">Character state</param>
        public void SetCharacterState(Character state)
        {
            this._characterState = state; 
        }

        /// <summary>
        /// Update origin episode state
        /// </summary>
        /// <param name="state">Epsiode state</param>
        public void SetEpisodeState(Episode state)
        {
            this._episodeState = state;
        }

        public Character GetCharacterState() { return this._characterState; }
        public Episode GetEpisodeState() { return this._episodeState; }



        #region IOriginator implementation
        /// <summary>
        /// Save the current SavingPoint state inside a memento.
        /// </summary>
        /// <returns></returns>
        public IMemento Save()
        {
            return new SavingPointMemento(this, this._characterState, this._episodeState);
        }
        #endregion

    }
}
