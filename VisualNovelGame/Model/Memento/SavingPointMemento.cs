using cnam_mania.VisualNovelGame.Model.Characters;
using cnam_mania.VisualNovelGame.Model.Episodes;
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
        /// Character to save
        /// </summary>
        public Character CharacterState { get;  private set; }

        /// <summary>
        /// Episode to save
        /// </summary>
        public Episode EpisodeState { get; private set; }


        /// <summary>
        /// Originator 
        /// </summary>
        private SavingPointOriginator _originator;

        /// <summary>
        /// Create new instance of class
        /// </summary>
        /// <param name="originator">Originator</param>
        /// <param name="state">Saving point</param>
        public SavingPointMemento(SavingPointOriginator originator, Character characterState, Episode episodeState)
        {
            _originator = originator;
            this.CharacterState = characterState;
            this.EpisodeState = episodeState;
        }

        /// <summary>
        /// Originator uses this method when restoring its state.
        /// </summary>
        public void Restore()
        {
            _originator.SetCharacterState(CharacterState);
            _originator.SetEpisodeState(EpisodeState);
        }

    }
}
