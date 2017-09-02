using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Game;
using Grimm.Game.GameWorld.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public interface IParserService
    {
        GameState GameState { get; }

        bool HasItemInCurrentLocation(Noun itemNoun);
        bool HasItemInContainer(Noun itemNoun, Noun containerNoun);
        Item GetItemFromCurrentLocation(Noun itemNoun);
        Item GetItemFromContainer(Noun itemNoun, Noun containerNoun);
    }
}
