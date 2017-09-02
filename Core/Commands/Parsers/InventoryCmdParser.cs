using Grimm.Core.Commands.Prompts;
using Grimm.Core.Commands.Prompts.Results;
using Grimm.Core.Commands.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class InventoryCmdParser : ICommandParser<InventoryCmd>
    {
        public InventoryCmd Command { get; }

        public InventoryCmdParser(InventoryCmd cmd)
        {
            this.Command = cmd;
        }

        public void ParseAndExecute(string alias, Arguments args = null)
        {
            this.Command.OpenPlayerInventory();
        }
    }
}
