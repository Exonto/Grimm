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
        public List<string> Adjectives { get; private set; } = new List<string>();
        public Item(string name)
        {
            this.Name = name;
        }

        public bool HasAdjective(string adjective)
        {
            return this.Adjectives.Contains(adjective);
        }

        public Item WithAdjective(string adjective)
        {
            this.Adjectives.Add(adjective);

            return this;
        }

        public bool IsNameOrAlias(string noun)
        {
            return this.Name.ToLower() == noun ||
                   this.Aliases.Contains(noun);
        }

        public Item WithAlias(string alias)
        {
            this.Aliases.Add(alias);

            return this;
        }
    }
}
