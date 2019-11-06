using cnam_mania.VisualNovelGame.Model.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.VisualNovelGame.Model.Episodes
{
    public interface IlevelStrategy
    {
        void ExecuteChoice(Character character, Choice choice);
    }
}