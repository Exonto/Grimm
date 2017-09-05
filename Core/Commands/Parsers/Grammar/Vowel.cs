using Grimm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers.Grammar
{
    public class Vowel
    {
        private static List<Vowel> Vowels { get; } = new List<Vowel>();

        public static readonly Vowel A = new Vowel('a');
        public static readonly Vowel E = new Vowel('e');
        public static readonly Vowel I = new Vowel('i');
        public static readonly Vowel O = new Vowel('o');
        public static readonly Vowel U = new Vowel('u');

        private char Character { get; }
        private Vowel(char character)
        {
            this.Character = character;

            Vowels.Add(this);
        }

        public static bool IsVowel(string character)
        {
            if (character.Length != 1)
                throw new GrammarException($"The provided vowel {character} must be a single character in length.");

            return Vowels.Any(v => v.Character.ToString() == character.ToLower());
        }

        public static bool IsVowel(char character)
        {
            return Vowels.Any(v => v.Character == character);
        }
    }
}
