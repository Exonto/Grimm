using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Game.GameWorld.Strings.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class InspectCmdParser : ICommandParser<InspectCmd>
    {
        public InspectCmd Command { get; }

        private IParserService _parserService;

        public InspectCmdParser(InspectCmd cmd)
        {
            this.Command = cmd;

            _parserService = new ParserService(cmd.GameState);
        }

        public void ParseAndExecute(string nameOrAlias, Arguments args = null)
        {
            var grammar = new GrammarParser(args);

            if (!grammar.HasSubject())
            {
                // Converts a shortcut alias into its full name for the sake of a natural response
                if (nameOrAlias == "i")
                    nameOrAlias = "inspect";

                ItemStrings.WHAT_ITEM.OutputResponse(nameOrAlias);
                return;
            }

            var target = grammar.GetSubject();

            if (!grammar.HasAnyPreposition())
            {
                InspectFromCurrentLocation(target);
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
                    ItemStrings.INSPECT_FROM_WHERE.OutputResponse(target);
                    return;
                }

                InspectInside(target, location);
                return;
            }

            CommandStrings.NO_UNDERSTAND_INSPECT.OutputResponse(target);
        }

        private void InspectInside(Noun target, Noun location)
        {
            var locationWord = location.Word;

            // Special case where the word "here" is used to define the current location
            if (locationWord == "here")
                InspectFromCurrentLocation(target);
            else
                InspectInsideContainer(target, location);
        }

        private void InspectFromCurrentLocation(Noun target)
        {
            if (_parserService.HasItemInCurrentLocation(target))
            {
                var targetItem = _parserService.GetItemFromCurrentLocation(target);

                this.Command.InspectItemInCurrentLocation(targetItem);
                return;
            }

            ItemStrings.ITEM_DOES_NOT_EXIST.OutputResponse(target);
        }

        private void InspectInsideContainer(Noun target, Noun container)
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

                this.Command.InspectItemInContainer(targetItem, containerItem);
                return;
            }

            ItemStrings.ITEM_DOES_NOT_EXIST.OutputResponse(container);
        }
    }
}
