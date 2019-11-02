using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.MiniGames
{
public class MiniGamesFactory
    {
        public AbsGameManager createGamesManager(string game)
        {
            switch (game)
            {
                case "Rebut":
                return new RebutManager();
                break;
                case "Riddle":
                return new RiddleManager();
                break;
                case "VisualNovel":
                return new VisualNovel();
                break;
            }
        }
    }
}