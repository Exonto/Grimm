using Grimm.Game.GameWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions.Player
{
    public class PlayerMoveException : PlayerException
    {
        public PlayerMoveException(Location from, Location to) : base($"The player cannot move to {to} from {from}.")
        {
        }
    }
}
