using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public static class Preposition
    {
        private static List<string> Prepositions = new List<string>();

        public static readonly string FROM = CreatePreposition("from");
        public static readonly string OF = CreatePreposition("of");
        public static readonly string TO = CreatePreposition("to");
        public static readonly string INTO = CreatePreposition("into");
        public static readonly string ON = CreatePreposition("on");
        public static readonly string ONTO = CreatePreposition("onto");
        public static readonly string WITH = CreatePreposition("with");

        public static readonly string IN = CreatePreposition("in");
        public static readonly string OUT = CreatePreposition("out");
        public static readonly string INSIDE = CreatePreposition("inside");
        public static readonly string OUTSIDE = CreatePreposition("outside");
        public static readonly string WITHIN = CreatePreposition("within");

        public static bool IsPreposition(string preposition)
        {
            return Prepositions.Contains(preposition.ToLower());
        }

        private static string CreatePreposition(string preposition)
        {
            Prepositions.Add(preposition);
            return preposition;
        }
    }
}
