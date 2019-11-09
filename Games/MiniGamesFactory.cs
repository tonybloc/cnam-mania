using cnam_mania.RebutGame;
using cnam_mania.RiddleGame;
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
        public static AbsGameManager createGamesManager(string game)
        {
            AbsGameManager manager;
            switch (game)
            {
                case "Rebus":
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