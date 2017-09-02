using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Services
{
    public interface IOutputService
    {
        void OutputList<T>(List<T> list);
        void OutputInventory(Inventory inventory);
    }
}
