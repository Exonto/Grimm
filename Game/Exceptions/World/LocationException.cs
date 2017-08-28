using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions
{
    public class LocationException : Exception
    {
        public LocationException() : base()
        {
        }

        public LocationException(string msg) : base(msg)
        {
        }
    }
}
