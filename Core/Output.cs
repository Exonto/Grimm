using Grimm.Game.GameWorld.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Grimm.Core
{
    public static class Output
    {
        public const int DEFAULT_CHAR_WRITE_SPEED = 60;

        public static OutputBuilder Write(string output)
        {
            Console.Write(output);
            return new OutputBuilder();
        }

        public static OutputBuilder WriteLine()
        {
            Console.WriteLine();
            return new OutputBuilder();
        }

        public static OutputBuilder WriteLine(string output)
        {
            var wordWrapped = WordWrap(output);
            wordWrapped.ForEach(l => Console.WriteLine(l));
            return new OutputBuilder();
        }

        public static OutputBuilder WriteNewLine(string output)
        {
            WriteLine();
            WriteLine(output);
            return new OutputBuilder();
        }

        public static OutputBuilder Say(string output)
        {
            var outputChars = output.ToList();
            outputChars.ForEach(c =>
            {
                Console.Write(c);
                Thread.Sleep(DEFAULT_CHAR_WRITE_SPEED);
            });
            return new OutputBuilder();
        }

        public static OutputBuilder Say(string output, int pause, int initialPause = 0)
        {
            Pause(initialPause);
            var outputChars = output.ToList();
            outputChars.ForEach(c =>
            {
                Console.Write(c);
                Thread.Sleep(pause);
            });
            return new OutputBuilder();
        }

        public static OutputBuilder SayLine(string output)
        {
            var outputChars = output.ToList();
            outputChars.ForEach(c =>
            {
                Console.Write(c);
                Thread.Sleep(DEFAULT_CHAR_WRITE_SPEED);
            });
            WriteLine();
            return new OutputBuilder();
        }

        public static OutputBuilder SayLine(string output, int pause, int initialPause = 0)
        {
            Pause(initialPause);
            var outputChars = output.ToList();
            outputChars.ForEach(c =>
            {
                Console.Write(c);
                Thread.Sleep(pause);
            });
            WriteLine();
            return new OutputBuilder();
        }

        public static OutputBuilder SayNewLine(string output)
        {
            WriteLine();
            SayLine(output);
            return new OutputBuilder();
        }

        public static OutputBuilder SayNewLine(string output, int pause, int initialPause = 0)
        {
            Pause(initialPause);
            WriteLine();
            SayLine(output, pause);
            return new OutputBuilder();
        }

        public static void Pause(int millis)
        {
            Thread.Sleep(millis);
        }

        private static List<string> WordWrap(string output)
        {
            var words = output.Split(' ');
            return words.Skip(1).Aggregate(words.Take(1).ToList(), (l, w) =>
            {
                if (l.Last().Length + w.Length >= 80)
                    l.Add(w);
                else
                    l[l.Count - 1] += " " + w;
                return l;
            });
        }
    }

    // ---------------------------------------------------------------------------------------------

    public class OutputBuilder
    {
        public OutputBuilder Write(string output)
        {
            Output.Write(output);
            return this;
        }

        public OutputBuilder WriteLine()
        {
            Output.WriteLine();
            return this;
        }

        public OutputBuilder WriteLine(string output)
        {
            Output.WriteLine(output);
            return this;
        }

        public OutputBuilder WriteNewLine(string output)
        {
            Output.WriteNewLine(output);
            return this;
        }

        public OutputBuilder Say(string output)
        {
            Output.Say(output);
            return this;
        }

        public OutputBuilder Say(string output, int pause, int initialPause = 0)
        {
            Output.Say(output, pause, initialPause);
            return this;
        }

        public  OutputBuilder SayLine(string output)
        {
            Output.SayLine(output);
            return this;
        }

        public OutputBuilder SayLine(string output, int pause, int initialPause = 0)
        {
            Output.SayLine(output, pause, initialPause);
            return this;
        }

        public OutputBuilder SayNewLine(string output)
        {
            Output.SayLine(output);
            return this;
        }

        public OutputBuilder SayNewLine(string output, int pause, int initialPause = 0)
        {
            Output.SayNewLine(output, pause, initialPause);
            return this;
        }

        public OutputBuilder Pause(int millis)
        {
            Output.Pause(millis);
            return this;
        }
    }
}
