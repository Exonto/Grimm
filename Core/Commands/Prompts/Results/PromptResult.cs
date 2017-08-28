using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Prompts
{
    public abstract class PromptResult
    {
        public string Input { get; }

        public PromptResult(string input)
        {
            this.Input = input;
        }
    }
}
