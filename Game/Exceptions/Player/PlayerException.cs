using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions
{
    public class PlayerException : Exception
    {
        public PlayerException() : base()
        {
        }
        public PlayerException(string msg) : base(msg)
        {
        }
    }
}
