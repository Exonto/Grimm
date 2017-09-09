using Grimm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers.Grammar
{
    public class Conjunction
    {
        private static List<Conjunction> Contractions { get; } = new List<Conjunction>();

        public static readonly Conjunction AND = new Conjunction("and");
        public static readonly Conjunction OR = new Conjunction("or");

        private string Word { get; }
        private Conjunction(string word)
        {
            this.Word = word;

            Contractions.Add(this);
        }

        public override string ToString()
        {
            return this.Word;
        }

        public static bool IsContraction(string contraction)
        {
            return Contractions.Any(a => a.Word == contraction.ToLower());
        }

        public static Conjunction Parse(string contraction)
        {
            return Contractions.FirstOrDefault(c => c.Word == contraction.ToLower());
        }
    }
}
