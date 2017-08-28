using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands
{
    public sealed class Arguments
    {
        public List<string> Args { get; private set; } = new List<string>();

        public Arguments() { }

        public Arguments(List<string> args)
        {
            this.Args = args;
        }

        public bool HasAtLeast(int numberOfArgs)
        {
            return this.Args.Count >= numberOfArgs;
        }

        public bool HasLessThan(int numberOfArgs)
        {
            return this.Args.Count < numberOfArgs;
        }

        public bool HasExactly(int numberOfArgs)
        {
            return this.Args.Count == numberOfArgs;
        }

        public void RemoveOccurrencesOf(string arg)
        {
            this.Args.RemoveAll(a => a.ToLower() == arg.ToLower());
        }

        public string ElementAt(int index)
        {
            return this.Args.ElementAt(index);
        }
    }
}
