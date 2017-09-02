using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Services
{
    public interface IDescriptionService
    {
        void OutputDescription<T>(DescriptionBase<T> description) where T : DescriptionBase<T>;

        void OutputItemDescriptions(Location loc);
        void OutputLocationDescription(Location loc);
    }
}
