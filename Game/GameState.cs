using Grimm.Game.GameWorld;
using Grimm.Game.GameWorld.Builders.WorldRegions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game
{
    public sealed class GameState
    {
        public World World { get; set; }
        public Player Player { get; set; }

        public void StartGame()
        {
            this.World = new World("Overworld");
            PopulateWorld();

            SpawnPlayer();

            var commandLine = new CommandLine();
            commandLine.StartListening();
        }

        public Location GetPlayerLocation()
        {
            return this.Player.Location;
        }

        private void PopulateWorld()
        {
            var regionBuilder = new RegionBuilder();
            var regions = regionBuilder.BuildWorldRegions();
            regions.ForEach(r => this.World.AddRegion(r));
        }

        private void SpawnPlayer()
        {
            this.Player = new Player("Tyler Syme");
            this.World.SpawnPlayer(this.Player, this.World.GetRegionById(Regions.ERSOM_VILLAGE), new Vector(0,0,2));
        }
    }
}
