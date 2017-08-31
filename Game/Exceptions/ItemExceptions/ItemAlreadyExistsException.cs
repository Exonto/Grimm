using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.Exceptions.ItemExceptions
{
    public class ItemAlreadyExistsException : ItemException
    {
        public ItemAlreadyExistsException(Item item, Inventory inventory) 
            : base($"The item {item} is already contained within the inventory {inventory}.")
        {
        }
    }
}
