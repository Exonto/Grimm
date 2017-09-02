using Grimm.Core.Commands.Parsers;
using Grimm.Core.Commands.Prompts;
using Grimm.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public class InventoryCmd : Command
    {
        public InventoryCmd(GameState state) 
            : base("inventory", new string[] { "inv" })
        {
            base._parser = new InventoryCmdParser(this);

            this.GameState = state;
        }

        public override void Execute(string alias, Arguments args = null)
        {
            base._parser.ParseAndExecute(alias, args);
        }

        public void OpenPlayerInventory()
        {
            var player = this.GameState.Player;

            player.OpenInventory();
        }
    }
}
