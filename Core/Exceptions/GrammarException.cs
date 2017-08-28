using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Exceptions
{
    public class GrammarException : Exception
    {
        public GrammarException(string message) : base(message)
        {
        }
    }
}
