using Grimm.Core.Commands.Parsers;
using Grimm.Game;
using Grimm.Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public class MoveCmd : Command
    {
        public MoveCmd(GameState state) 
            : base("move", new string[] 
            {
                "go", "walk",
                "n", "s", "e", "w", "up", "down",
                "north", "south", "east", "west"
            })
        {
            this.GameState = state;

            _parser = new MoveCmdParser(this);
        }

        public override void Execute(string alias, Arguments args = null)
        {
            _parser.ParseAndExecute(alias, args);
        }

        public void MoveInDirection(Direction dir)
        {
            var player = this.GameState.Player;

            if (!player.CanMove(dir))
            {
                Output.WriteNewLine("You cannot go that direction.");
                return;
            }

            player.Move(dir);
        }


    }
}
