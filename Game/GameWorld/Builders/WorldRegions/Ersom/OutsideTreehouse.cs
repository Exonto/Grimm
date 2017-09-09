using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Game.GameWorld.Items;
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
        public Location Build_TreehouseBase()
        {
            var crops = new Item("Crops")
                .WithAlias("Corn")
                .WithAdjective(Adjective.MY)

                .WithDescriptionLine("This is your corn crop.")
                .WithDescriptionLine("You've maintained this little, garden sized section of land since you moved here.")
                .WithDescriptionLine("It's only large enough to provide the occasional meal for yourself.")
                ;

            var scarecrow = new Item("Scarecrow")
                .WithAlias("Dummy")
                .WithAdjective(Adjective.MY)

                .WithDescriptionLine("This thing is supposed to keep the crows away.")
                .WithDescriptionLine("The problem is that this also doubles as your practice dummy, and is so beat up that it hardly resembles a human being anymore.")
                .WithDescriptionLine("Not that it ever did.")
                ;

            var ladder = new Item("Ladder")
                .WithDescriptionLine("This leads up to your house.")
                ;

            var loc = new Location()
                .AddItem(crops)
                .AddItem(scarecrow)
                .AddItem(ladder)

                .WithDescription(new LocationDescription()
                    .WithLine("You are in a small clearing which spans out in front of your house in the trees.")
                    .WithLine("Ahead of you, to the north, is the dirt path which leads to your hometown of Ersom.")
                    .WithLine("You can see your circular treehouse wrapped around the tree.")

                    .WithItem(crops)
                    .WithItemDescriptionLine("To your right, near the treeline, is the corn crop you've been harvesting for the past few years now.")
                    .BuildItemDescription()
                );

            return loc;
        }
    }
}
