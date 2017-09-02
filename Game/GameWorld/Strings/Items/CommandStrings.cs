using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Strings.Items
{
    public class CommandStrings
    {
        public static readonly RandomResponse NO_UNDERSTAND_TAKE = new RandomResponse()
            .WithResponse("Are you trying to take the {0} from somewhere?")
            ;

        public static readonly RandomResponse NO_UNDERSTAND_INSPECT = new RandomResponse()
            .WithResponse("What are you trying to inspect?")
            ;
    }
}
