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

        public Item GetItemFromCurrentLocation(Noun itemNoun)
        {
            var currentLoc = this.GameState.GetPlayerLocation();
            return currentLoc.Inventory.Items.FirstOrDefault(i => i.Name.ToLower() == itemNoun.Word.ToLower() &&
                                                                  i.Description.HasAdjectives(itemNoun.Adjectives));
        }

        public Item GetItemFromContainer(Noun itemNoun, Noun containerNoun)
        {
            var containerItem = GetItemFromCurrentLocation(containerNoun);
            return containerItem.Inventory.Items.FirstOrDefault(i => i.Name.ToLower() == itemNoun.Word.ToLower() &&
                                                                     i.Description.HasAdjectives(itemNoun.Adjectives));
        }

    }
}
