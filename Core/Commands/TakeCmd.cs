﻿using Grimm.Core.Commands.Parsers;
using Grimm.Game;
using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Results
{
    public class TakeCmd : Command
    {
        public TakeCmd(GameState state) 
            : base("take", new string[] { "grab" })
        {
            this.GameState = state;

            base._parser = new TakeCmdParser(this);
        }

        public override void Execute(string alias, Arguments args = null)
        {
            base._parser.ParseAndExecute(alias, args);
        }

        public void TakeItemFromCurrentLocation(Item item)
        {
            var player = this.GameState.Player;

            player.TakeItem(item);
        }

        public void TakeItemsFromCurrentLocation(List<Item> items)
        {
            var player = this.GameState.Player;

            player.TakeItems(items);
        }

        public void TakeItemFromContainer(Item target, Item container)
        {
            var player = this.GameState.Player;

            player.TakeItemFromContainer(target, container);
        }

        public void TakeItemsFromContainer(Item container, List<Item> items)
        {
            var player = this.GameState.Player;

            player.TakeItemsFromContainer(container, items);
        }
    }
}
