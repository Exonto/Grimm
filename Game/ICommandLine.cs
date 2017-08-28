using Grimm.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game
{
    public interface ICommandLine
    {
        CommandDirectory CommandDirectory { get; set; }

        void ProcessRawInput(string rawInput);
    }
}
