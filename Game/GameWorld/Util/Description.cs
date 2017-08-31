using Grimm.Core.Commands.Parsers.Grammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Util
{
    public class Description
    {
        List<Adjective> Adjectives { get; set; } = new List<Adjective>();

        public bool HasAdjective(Adjective adjective)
        {
            return this.Adjectives.Contains(adjective);
        }

        public bool HasAdjectives(List<Adjective> adjectives)
        {
            return adjectives.All(a => HasAdjective(a));
        }

        public Description WithAdjective(Adjective adjective)
        {
            this.Adjectives.Add(adjective);

            return this;
        }
    }
}
