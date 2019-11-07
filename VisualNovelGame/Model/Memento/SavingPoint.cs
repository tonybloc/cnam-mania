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
        /// <summary>
        /// Character to save
        /// </summary>
        public Character CharacterState { get; set; } 

        /// <summary>
        /// Episode to save
        /// </summary>
        public Episode EpisodeState { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="characterState"></param>
        /// <param name="episodeToSave"></param>
        public SavingPoint(Character characterState, Episode episodeToSave)
        {
            CharacterState = characterState;
            EpisodeState = episodeToSave;
        }
    }
}
