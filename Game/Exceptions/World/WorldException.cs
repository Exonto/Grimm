using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions
{
    public class WorldException : Exception
    {
        public WorldException() : base()
        {
        }

        public WorldException(string msg) : base(msg)
        {
        }
    }
}
