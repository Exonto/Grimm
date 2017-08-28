using Grimm.Game.GameWorld;
using Grimm.Game.GameWorld.Items;
using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Builders.WorldRegions
{
    public partial class RegionBuilder
    {
        private ErsomVillageRegion BuildErsom()
        {
            var region = new ErsomVillageRegion();

            region.TreeHouse_TopFloor = Build_TreeHouseTopFloor();

            region.TreeHouse_BottomFloor = new Location(0, 0, 1)
                .WithDescription(new Description()
                    .WithLine("You are on the ground floor of your treehouse."));

            region.TreeHouse_Base = new Location(0, 0, 0);

            region.AddLocation(region.TreeHouse_TopFloor);
            region.AddLocation(region.TreeHouse_BottomFloor);
            region.AddLocation(region.TreeHouse_Base);

            return region;
        }

        private Location Build_TreeHouseTopFloor()
        {
            var bed = new Item("Bed")
                .WithAdjective("my")
                .WithAdjective("wooden")
                .WithAdjective("small")
                ;
            var chest = new Item("Chest");
            var ladder = new Item("Ladder");
            var loc = new Location(0, 0, 2)
                .AddItem(bed)
                .AddItem(chest)
                .AddItem(ladder)

                .WithDescription(new Description()
                    .WithLine("You are on the upper loft of your treehouse.")
                    .WithLine("You use this small space as your bedroom.")

                    .WithItem(chest)
                    .WithItemDescriptionLine("There is a chest directly in front of the single, circular window ")
                    .WithItemDescriptionLine("which overlooks the dirt path leading to Ersom.")
                    .BuildItemDescription()
                    
                    .WithItem(bed)
                    .WithItemDescriptionLine("Your wooden bed sits in the corner.")
                    .BuildItemDescription()

                    .WithItem(ladder)
                    .WithItemDescriptionLine("Towards the opposite corner of your bed, there is a ladder leading to the floor below")
                    .BuildItemDescription()
                );

            return loc;
        }
    }

    public class ErsomVillageRegion : Region
    {
        public Location TreeHouse_TopFloor { get; set; }
        public Location TreeHouse_BottomFloor { get; set; }
        public Location TreeHouse_Base { get; set; }
        public ErsomVillageRegion() : base(Regions.ERSOM_VILLAGE, "Ersom Village")
        {
        }
    }
}
