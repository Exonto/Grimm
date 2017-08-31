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
        private const string NO_SUBJECT = "What do you want to {0}?";
        private const string NO_ITEM = "There is no {0} here.";
        private const string ITEM_NOT_TAKEABLE = "You cannot take the {0}.";
        private const string ITEM_TAKEN = "Taken.";
        private const string TAKE_ITEM_FROM_WHERE = "Take {0} from where?";

        public TakeCmd Command { get; }
        public TakeCmdParser(TakeCmd cmd)
        {
            this.Command = cmd;
        }

        public void ParseAndExecute(string nameOrAlias, Arguments args = null)
        {
            var grammar = new GrammarParser(args);

            if (!grammar.HasSubject())
            {
                Output.WriteLine(string.Format(NO_SUBJECT, nameOrAlias));
                return;
            }

            var target = grammar.GetSubject();

            if (!grammar.HasAnyPreposition())
            {
                TakeFrom(target, new Noun("here"));
                return;
            }

            if (grammar.HasPrepositionAt(Preposition.FROM, 1) ||
                grammar.HasPrepositionAt(Preposition.OUT, 1))
            {
                var location = grammar.GetObjectOfPreposition(grammar.GetPreposition(1));

                if (location == null)
                {
                    Output.WriteLine(string.Format(TAKE_ITEM_FROM_WHERE, target));
                    return;
                }

                TakeFrom(target, location);
            }
        }

        private Item GetItemFromCurrentLocation(Noun itemNoun)
        {
            var currentLoc = this.Command.GameState.GetPlayerLocation();
            return currentLoc.Inventory.Items.FirstOrDefault(i => i.Name.ToLower() == itemNoun.Word.ToLower() &&
                                                                  i.Description.HasAdjectives(itemNoun.Adjectives));
        }

        private void TakeFrom(Noun target, Noun location)
        {
            var locationWord = location.Word;

            // Special case where the word "here" is used to define the current location
            if (locationWord == "here")
            {
                var targetItem = GetItemFromCurrentLocation(target);

                if (targetItem == null)
                {
                    Output.WriteNewLine(string.Format(NO_ITEM, target));
                    return;
                }

                if (!targetItem.IsTakeable)
                {
                    Output.WriteNewLine(string.Format(ITEM_NOT_TAKEABLE, targetItem));
                    return;
                }

                this.Command.TakeItemFromCurrentLocation(targetItem);

                Output.WriteNewLine(ITEM_TAKEN);
                return;
            }

            if (location.Word != "chest")
            {
                Output.WriteLine($"Cannot find a {location} here.");
                return;
            }
            else if (target.Word != "sword")
            {
                Output.WriteLine($"There is no {target} inside {location}.");
                return;
            }

            Output.WriteLine($"Taken.");
        }

    }
}
