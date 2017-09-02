using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class InspectCmdParser : ICommandParser<InspectCmd>
    {
        private const string NO_SUBJECT = "What do you want to {0}?";

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

                Output.WriteNewLine(string.Format(NO_SUBJECT, nameOrAlias));
                return;
            }

            var target = grammar.GetSubject();

            if (_parserService.HasItemInCurrentLocation(target))
            {
                var targetItem = _parserService.GetItemFromCurrentLocation(target);

                targetItem.Inspect();
            }
        }
    }
}
