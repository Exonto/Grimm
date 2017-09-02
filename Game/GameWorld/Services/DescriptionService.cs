using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimm.Game.GameWorld.Util;
using Grimm.Core;

namespace Grimm.Game.GameWorld.Services
{
    public class DescriptionService : IDescriptionService
    {
        public void OutputDescription<T>(DescriptionBase<T> description) where T : DescriptionBase<T>
        {
            description.Lines.ForEach(l => Output.WriteLine(l));
            Output.WriteLine();
        }

        public void OutputItemDescriptions(Location loc)
        {
            var description = loc.Description;
            var items = description.ItemDescriptions.Keys;
            foreach (var item in items)
            {
                if (!loc.HasItem(item))
                    continue;

                var itemDescription = description.ItemDescriptions[item];
                itemDescription.Lines.ForEach(l => Output.WriteLine(l));
            }
        }

        public void OutputLocationDescription(Location loc)
        {
            OutputDescription(loc.Description);
            OutputItemDescriptions(loc);
            Output.WriteLine();
        }
    }
}
