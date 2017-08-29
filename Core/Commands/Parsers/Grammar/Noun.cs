using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers.Grammar
{
    public class Noun
    {
        public string Word { get; private set; }
        public List<Adjective> Adjectives { get; private set; } = new List<Adjective>();
        public Noun(string word)
        {
            this.Word = word.ToLower();
        }

        public void AddAdjective(Adjective adjective)
        {
            this.Adjectives.Add(adjective);
        }

        public bool HasAdjective(Adjective adjective)
        {
            return this.Adjectives.Contains(adjective);
        }

        public override string ToString()
        {
            var str = "";
            this.Adjectives.ForEach(a => str += a.Word + " ");
            str += this.Word;

            return str;
        }
    }
}
