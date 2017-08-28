using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimm.Game;
using Grimm.Game.GameWorld;
using Grimm.Core;

namespace Grimm
{
    public class Program
    {
        public static GameState GameState = new GameState();

        static void Main(string[] args)
        {
            GameState.StartGame();
        }
    }
}
