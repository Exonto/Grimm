using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions.ItemExceptions
{
    public class ItemDoesNotExistException : ItemException
    {
        public ItemDoesNotExistException(Item item, Inventory inventory) 
            : base($"The item {item} does not exist in the inventory {inventory}.")
        {
        }
    }
}
