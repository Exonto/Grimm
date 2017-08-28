using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Prompts.Results
{
    public class ConfirmationPromptResult : PromptResult
    {
        public bool Confirmed { get; set; }

        public ConfirmationPromptResult(string input) : base(input)
        {
        }
    }
}
