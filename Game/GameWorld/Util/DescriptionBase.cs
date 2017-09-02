using Grimm.Core.Commands.Parsers.Grammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Util
{
    public abstract class DescriptionBase<T> where T : DescriptionBase<T>
    {
        public List<string> Lines { get; private set; } = new List<string>();
        public List<Adjective> Adjectives { get; private set; } = new List<Adjective>();

        public bool HasAdjective(Adjective adjective)
        {
            return this.Adjectives.Contains(adjective);
        }

        public bool HasAdjectives(List<Adjective> adjectives)
        {
            return adjectives.All(a => HasAdjective(a));
        }

        public T WithAdjective(Adjective adjective)
        {
            this.Adjectives.Add(adjective);

            return (T)this;
        }

        public T WithLine(string line)
        {
            this.Lines.Add(line);

            return (T)this;
        }
    }
}
