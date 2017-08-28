using Grimm.Core.Commands.Prompts.Results;
using Grimm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Prompts
{
    public class ConfirmationPrompt : Prompt<ConfirmationPrompt, ConfirmationPromptResult>
    {
        private const string INVALID_INPUT_MSG = "You must type either \"Yes\" or \"No\"";

        public override ConfirmationPromptResult GetResponse()
        {
            try
            {
                this.Decorate();
                var result = new ConfirmationPromptResult(Console.ReadLine());
                var input = result.Input;

                result.Confirmed = WasConfirmed(input);

                return result;
            }
            catch (ExpectedPromptInputException)
            {
                Console.WriteLine();
                Console.WriteLine(INVALID_INPUT_MSG);

                return GetResponse();
            }
        }

        private bool WasConfirmed(string input)
        {
            input = input.ToLower();

            if (input == "yes" ||
                input == "yea" ||
                input == "true" ||
                input == "confirm" ||
                input == "okay" ||
                input == "of course" ||
                input == "affirmative" ||
                input == "certainly")
            {
                return true;
            }
            else if (input == "no" ||
                     input == "never" ||
                     input == "false" ||
                     input == "deny" ||
                     input == "negative" ||
                     input == "negatory" ||
                     input == "no way" ||
                     input == "forget it" ||
                     input == "impossible")
            {
                return false;
            }

            throw new ExpectedPromptInputException();
        }
    }
}
