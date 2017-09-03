using Grimm.Core.Commands.Parsers.Grammar;
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
    public class LookCmdParser : ICommandParser<LookCmd>
    {
        public LookCmd Command { get; }

        private IParserService _parserService;
        public LookCmdParser(LookCmd cmd)
        {
            this.Command = cmd;

            _parserService = new ParserService(this.Command.GameState);
        }

        public void ParseAndExecute(string alias, Arguments args = null)
        {
            var grammar = new GrammarParser(args);

            var hasPrepositions = grammar.HasAnyPreposition();
            if (!grammar.HasSubject() && !hasPrepositions)
            {
                this.Command.OutputLocationDescription();
                return;
            }

            if (hasPrepositions)
            {
                if (grammar.HasPrepositionAt(Preposition.IN, 1) ||
                    grammar.HasPrepositionAt(Preposition.WITHIN, 1) ||
                    grammar.HasPrepositionAt(Preposition.INSIDE, 1))
                {
                    var location = grammar.GetObjectOfPreposition(grammar.GetPreposition(1));

                    if (location == null)
                    {
                        ItemStrings.LOOK_INSIDE_WHAT.OutputResponse();
                        return;
                    }

                    LookInsideContainer(location);
                    return;
                }

                CommandStrings.NO_UNDERSTAND_LOOK.OutputResponse();
            }

            CommandStrings.NO_UNDERSTAND_LOOK.OutputResponse();
        }

        private void LookInsideContainer(Noun container)
        {
            var targetContainer = _parserService.GetItemFromCurrentLocation(container);

            if (targetContainer == null)
            {
                ItemStrings.ITEM_DOES_NOT_EXIST.OutputResponse(container);
                return;
            }

            this.Command.LookInsideContainer(targetContainer);
        }
    }
}
