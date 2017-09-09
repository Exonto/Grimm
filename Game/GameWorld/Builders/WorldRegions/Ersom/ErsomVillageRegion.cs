using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Game.GameWorld;
using Grimm.Game.GameWorld.Items;
using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Builders.WorldRegions.Ersom
{
    public partial class ErsomVillageRegion : Region
    {
        public Location TreeHouse_TopFloor { get; set; }
        public Location TreeHouse_BottomFloor { get; set; }
        public Location TreeHouse_Base { get; set; }
        public Location PathToErsomFromTreehouse { get; set; }
        public ErsomVillageRegion()
            : base(Regions.ERSOM_VILLAGE, "Ersom Village")
        {
            Build();
        }

        protected override void Build()
        {
            this.TreeHouse_TopFloor = Build_TreehouseTopFloor()
                .WithPosition(0, 0, 2);

            this.TreeHouse_BottomFloor = Build_TreehouseBottomFloor()
                .WithPosition(this.TreeHouse_TopFloor.Pos, Direction.DOWN);

            this.TreeHouse_Base = Build_TreehouseBase()
                .WithPosition(this.TreeHouse_BottomFloor.Pos, Direction.DOWN);

            this.PathToErsomFromTreehouse = Build_PathToErsomFromTreehouse()
                .WithPosition(this.TreeHouse_Base.Pos, Direction.NORTH);

            this.AddLocation(this.TreeHouse_TopFloor);
            this.AddLocation(this.TreeHouse_BottomFloor);
            this.AddLocation(this.TreeHouse_Base);
            this.AddLocation(this.PathToErsomFromTreehouse);
        }
    }
}