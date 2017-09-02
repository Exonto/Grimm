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
    public class LookCmd : Command
    {
        public LookCmd(GameState state) 
            : base("look", new string[] { })
        {
            this.GameState = state;

            base._parser = new LookCmdParser(this);
        }

        public override void Execute(string alias, Arguments args = null)
        {
            base._parser.ParseAndExecute(alias, args);
        }

        public void OutputLocationDescription()
        {
            var player = this.GameState.Player;

            player.Location.OutputDescription();
        }

        public void LookInsideContainer(Item container)
        {
            var player = this.GameState.Player;

            player.LookInsideContainer(container);
        }
    }
}
