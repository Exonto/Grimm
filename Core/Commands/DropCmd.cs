using Grimm.Core.Commands.Parsers;
using Grimm.Core.Commands.Prompts;
using Grimm.Game;
using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public class DropCmd : Command
    {
        public DropCmd(GameState state) 
            : base("drop", new string[] { })
        {
            this.GameState = state;

            base._parser = new DropCmdParser(this);
        }

        public override void Execute(string alias, Arguments args = null)
        {
            base._parser.ParseAndExecute(alias, args);
        }

        public void DropItem(Item item)
        {
            var player = this.GameState.Player;

            player.DropItem(item);
        }
    }
}
