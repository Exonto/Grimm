using Grimm.Game.Exceptions.ItemExceptions;
using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game
{
    public class Inventory
    {
        public List<Item> Items { get; private set; } = new List<Item>();

        public void AddItem(Item item)
        {
            this.Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            var didExist = this.Items.Remove(item);

            if (!didExist)
                throw new ItemDoesNotExistException(item, this);
        }

        public bool HasItem(Item item)
        {
            return this.Items.Contains(item);
        }
    }
}
