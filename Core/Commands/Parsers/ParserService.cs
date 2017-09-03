using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Game.GameWorld.Items;
using Grimm.Game;

namespace Grimm.Core.Commands.Parsers
{
    public class ParserService : IParserService
    {
        public GameState GameState { get; }

        public ParserService(GameState gameState)
        {
            this.GameState = gameState;
        }

        public bool HasItemInCurrentLocation(Noun itemNoun)
        {
            var currentLoc = this.GameState.GetPlayerLocation();
            return HasItemInInventory(itemNoun, currentLoc.Inventory);
        }

        public bool HasItemInContainer(Noun itemNoun, Noun containerNoun)
        {
            var containerItem = GetItemFromCurrentLocation(containerNoun);
            return HasItemInInventory(itemNoun, containerItem.Inventory); ;
        }

        public bool HasItemInInventory(Noun itemNoun, Inventory inventory)
        {
            return GetItemFromInventory(itemNoun, inventory) != null;
        }
        
        public Item GetItemFromCurrentLocation(Noun itemNoun)
        {
            var currentLoc = this.GameState.GetPlayerLocation();
            return GetItemFromInventory(itemNoun, currentLoc.Inventory);
        }

        public Item GetItemFromContainer(Noun itemNoun, Noun containerNoun)
        {
            var containerItem = GetItemFromCurrentLocation(containerNoun);
            return GetItemFromInventory(itemNoun, containerItem.Inventory);
        }

        public Item GetItemFromInventory(Noun itemNoun, Inventory inventory)
        {
            return inventory.Items.FirstOrDefault(i => i.Name.ToLower() == itemNoun.Word.ToLower() &&
                                                       i.Description.HasAdjectives(itemNoun.Adjectives));
        }
    }
}
