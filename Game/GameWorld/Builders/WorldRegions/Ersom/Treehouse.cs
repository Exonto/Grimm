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
        public Location Build_TreehouseTopFloor()
        {
            var bed = new Item("Bed")
                .WithAdjective(Adjective.MY)
                .WithAdjective(Adjective.WOODEN)
                .WithAdjective(Adjective.SMALL)

                .AsTakeable(true)

                .WithDescriptionLine("This is your comfy, although somewhat small, wooden bed.")
                ;
            bed.ItemStrings.ITEM_TAKEN.RemoveResponses();
            bed.ItemStrings.ITEM_TAKEN
                .WithResponse("With great effort, you slowly haul one side of the bed up to your shoulders with the other end dragging behind you.");

            var apple = new Item("Apple")
                .WithAdjective(Adjective.Colors.RED)
                .WithAdjective(Adjective.FRESH)
                .AsTakeable(true)

                .WithDescriptionLine("A shiny red apple.")
                ;

            var notebook = new Item("Notebook")
                .WithAlias("Journal")
                .WithDescriptionLine("This leather backed book has been your journal for many years.")
                .WithAdjective(Adjective.MY)
                .WithAdjective(Adjective.LEATHER)

                .AsTakeable(true)
                ;

            var chest = new Item("Chest")
                .WithAdjective(Adjective.MY)
                .AsTakeable(true)
                .AsContainer(true)
                    .AddItem(apple)
                    .AddItem(notebook)
                ;

            var ladder = new Item("Ladder")
                ;

            var loc = new Location()
                .AddItem(bed)
                .AddItem(chest)
                .AddItem(ladder)

                .WithDescription(new LocationDescription()
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

        public Location Build_TreehouseBottomFloor()
        {
            var chair = new Item("Chair")
                .WithAdjective(Adjective.WOODEN)

                .WithDescriptionLine("This handcrafted wooden chair was built by Samuel quite some time ago.")
                ;


            var loc = new Location()
                .AddItem(chair)

                .WithDescription(new LocationDescription()
                    .WithLine("You are on the lower floor of your treehouse.")
                    .WithLine("Going straight through the center of the house is the trunk of the oak tree.")
                    .WithLine("There are a couple windows along wall which circles the trunk.")

                    .WithItem(chair)
                    .WithItemDescriptionLine("To the side of one of the windows is a chair which has sat, mostly unused since you received it.")
                    .BuildItemDescription()
                );

            return loc;
        }
    }
}
