using Grimm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Services
{
    public class OutputService : IOutputService
    {
        public void OutputList<T>(List<T> list)
        {
            list.ForEach(e => Output.WriteLine(e.ToString()));
        }

        public void OutputInventory(Inventory inventory)
        {
            var itemsSorted = inventory.Items
                .OrderBy(i => i.Name)
                .ToList();

            Output.WriteLine("---------------------------------");

            if (itemsSorted.Count == 0)
                Output.WriteLine("  No Items  ");
            else
                OutputList(itemsSorted);

            Output.WriteLine("---------------------------------");
            Output.WriteLine();
        }
    }
}
