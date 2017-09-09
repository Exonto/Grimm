using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Strings.Items
{
    public class ItemStrings
    {
        public static readonly RandomResponse WHAT_ITEM = new RandomResponse()
            .WithResponse("What do you want to {0}?")
            ;

        public static readonly RandomResponse ITEM_CANNOT_BE_TAKEN = new RandomResponse()
            .WithResponse("The {0} cannot be taken.")
            .WithResponse("You cannot take the {0}.")
            .WithResponse("You cannot take this.")
            ;

        public static readonly RandomResponse ITEM_CANNOT_BE_DROPPED = new RandomResponse()
            .WithResponse("You really need to keep this in your inventory.")
            ;

        public static readonly RandomResponse ITEM_DOES_NOT_EXIST = new RandomResponse()
            .WithResponse("There is no {0} here.")
            ;

        public static readonly RandomResponse ITEM_NOT_IN_PLAYER_INVENTORY = new RandomResponse()
            .WithResponse("There is no {0} in your inventory.")
            .WithResponse("You don't have that.")
            ;

        public static readonly RandomResponse ITEM_NOT_IN_CONTAINER = new RandomResponse()
            .WithResponse("There is no {0} inside the {1}.")
            .WithResponse("That is not inside the {1}.")
            ;

        public static readonly RandomResponse TAKE_FROM_WHERE = new RandomResponse()
            .WithResponse("Take {0} from where?")
            .WithResponse("From where do you want to take the {0}?")
            ;

        public static readonly RandomResponse ITEM_NOT_CONTAINER = new RandomResponse()
            .WithResponse("The {0} is not a container.")
            .WithResponse("The {0} cannot hold anything.")
            ;

        public static readonly RandomResponse CONTAINER_HAS_NO_TAKEABLE_ITEMS = new RandomResponse()
            .WithResponse("There are no items in the {0} that can be taken.")
            ;

        public static readonly RandomResponse LOCATION_HAS_NO_TAKEABLE_ITEMS = new RandomResponse()
            .WithResponse("There are no items that can be taken.")
            ;

        public static readonly RandomResponse ITEM_HAS_NO_DESCRIPTION = new RandomResponse()
            .WithResponse("The {0} is quite boring.")
            .WithResponse("The {0} is uninteresting.")
            .WithResponse("There isn't much to say about this.")
            ;

        public static readonly RandomResponse INSPECT_FROM_WHERE = new RandomResponse()
            .WithResponse("Inspect {0} from where?")
            .WithResponse("From where do you want to inspect a {0}?")
            ;

        public static readonly RandomResponse LOOK_INSIDE_WHAT = new RandomResponse()
            .WithResponse("What do you want to look inside of?")
            ;

        public RandomResponse ITEM_TAKEN { get; private set; } = new RandomResponse()
            .WithResponse("Taken.")
            ;

        public RandomResponse ITEM_TAKEN_VERBOSE { get; private set; } = new RandomResponse()
            .WithResponse("You took the {0}.")
            ;

        public RandomResponse ITEM_TAKEN_FROM_VERBOSE { get; private set; } = new RandomResponse()
            .WithResponse("You took the {0} from the {1}.")
            ;

        public RandomResponse ITEM_DROPPED { get; private set; } = new RandomResponse()
            .WithResponse("Dropped.")
            ;
    }
}
