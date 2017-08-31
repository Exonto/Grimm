using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Game.Exceptions.ItemExceptions;
using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Items
{
    public class Item : IDescribable<Description>
    {
        public string Name { get; set; }
        public List<string> Aliases { get; private set; } = new List<string>();
        public Description Description { get; set; } = new Description();

        public bool IsTakeable { get; set; } = false;
        public Item(string name)
        {
            this.Name = name;
        }

        public Item WithAdjective(Adjective adjective)
        {
            this.Description.WithAdjective(adjective);

            return this;
        }

        public bool IsNameOrAlias(string word)
        {
            return this.Name.ToLower() == word ||
                   this.Aliases.Contains(word);
        }

        public Item WithAlias(string alias)
        {
            this.Aliases.Add(alias);

            return this;
        }

        public Item AsTakeable(bool isTakeable)
        {
            this.IsTakeable = isTakeable;

            return this;
        }

        public void TakeFromLocation(Location loc, Inventory inventory)
        {
            if (!this.IsTakeable)
                throw new ItemException($"The item {this} cannot be taken.");

            loc.RemoveItem(this);

            inventory.AddItem(this);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
