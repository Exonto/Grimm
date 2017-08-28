using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Util
{
    public class OffsetList<T> : List<T>
    {
        public int Offset { get; set; }

        public bool WillUpdateOffset(int num)
        {
            return Math.Abs(num) > this.Offset;
        }

        public int AttemptUpdateOffset(int num)
        {
            var willIncrease = WillUpdateOffset(num);
            if (willIncrease)
                Offset = Math.Abs(num);

            return this.Offset;
        }
    }
}
