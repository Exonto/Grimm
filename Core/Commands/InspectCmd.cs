using Grimm.Core.Commands.Parsers;
using Grimm.Game;
using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public class InspectCmd : Command
    {
        public InspectCmd(GameState state) 
            : base("inspect", new string[] { "i", "examine" })
        {
            this.GameState = state;

            base._parser = new InspectCmdParser(this);
        }

        public override void Execute(string alias, Arguments args = null)
        {
            base._parser.ParseAndExecute(alias, args);
        }

        public void InspectItemInCurrentLocation(Item item)
        {
            var player = this.GameState.Player;

            player.InspectItem(item);
        }

        public void InspectItemInContainer(Item item, Item container)
        {
            var player = this.GameState.Player;

            player.InspectItemInContainer(item, container);
        }
    }
}
