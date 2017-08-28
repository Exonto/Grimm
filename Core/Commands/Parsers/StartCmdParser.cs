using Grimm.Core.Commands.Prompts;
using Grimm.Core.Commands.Prompts.Results;
using Grimm.Core.Commands.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class StartCmdParser : ICommandParser<StartCmd>
    {
        public StartCmd Command { get; }

        public StartCmdParser(StartCmd cmd)
        {
            this.Command = cmd;
        }

        public void ParseAndExecute(string alias, Arguments args = null)
        {
            this.Command.ShowInto();

            var name = this.Command.PromptForName();

            Output
                .SayLine("It is nice to meet you " + name).Pause(300)
                .Say("It is time").SayLine("...", 300);
        }
    }
}
