using cnam_mania.FactGame.Manager;
using cnam_mania.VisualNovelGame.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cnam_mania.Game
{
    public static class MiniGamesFactory
    {
        /// <summary>
        /// Create the desired game manager 
        /// </summary>
        /// <param name="game">Game desired by the user</param>
        /// <returns></returns>
        public static AbsGameManager CreateGamesManager(string game)
        {
            AbsGameManager manager;
            switch (game)
            {
                case "Fact":
                    manager = FactManager.Instance;
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