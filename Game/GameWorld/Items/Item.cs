using Grimm.Core.Commands.Parsers.Grammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Items
{
    public class Item
    {
        public string Name { get; set; }
        public List<string> Aliases { get; private set; } = new List<string>();
        public List<Adjective> Adjectives { get; private set; } = new List<Adjective>();
        public Item(string name)
        {
            this.Name = name;
        }

        public bool HasAdjective(Adjective adjective)
        {
            return this.Adjectives.Contains(adjective);
        }

        public bool HasAdjectives(List<Adjective> adjectives)
        {
            return adjectives.All(a => HasAdjective(a));
        }

        public Item WithAdjective(Adjective adjective)
        {
            this.Adjectives.Add(adjective);

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
    }
}
