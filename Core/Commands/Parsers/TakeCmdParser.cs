using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Core.Commands.Prompts;
using Grimm.Core.Commands.Prompts.Results;
using Grimm.Core.Commands.Results;
using Grimm.Game.GameWorld.Items;
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

        public TakeCmdParser(TakeCmd cmd)
        {
            this.Command = cmd;
        }

        public void ParseAndExecute(string alias, Arguments args = null)
        {
            var grammar = new GrammarParser(args);

            if (!grammar.HasSubject())
            {
                Output.WriteLine("You must choose what you want to take.");
                return;
            }

            var target = grammar.GetSubject();

            if (!grammar.HasAnyPreposition())
            {
                var targetItem = GetItem(target);

                if (targetItem == null)
                {
                    Output.WriteNewLine($"There is no {target} here.");
                    return;
                }

                this.Command.TakeItemFromCurrentLocation(targetItem);

                Output.WriteLine($"Taken.");
                return;
            }

            if (grammar.HasPrepositionAt(Preposition.FROM, 1) ||
                grammar.HasPrepositionAt(Preposition.OUT, 1))
            {
                if (grammar.HasObjectOfPreposition(Preposition.FROM) ||
                    grammar.HasObjectOfPreposition(Preposition.OUT))
                {
                    target = grammar.GetSubject();
                    var location = grammar.GetObjectOfPreposition(grammar.GetPreposition(1));

                    TakeFrom(target, location);
                }
            }
        }

        private Item GetItem(Noun itemNoun)
        {
            var currentLoc = this.Command.GameState.GetPlayerLocation();
            return currentLoc.Inventory.Items.FirstOrDefault(i => i.Name.ToLower() == itemNoun.Word.ToLower() &&
                                                                  i.HasAdjectives(itemNoun.Adjectives));
        }

        private void TakeFrom(Noun target, Noun location)
        {
            if (location.Word != "chest")
            {
                Output.WriteLine($"Cannot find a {location} here.");
                return;
            }
            else if (target.Word != "sword")
            {
                Output.WriteLine($"There isn't a {target} inside the {location}");
                return;
            }

            Output.WriteLine($"Taken.");
        }

    }
}
