using Grimm.Core.Commands.Parsers.Grammar;
using Grimm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers
{
    public class GrammarParser
    {
        private Arguments Args { get; set; }
        private Arguments Original { get; set; }
        public GrammarParser(Arguments args)
        {
            this.Original = args;
            this.Args = GetCondensed();
        }

        private Arguments GetCondensed()
        {
            Arguments stripped = new Arguments(this.Original.Args);
            stripped = StripArticles();

            return stripped;
        }

        private Arguments StripArticles()
        {
            Arguments stripped = new Arguments(this.Original.Args);
            stripped.RemoveOccurrencesOf("the");
            stripped.RemoveOccurrencesOf("a");
            stripped.RemoveOccurrencesOf("an");

            return stripped;
        }

        public bool HasSubject()
        {
            if (!this.Args.HasAtLeast(1))
                return false;

            var arg = this.Args.Args[0];

            if (Preposition.IsPreposition(arg))
                return false;

            if (Adjective.IsAdjective(arg))
            {
                return GetSubjectOfAdjectiveAt(0) != null;
            }

            return true;
        }

        public Noun GetSubject()
        {
            if (!HasSubject())
                throw new GrammarException("No subject.");

            return GetNounAt(0);
        }

        private string GetSubjectOfAdjectiveAt(int adjectiveIdx)
        {
            for (var idx = adjectiveIdx; idx < this.Args.Args.Count; idx++)
            {
                var arg = this.Args.Args[idx];
                if (!Adjective.IsAdjective(arg))
                    return arg;
            }
            return null;
        }

        /// <summary>
        /// Will build a noun by adding any adjectives beginning
        /// at the provided idx.
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public Noun GetNounAt(int idx)
        {
            var adjectives = new List<Adjective>();
            var nextArg = this.Args.Args.ElementAt(0);
            while (Adjective.IsAdjective(nextArg))
            {
                var adjective = Adjective.Parse(nextArg);

                // Enforces an adjectives required position
                if (adjective.HasRequiredPosition() &&
                    adjective.RequiredPosition != idx + 1)
                    return null;

                adjectives.Add(Adjective.Parse(nextArg));
                ++idx;
                nextArg = this.Args.Args.ElementAt(idx);
            }

            var noun = new Noun(nextArg);
            adjectives.ForEach(a => noun.AddAdjective(a));

            return noun;
        }

        public bool HasAnyPreposition()
        {
            return this.Args.Args.Any(a => Preposition.IsPreposition(a));
        }

        public bool HasPreposition(string preposition)
        {
            return this.Args.Args.Any(a => a.ToLower() == preposition.ToLower());
        }

        public int TotalPrepositions()
        {
            return this.Args.Args
                .Where(a => Preposition.IsPreposition(a))
                .Count();
        }

        public int GetPrepositionPosition(string preposition)
        {
            if (!HasPreposition(preposition))
                throw new ArgumentException($"The argument list does not contain the preposition: \"{preposition}\"");

            var order = 1;

            foreach (var arg in this.Args.Args)
            {
                if (arg.ToLower() == preposition.ToLower())
                    break;
                else if (Preposition.IsPreposition(arg))
                    ++order;
            }

            return order;
        }

        public bool HasPrepositionAt(int position)
        {
            try
            {
                return TotalPrepositions() < position;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public bool HasPrepositionAt(string preposition, int position)
        {
            try
            {
                return GetPreposition(position) == preposition.ToLower();
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public string GetPreposition(int position)
        {
            if (TotalPrepositions() < position)
                throw new IndexOutOfRangeException($"There is no preposition at the position: {position}");

            var prepositionsFound = 0;
            var idx = 0;
            foreach (var arg in this.Args.Args)
            {
                if (Preposition.IsPreposition(arg))
                    ++prepositionsFound;

                if (prepositionsFound == position)
                    break;

                ++idx;
            }

            return this.Args.Args.ElementAt(idx);
        }

        public bool HasPrepositionBefore(string preposition)
        {
            return GetPrepositionPosition(preposition) > 1;
        }

        public bool HasPrepositionAfter(string preposition)
        {
            return GetPrepositionPosition(preposition) < TotalPrepositions();
        }

        public string GetPrepositionBefore(string preposition)
        {
            if (!HasPrepositionBefore(preposition))
                throw new ArgumentException("The preposition has no preceding preposition");

            return GetPreposition(GetPrepositionPosition(preposition) - 1);
        }

        public string GetPrepositionAfter(string preposition)
        {
            if (HasPrepositionAfter(preposition))
                throw new ArgumentException("The preposition has no preposition after it");

            return GetPreposition(GetPrepositionPosition(preposition) + 1);
        }

        public bool HasObjectOfPreposition(string preposition)
        {
            try
            {
                GetObjectOfPreposition(preposition);

                return true;
            }
            catch (NoObjectOfPrepositionException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public Noun GetObjectOfPreposition(string preposition)
        {
            try
            {
                if (!HasPreposition(preposition))
                    throw new ArgumentException($"The argument list does not contain the preposition: \"{preposition}\"");

                var nextIdx = this.Args.Args.IndexOf(preposition) + 1;
                var nextArg = this.Args.Args.ElementAt(nextIdx);

                // There may be cases where two or more prepositions occur immediately
                // after each other. In this case, they all share the same object.
                while (Preposition.IsPreposition(nextArg))
                {
                    ++nextIdx;
                    nextArg = this.Args.Args.ElementAt(nextIdx);
                }

                return GetNounAt(nextIdx);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NoObjectOfPrepositionException();
            }
        }
    }
}
