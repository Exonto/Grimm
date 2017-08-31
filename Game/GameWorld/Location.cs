using Grimm.Core;
using Grimm.Game.Exceptions;
using Grimm.Game.GameWorld.Events;
using Grimm.Game.GameWorld.Items;
using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld
{
    public class Location : IDescribable<LocationDescription>
    {
        #region Basics

        private Region _region;
        public Region Region
        {
            get { return _region; }
            set
            {
                // The location's region must have this location within itself
                if (!value.HasLocation(this))
                    throw new NoLocationException(this, _region);
                _region = value;
            }
        }
        public Vector Pos { get; private set; }
        public int X { get { return (int) this.Pos.X; } }
        public int Y { get { return (int) this.Pos.Y; } }
        public int Z { get { return (int) this.Pos.Z; } }

        public LocationDescription Description { get; private set; } = new LocationDescription();
        public Inventory Inventory { get; private set; } = new Inventory();

        public Location(int x, int y, int z, Region region)
        {
            this.Pos = new Vector(x, y, z);
            this.Region = region;
        }
        public Location(int x, int y, int z)
        {
            this.Pos = new Vector(x, y, z);
        }
        public Location(Vector pos)
        {
            this.Pos = pos;
        }
        public Location(Vector pos, Region region)
        {
            this.Pos = pos;
            this.Region = region;
        }

        public void SubscribeToWorld(World world)
        {
            world.PlayerLocationChanged -= OnPlayerLocationChanged;
            world.PlayerLocationChanged += OnPlayerLocationChanged;
        }

        public Location GetAdjacent(Direction dir)
        {
            if (!HasRegion())
                throw new NoRegionException(this);

            return this.Region.GetLocationAt(this.Pos.InDirection(dir));
        }

        public bool HasAdjacent(Direction dir)
        {
            return GetAdjacent(dir) != null;
        }

        public bool IsAdjacent(Location loc)
        {
            foreach (var dir in Direction.GetAll())
            {
                if (loc.Pos.InDirection(dir).IsEqualTo(this.Pos))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasRegion()
        {
            return this.Region != null;
        }

        public override string ToString()
        {
            return $"{this.Pos} : " + (Region != null ? Region.ToString() : "No Region");
        }

        #endregion

        public void OnPlayerLocationChanged(object source, PlayerLocationChangedEventArgs args)
        {
            if (args.To != this)
                return;

            WriteDescription(this.Description);
        }

        public void WriteDescription(LocationDescription description)
        {
            description.Lines.ForEach(l => Output.WriteLine(l));
            Output.WriteLine();

            var items = description.ItemDescriptions.Keys;
            foreach (var item in items)
            {
                if (!HasItem(item))
                    continue;

                var itemDescription = description.ItemDescriptions[item];
                itemDescription.ForEach(l => Output.WriteLine(l));
            }
        }

        public Location WithDescription(LocationDescription description)
        {
            this.Description = description;

            return this;
        }

        public Location AddItem(Item item)
        {
            this.Inventory.AddItem(item);

            return this;
        }

        public Location RemoveItem(Item item)
        {
            this.Inventory.RemoveItem(item);

            return this;
        }

        public bool HasItem(Item item)
        {
            return this.Inventory.HasItem(item);
        }
    }
}