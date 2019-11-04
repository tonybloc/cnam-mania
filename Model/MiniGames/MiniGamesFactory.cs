using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Model.MiniGames
{
    public static class MiniGamesFactory
    {
        public static AbsGameManager createGamesManager(string game)
        {
            AbsGameManager manager;
            switch (game)
            {
                case "Rebut":
                    manager = new RebutManager();
                    break;
                case "Riddle":
                    manager = new RiddleManager();
                    break;
                case "VisualNovel":
                    manager = VisualNovelManager.Instance;
                    break;
                default:
                    manager = VisualNovelManager.Instance;
                    break;                   
            }
            return manager;
        }
    }
}