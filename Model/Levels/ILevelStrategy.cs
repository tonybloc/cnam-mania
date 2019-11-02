using cnam_mania.Model.Characters;
using cnam_mania.Model.Episodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.Levels
{
    public interface IlevelStrategy
    {
        void ExecuteChoice(Character character, Choice choice);
    }
}