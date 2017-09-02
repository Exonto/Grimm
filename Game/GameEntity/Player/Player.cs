using Grimm.Core;
using Grimm.Game.Exceptions;
using Grimm.Game.Exceptions.Player;
using Grimm.Game.GameEntity;
using Grimm.Game.GameWorld;
using Grimm.Game.GameWorld.Items;
using Grimm.Game.GameWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game
{
    public class Player : Entity
    {
        public string Name { get; private set; }
        public Location Location { get; set; }
        public Region Region { get { return this.Location.Region; } }
        public World World { get { return this.Region.World; } }

        private IOutputService _outputService;
        private Player(IOutputService outputService)
        {
            _outputService = outputService;
        }
        public Player(string name)
            : this(new OutputService())
        {
            this.Name = name;
        }

        public bool CanMove(Direction dir)
        {
            var adjacent = this.Location.GetAdjacent(dir);

            return CanMove(adjacent);
        }
        public bool CanMove(Location loc)
        {
            if (loc == null)
                return false;

            if (!loc.IsAdjacent(this.Location))
                return false;

            return true;
        }

        public void Move(Direction dir)
        {
            Move(this.Location.GetAdjacent(dir));
        }

        public void Move(Location loc)
        {
            if (!CanMove(loc))
                throw new PlayerMoveException(this.Location, loc);

            this.World.SetPlayerLocation(loc);
        }

        public void TakeItem(Item item)
        {
            item.TakeFromLocation(this.Location, this.Inventory);
        }

        public void TakeItemFromContainer(Item target, Item container)
        {
            target.TakeFromContainer(container, this.Inventory);
        }

        public void InspectItem(Item target)
        {
            target.Inspect();
        }

        public void InspectItemInContainer(Item target, Item container)
        {
            target.InspectInContainer(container);
        }

        public void OpenInventory()
        {
            Output.WriteLine("Items in Your Inventory");
            _outputService.OutputInventory(this.Inventory);
        }

        public void LookInsideContainer(Item container)
        {
            Output.WriteLine($"Inventory of the {container}");
            container.LookInside();
        }
    }
}
