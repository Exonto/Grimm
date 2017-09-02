using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Util
{
    public class LocationDescription : DescriptionBase<LocationDescription>, IItemDescription
    {
        public Dictionary<Item, Description> ItemDescriptions = new Dictionary<Item, Description>();
        private Item ItemBeingBuilt;

        public LocationDescription WithItem(Item item)
        {
            this.ItemBeingBuilt = item;
            this.ItemDescriptions.Add(item, new Description());

            return this;
        }

        /// <summary>
        /// A location may describe the items that are within it to provide
        /// a more interesting picture.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public IItemDescription WithItemDescriptionLine(string line)
        {
            this.ItemDescriptions[this.ItemBeingBuilt].WithLine(line);

            return this;
        }

        public LocationDescription BuildItemDescription()
        {
            return this;
        }
    }
}
