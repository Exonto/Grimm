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
            this.Items.Remove(item);
        }

        public bool HasItem(Item item)
        {
            return this.Items.Contains(item);
        }
    }
}
