using Grimm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers.Grammar
{
    public class Contraction
    {
        private static List<Contraction> Contractions { get; } = new List<Contraction>();

        public static readonly Contraction AND = new Contraction("and");
        public static readonly Contraction OR = new Contraction("or");

        private string Word { get; }
        private Contraction(string word)
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
    }
}
