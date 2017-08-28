using Grimm.Game.Exceptions;
using Grimm.Game.GameWorld.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld
{
    public class World
    {
        public string Name { get; private set; }
        public Player Player { get; private set; }

        private List<Region> Regions { get; set; } = new List<Region>();

        // Represents the region which the player is currently located in
        private Region ActiveRegion { get; set; }

        public delegate void PlayerLocationChangedEventHandler(object source, PlayerLocationChangedEventArgs args);
        public event PlayerLocationChangedEventHandler PlayerLocationChanged;

        public World(string name)
        {
            this.Name = name;
        }

        public void SpawnPlayer(Player player, Region region, Vector pos)
        {
            var loc = region.GetLocationAt(pos);
            if (loc == null)
                throw new NoLocationException(pos);

            if (!loc.HasRegion())
                throw new LocationHasNoRegionException();

            this.Player = player;
            SetPlayerLocation(loc);
        }

        public void SetPlayerLocation(Location loc)
        {
            if (!loc.HasRegion())
                throw new LocationHasNoRegionException();

            OnPlayerLocationChanged(this.Player, this.Player.Location, loc);

            this.Player.Location = loc;
            UpdateActiveRegion();
        }
        public void SetPlayerPosition(Vector pos)
        {
            if (!PlayerSpawned())
                throw new PlayerException("The player has not been spawned in.");

            SetPlayerLocation(this.ActiveRegion.GetLocationAt(pos));
        }

        public bool PlayerSpawned()
        {
            return this.Player != null;
        }

        public Region AddRegion(Region region)
        {
            this.Regions.Add(region);
            region.World = this;

            return region;
        }

        public bool HasRegion(Region region)
        {
            return this.Regions.Contains(region);
        }

        public Region GetRegionByName(string name)
        {
            return this.Regions.FirstOrDefault(r => r.Name == name);
        }
        
        public Region GetRegionById(Guid id)
        {
            return this.Regions.FirstOrDefault(r => r.Id == id);
        }

        private void UpdateActiveRegion()
        {
            var region = this.Player.Location.Region;
            if (!this.Regions.Contains(region))
                throw new NoRegionException("The player's region is not available in this world.");

            if (region == this.ActiveRegion)
                return;

            this.ActiveRegion = region;
            this.ActiveRegion.World = this;
        }

        #region Events

        protected virtual void OnPlayerLocationChanged(Player player, Location from, Location to)
        {
            this.PlayerLocationChanged?.Invoke(this, new PlayerLocationChangedEventArgs(player, from, to));
        }

        #endregion
    }
}
