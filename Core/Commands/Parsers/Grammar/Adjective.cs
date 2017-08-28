﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers.Grammar
{
    public class Adjective
    {
        private static List<Adjective> Adjectives { get; } = new List<Adjective>();

        public static readonly Adjective MY = new Adjective("my")
            .WithRequiredPosition(1);

        public static readonly Adjective HIS = new Adjective("his")
            .WithRequiredPosition(1);
        public static readonly Adjective HER = new Adjective("her")
            .WithRequiredPosition(1);

        public static readonly Adjective TINY = new Adjective("tiny");
        public static readonly Adjective SMALL = new Adjective("small");
        public static readonly Adjective AVERAGE = new Adjective("average")
            .WithAlias("medium");
        public static readonly Adjective LARGE = new Adjective("large")
            .WithAlias("big");
        public static readonly Adjective MASSIVE = new Adjective("massive")
            .WithAlias("huge")
            .WithAlias("gigantic");

        // --------------------------------------------------------------------------------

        public string Name { get; private set; }
        public List<string> Aliases { get; private set; } = new List<string>();

        public int? RequiredPosition;

        private Adjective(string name)
        {
            this.Name = name;

            Adjectives.Add(this);
        }

        public static bool IsAdjective(string adjective)
        {
            return Adjectives.Any(a => a.Name == adjective.ToLower());
        }

        public static bool IsOwnership(string owernshipAdjective)
        {
            var length = owernshipAdjective.Length;

            // For an adjective to be considered and ownership adjective
            // It must have and " 's " at the end with at least one other
            // character appearing before the " 's "
            if (length < 3)
                return false;

            return owernshipAdjective.ElementAt(length - 2) == '\'' &&
                   owernshipAdjective.ElementAt(length - 1) == 's';
        }

        public bool HasRequiredPosition()
        {
            return this.RequiredPosition != null;
        }

        public Adjective WithRequiredPosition(int position)
        {
            this.RequiredPosition = position;

            return this;
        }

        public bool IsNameOrAlias(string adjective)
        {
            return this.Name.ToLower() == adjective ||
                   this.HasAlias(adjective);
        }

        public bool HasAlias(string alias)
        {
            return this.Aliases.Contains(alias);
        }

        public Adjective WithAlias(string alias)
        {
            this.Aliases.Add(alias);

            return this;
        }
    }
}
