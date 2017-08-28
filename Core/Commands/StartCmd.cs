using Grimm.Core.Commands.Parsers;
using Grimm.Core.Commands.Prompts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public class StartCmd : Command
    {
        public StartCmd() 
            : base("start", new string[] { "begin" })
        {
            base._parser = new StartCmdParser(this);
        }

        public override void Execute(string alias, Arguments args = null)
        {
            base._parser.ParseAndExecute(alias, args);
        }

        public void ShowInto()
        {
            Output
                .Say("...", 350).Pause(400)
                .Say("Welcome ", 150).Pause(150).SayLine("young one").Pause(500)
                .SayLine("You will soon be entering this brave, new world").Pause(200)
                .SayLine("And it is time for you to choose the name by which you will be known");
        }

        public string PromptForName()
        {
            return new InputPrompt()
                .WithMessage("What name do you choose?")
                .WithConfirmation("This name will remain with you all of your days. Are you sure?")
                .GetResponse()
                .Input;
        }
    }
}
