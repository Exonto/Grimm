using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Core.Commands.Prompts;
using Grimm.Core.Commands.Prompts.Results;
using Grimm.Core.Commands.Results;
using Grimm.Game.GameWorld.Items;
using Grimm.Game.GameWorld.Strings.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class TakeCmdParser : ICommandParser<TakeCmd>
    {
        public TakeCmd Command { get; }

        private IParserService _parserService;

        public TakeCmdParser(TakeCmd cmd)
        {
            this.Command = cmd;

            _parserService = new ParserService(cmd.GameState);
        }

        public void ParseAndExecute(string nameOrAlias, Arguments args = null)
        {
            var grammar = new GrammarParser(args);

            if (!grammar.HasSubject())
            {
                ItemStrings.WHAT_ITEM.OutputResponse(nameOrAlias);
                return;
            }

            var target = grammar.GetSubject();

            if (!grammar.HasAnyPreposition())
            {
                TakeFrom(target, new Noun("here"));
                return;
            }

            if (grammar.HasPrepositionAt(Preposition.FROM, 1) ||
                grammar.HasPrepositionAt(Preposition.OUT, 1) ||
                grammar.HasPrepositionAt(Preposition.IN, 1) ||
                grammar.HasPrepositionAt(Preposition.WITHIN, 1) ||
                grammar.HasPrepositionAt(Preposition.INSIDE, 1))
            {
                var location = grammar.GetObjectOfPreposition(grammar.GetPreposition(1));

                if (location == null)
                {
                    ItemStrings.TAKE_FROM_WHERE.OutputResponse(target);
                    return;
                }

                TakeFrom(target, location);
                return;
            }

            CommandStrings.NO_UNDERSTAND_TAKE.OutputResponse(target);
        }

        private void TakeFrom(Noun target, Noun location)
        {
            var locationWord = location.Word;

            // Special case where the word "here" is used to define the current location
            if (locationWord == "here")
                TakeFromCurrentLocation(target);
            else
                TakeFromContainer(target, location);
        }

        private void TakeFromCurrentLocation(Noun target)
        {
            var targetItem = _parserService.GetItemFromCurrentLocation(target);

            if (targetItem == null)
            {
                ItemStrings.ITEM_DOES_NOT_EXIST.OutputResponse(target);
                return;
            }

            if (!targetItem.IsTakeable)
            {
                ItemStrings.ITEM_CANNOT_BE_TAKEN.OutputResponse(targetItem.Name);
                return;
            }

            this.Command.TakeItemFromCurrentLocation(targetItem);

            targetItem.ItemStrings.ITEM_TAKEN.OutputResponse();
            return;
        }

        private void TakeFromContainer(Noun target, Noun container)
        {
            // Check to see if there is an item
            var containerItem = _parserService.GetItemFromCurrentLocation(container);

            if (containerItem != null)
            {
                if (!containerItem.IsContainer)
                {
                    ItemStrings.ITEM_NOT_CONTAINER.OutputResponse(container);
                    return;
                }

                var targetItem = _parserService.GetItemFromContainer(target, container);

                if (!containerItem.HasItem(targetItem))
                {
                    ItemStrings.ITEM_NOT_IN_CONTAINER.OutputResponse(target, container);
                    return;
                }

                if (!targetItem.IsTakeable)
                {
                    ItemStrings.ITEM_CANNOT_BE_TAKEN.OutputResponse(target);
                    return;
                }

                this.Command.TakeItemFromContainer(targetItem, containerItem);
                targetItem.ItemStrings.ITEM_TAKEN.OutputResponse();
                return;
            }

            ItemStrings.ITEM_DOES_NOT_EXIST.OutputResponse(container);
        }
    }
}
