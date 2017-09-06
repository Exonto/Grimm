using Grimm.Game.GameWorld;
using Grimm.Game.GameWorld.Builders.WorldRegions.Ersom;
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

            var ersomVillage = new ErsomVillageRegion();

            regions.Add(ersomVillage);

            return regions;
        }
    }
}
