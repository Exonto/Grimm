using Grimm.Core.Commands.Prompts;
using Grimm.Core.Commands.Prompts.Results;
using Grimm.Core.Commands.Results;
using Grimm.Game.GameWorld.Strings.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class DropCmdParser : ICommandParser<DropCmd>
    {
        public DropCmd Command { get; }

        private IParserService _parserService;

        public DropCmdParser(DropCmd cmd)
        {
            this.Command = cmd;

            _parserService = new ParserService(this.Command.GameState);
        }

        public void ParseAndExecute(string alias, Arguments args = null)
        {
            var grammar = new GrammarParser(args);

            if (!grammar.HasSubject())
            {
                ItemStrings.WHAT_ITEM.OutputResponse(alias);
                return;
            }

            var target = grammar.GetSubject();

            var playerInventory = this.Command.GameState.Player.Inventory;
            var targetItem = _parserService.GetItemFromInventory(target, playerInventory);

            if (targetItem == null)
            {
                ItemStrings.ITEM_NOT_IN_PLAYER_INVENTORY.OutputResponse(target);
                return;
            }

            if (!targetItem.IsDroppable)
            {
                ItemStrings.ITEM_CANNOT_BE_DROPPED.OutputResponse(targetItem.Name);
                return;
            }

            this.Command.DropItem(targetItem);

            targetItem.ItemStrings.ITEM_DROPPED.OutputResponse();
        }
    }
}
