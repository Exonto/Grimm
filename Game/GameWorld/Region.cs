using Grimm.Game.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld
{
    public abstract class Region
    {
        private World _world;
        public World World
        {
            get { return _world; }
            set
            {
                if (!value.HasRegion(this))
                    throw new NoRegionException(this, value);
                _world = value;
                SubscribeToWorld(_world);
            }
        }

        public Guid Id { get; private set; }
        public String Name { get; private set; }
        private Grid3D Grid { get; set; } = new Grid3D();
        public Region(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        protected abstract void Build();

        private void SubscribeToWorld(World world)
        {
            this.Grid.ForEach(l => l.SubscribeToWorld(this.World));
        }

        public Location AddLocation(Location loc)
        {
            this.Grid.AddLocation(loc);
            loc.Region = this;

            return loc;
        }

        public Location GetLocationAt(Vector pos)
        {
            return this.Grid.GetLocationAt(pos);
        }
        public Location GetLocationAt(Location loc)
        {
            return this.Grid.GetLocationAt(loc.Pos);
        }

        public bool HasLocation(Location loc)
        {
            return this.Grid.HasLocationAt(loc.Pos);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
