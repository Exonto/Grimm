using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Exceptions
{
    public class CommandDoesNotExistException : Exception
    {
        public CommandDoesNotExistException(string attemptedCmdName) 
            : base("A command named " + attemptedCmdName + " does not exist.")
        {
        }
    }
}
