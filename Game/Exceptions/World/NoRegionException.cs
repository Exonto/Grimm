using Grimm.Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions
{
    public class NoRegionException : Exception
    {
        public NoRegionException(Location loc) : base($"The location {loc} does not have a region.")
        {
        }
        public NoRegionException(string msg) : base(msg)
        {
        }
        public NoRegionException(Region attempted, World world) : base($"The region \"{attempted.Name}\" does not exist in the world \"{world.Name}\"")
        {
        }
    }
}
