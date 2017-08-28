using Grimm.Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Builders.WorldRegions
{
    public partial class RegionBuilder
    {
        public List<Region> BuildWorldRegions()
        {
            var regions = new List<Region>();

            regions.Add(BuildErsom());

            return regions;
        }
    }
}
