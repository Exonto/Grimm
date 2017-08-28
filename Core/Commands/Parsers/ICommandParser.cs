using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public interface ICommandParser<out T> where T : Command
    {
        T Command { get; }

        void ParseAndExecute(string alias, Arguments args = null);
    }
}
