using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimm.Core.Commands;

namespace Grimm.Game
{
    public class CommandLine : ICommandLine
    {
        private bool Listen { get; set; }
        public CommandDirectory CommandDirectory { get; set; } = new CommandDirectory();

        public CommandLine()
        {
        }

        public void StartListening()
        {
            this.Listen = true;

            while (this.Listen)
            {
                var input = AwaitInput();

                ProcessRawInput(input);
            }
        }

        public void StopListening()
        {
            this.Listen = false;
        }

        public string AwaitInput()
        {
            return Console.ReadLine();
        }

        public void ProcessRawInput(string rawInput)
        {
            if (rawInput == String.Empty)
                return;

            var cmdName = GetCmdNameFromInput(rawInput);
            var args = new Arguments(GetCmdArgsFromInput(rawInput));

            if (this.CommandDirectory.Exists(cmdName))
            {
                this.CommandDirectory.ExecuteCommand(cmdName, args);
            }
        }

        private string GetCmdNameFromInput(string rawInput)
        {
            return rawInput.Split(' ')[0];
        }

        private List<string> GetCmdArgsFromInput(string rawInput)
        {
            var splitInput = rawInput.Split(' ');

            if (splitInput.Length <= 1)
                return new List<string>();

            var cmdArgs = splitInput.ToList();
            cmdArgs.RemoveAt(0);

            return cmdArgs;
        }
    }
}
