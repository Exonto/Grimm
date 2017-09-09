using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Builders.WorldRegions.Ersom
{
    public partial class ErsomVillageRegion
    {
        public Location Build_PathToErsomFromTreehouse()
        {
            var loc = new Location()
                .WithDescription(new LocationDescription()
                    .WithLine("On either side of you is the thick forest, where huge oak trees span for miles in every direction.")
                    .WithLine("Ahead of you, further down the side of the hill you're overlooking, you can see Ersom.")
                );

            return loc;
        }
    }
}
