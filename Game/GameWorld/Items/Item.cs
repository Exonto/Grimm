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
        public Inventory Inventory { get; private set; } = new Inventory();

        public bool IsTakeable { get; set; } = false;
        public bool IsContainer { get; set; } = false;
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

        public Item AsContainer(bool isContainer)
        {
            this.IsContainer = isContainer;

            return this;
        }

        public void TakeFromLocation(Location loc, Inventory putIn)
        {
            if (!this.IsTakeable)
                throw new ItemException($"The item {this} cannot be taken.");

            loc.RemoveItem(this);

            putIn.AddItem(this);
        }

        public void TakeFromContainer(Item container, Inventory putIn)
        {
            if (!this.IsTakeable)
                throw new ItemException($"The item {this} cannot be taken.");

            container.RemoveItem(this);

            putIn.AddItem(this);
        }

        public Item AddItem(Item item)
        {
            if (!this.IsContainer)
                throw new ItemException($"The item {this} is not a container.");

            this.Inventory.AddItem(item);
            return this;
        }

        public void RemoveItem(Item item)
        {
            if (!this.IsContainer)
                throw new ItemException($"The item {this} is not a container.");

            this.Inventory.RemoveItem(item);
        }

        public bool HasItem(Item item)
        {
            if (!this.IsContainer)
                throw new ItemException($"The item {this} is not a container.");

            return this.Inventory.HasItem(item);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
