using Grimm.Core.Commands.Results;
using Grimm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public class CommandDirectory
    {
        private List<Command> Directory { get; } = GetAllCommands();

        public void ExecuteCommand(string cmdName, Arguments args)
        {
            if (!Exists(cmdName))
                throw new CommandDoesNotExistException(cmdName);

            var cmd = GetCommand(cmdName);

            args.Args.ForEach(a => a = a.ToLower());
            cmd.Execute(cmdName.ToLower(), args);
        }

        public bool Exists(string cmdName)
        {
            return this.Directory.Exists(c => c.Name.ToLower() == cmdName.ToLower()) || IsAlias(cmdName);
        }

        public bool IsAlias(string cmdName)
        {
            return this.Directory.Exists(c => c.Aliases.Any(a => a.ToLower() == cmdName));
        }

        private Command GetCommand(string cmdName)
        {
            var cmd = this.Directory.FirstOrDefault(c => c.Name.ToLower() == cmdName.ToLower());
            if (cmd == null)
                cmd = this.Directory.First(c => c.Aliases.Any(a => a == cmdName));

            return cmd;
        }

        private static List<Command> GetAllCommands()
        {
            var commands = new List<Command>();
            var gameState = Program.GameState;

            commands.Add(new StartCmd());
            commands.Add(new MoveCmd(gameState));
            commands.Add(new TakeCmd(gameState));

            return commands;
        }
    }
}
