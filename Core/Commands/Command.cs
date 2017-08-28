using Grimm.Core.Commands.Parsers;
using Grimm.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public abstract class Command
    {
        protected ICommandParser<Command> _parser;

        public string Name { get; private set; }
        public List<string> Aliases { get; private set; }
        public GameState GameState { get; protected set; }

        public Command(string name)
        {
            this.Name = name;
        }

        public Command(string name, List<string> aliases) : this(name)
        {
            this.Aliases = aliases;
        }

        public Command(string name, string[] aliases) : this(name)
        {
            this.Aliases = aliases.ToList();
        }

        public abstract void Execute(string alias, Arguments args = null);
    }
}
