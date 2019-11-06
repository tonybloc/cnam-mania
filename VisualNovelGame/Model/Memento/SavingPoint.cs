using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cnam_mania.VisualNovelGame.Model.Characters;
using cnam_mania.VisualNovelGame.Model.Episodes;

namespace cnam_mania.VisualNovelGame.Model.Memento
{
    public class SavingPoint
    {
        private Character CharacterState { get; set; } 

        private Episode EpisodeState { get; set; }

        public SavingPoint(Character characterState, Episode episodeToSave)
        {
            CharacterState = characterState;
            EpisodeState = episodeToSave;
        }

        public IMemento Save()
        {
            return new SavingPointMemento(this);
        }

        public void Restore(IMemento memento)
        {
            if (!(memento is SavingPointMemento))
            {
                throw new Exception("Unknown Memento class: " + memento.ToString());
            }
            this.CharacterState = memento.GetSavingPoint().CharacterState;
            this.EpisodeState= memento.GetSavingPoint().EpisodeState;
        }
    }
}
