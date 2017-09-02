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
        public static readonly RandomResponse ITEM_HAS_NO_DESCRIPTION = new RandomResponse()
            .WithResponse("There is nothing particularly interesting about the {0}.")
            .WithResponse("The {0} is uninteresting.")
            .WithResponse("There isn't much to say about this.")
            ;

        public static readonly RandomResponse ITEM_CANNOT_BE_TAKEN = new RandomResponse()
            .WithResponse("The {0} cannot be taken.")
            .WithResponse("You cannot take the {0}.")
            .WithResponse("You cannot take this.")
            ;
    }
}
