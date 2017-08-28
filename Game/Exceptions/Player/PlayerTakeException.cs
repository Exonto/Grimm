using Grimm.Game.GameWorld;
using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions.Player
{
    public class PlayerTakeException : PlayerException
    {
        public PlayerTakeException(Item item, Location from) : base($"The item \"{item}\" does not exist in location \"{from}\".")
        {
        }
    }
}
