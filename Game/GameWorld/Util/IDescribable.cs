using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Util
{
    public interface IDescribable<T> where T : Description
    {
        T Description { get; }
    }
}
