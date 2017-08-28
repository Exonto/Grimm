using Grimm.Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions
{
    public class NoLocationException : LocationException
    {
        public NoLocationException(Location attempted, Region region) : base($"The location {attempted} does not exist in the region {region}.")
        {
        }
        public NoLocationException(Vector attempted, Region region) : base($"No location exists at {attempted} for the region {region}.")
        {
        }
        public NoLocationException(Vector attempted) : base($"No location exists at {attempted}.")
        {
        }
    }
}
