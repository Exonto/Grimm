using Grimm.Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class MoveCmdParser : ICommandParser<MoveCmd>
    {
        public MoveCmd Command { get; }

        public MoveCmdParser(MoveCmd cmd)
        {
            this.Command = cmd;
        }

        public void ParseAndExecute(string alias, Arguments args = null)
        {
            if (alias == "move" ||
                alias == "go" ||
                alias == "walk")
                ParseAndExecuteWithArgs(args);
            else
                ParseAndExecuteDirection(alias);
        }

        private void ParseAndExecuteWithArgs(Arguments args)
        {
            if (!args.HasAtLeast(1))
            {
                Output.WriteNewLine("Where do you want to move to?");
                return;
            }

            var grammar = new GrammarParser(args);
            if (grammar.HasSubject())
            {
                ParseAndExecuteDirection(grammar.GetSubject());
            }
            else
            {
                var preposition = grammar.GetPreposition(1);
                if (preposition == Preposition.TO)
                {
                    if (grammar.HasObjectOfPreposition(preposition))
                    {
                        var objOfPrep = grammar.GetObjectOfPreposition(preposition);
                        ParseAndExecuteDirection(objOfPrep);
                    }
                    else
                    {
                        Output.WriteNewLine("Where do you want to move to?");
                    }
                }
                else
                {
                    Output.WriteNewLine("I don't understand where you want to go.");
                }
            }
        }

        private void ParseAndExecuteDirection(string direction)
        {
            var dir = Direction.GetByName(direction);

            if (dir == null)
                return;

            this.Command.MoveInDirection(dir);
        }
    }
}
