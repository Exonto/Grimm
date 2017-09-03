using Grimm.Core;
using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Game.Exceptions.ItemExceptions;
using Grimm.Game.GameWorld.Services;
using Grimm.Game.GameWorld.Strings.Items;
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
        public ItemStrings ItemStrings { get; set; } = new ItemStrings();

        public Inventory Inventory { get; private set; } = new Inventory();

        public bool IsTakeable { get; set; } = false;
        public bool IsDroppable { get; set; } = true;
        public bool IsContainer { get; set; } = false;

        private IDescriptionService _descriptionService;
        private IOutputService _outputService;
        private Item(
            IDescriptionService descriptionService,
            IOutputService outputService)
        {
            _descriptionService = descriptionService;
            _outputService = outputService;
        }
        public Item(string name)
            : this(new DescriptionService(),
                   new OutputService())
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

        public Item WithDescriptionLine(string line)
        {
            this.Description.WithLine(line);

            return this;
        }

        public Item AsTakeable(bool isTakeable)
        {
            this.IsTakeable = isTakeable;

            return this;
        }

        public Item AsDroppable(bool isDroppable)
        {
            this.IsDroppable = isDroppable;

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

        public void RemoveFromInventory(Inventory inventory, Location loc)
        {
            if (!this.IsDroppable)
                throw new ItemException($"The item {this} cannot be dropped.");

            inventory.RemoveItem(this);

            loc.AddItem(this);
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

        public void Inspect()
        {
            if (this.Description.Lines.Count == 0)
            {
                ItemStrings.ITEM_HAS_NO_DESCRIPTION.OutputResponse(this.Name, "amazing");
                return;
            }

            _descriptionService.OutputDescription(this.Description);
        }

        public void InspectInContainer(Item container)
        {
            if (!container.IsContainer)
                throw new ItemException($"The item {container} is not a container.");

            if (!container.HasItem(this))
                throw new ItemDoesNotExistException(this, container.Inventory);

            Inspect();
        }

        public void LookInside()
        {
            if (!this.IsContainer)
                throw new ItemException($"The item {this} is not a container.");

            _outputService.OutputInventory(this.Inventory);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
