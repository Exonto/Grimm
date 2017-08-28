using Grimm.Core.Commands.Prompts.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Prompts
{
    public class InputPrompt : Prompt<InputPrompt, InputPromptResult>
    {
        private ConfirmationPrompt ConfirmationPrompt { get; set; }
        private bool ConfirmationRequired
        {
            get
            {
                return this.ConfirmationPrompt != null;
            }
        }

        public override InputPromptResult GetResponse()
        {
            this.Decorate();

            var result = new InputPromptResult(Console.ReadLine());
            if (this.ConfirmationRequired)
            {
                RepeatUntilConfirmed(ref result);
            }

            return result;
        }

        public InputPrompt WithConfirmation(string header)
        {
            this.ConfirmationPrompt = new ConfirmationPrompt().WithMessage(header);

            return this;
        }

        public void RepeatUntilConfirmed(ref InputPromptResult result)
        {
            var confirmed = this.ConfirmationPrompt.GetResponse().Confirmed;
            if (!confirmed)
            {
                result = this.GetResponse();
            }
        }
    }
}
