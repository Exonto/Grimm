using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Events
{
    public class PlayerLocationChangedEventArgs : EventArgs
    {
        public Player Player { get; private set; }
        public Location From { get; private set; }
        public Location To { get; private set; }
        public PlayerLocationChangedEventArgs(Player player, Location from, Location to)
        {
            this.Player = player;
            this.From = from;
            this.To = to;
        }
    }
}
