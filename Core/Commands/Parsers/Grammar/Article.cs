﻿using Grimm.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers.Grammar
{
    public class Article
    {
        private static List<Article> Articles { get; } = new List<Article>();

        public static readonly Article A = new Article("a", false);
        public static readonly Article AN = new Article("an", false);
        public static readonly Article THE = new Article("the", true);

        private string Word { get; }
        private bool IsDefinite { get; }
        private Article(string word, bool isDefinite)
        {
            this.Word = word;
            this.IsDefinite = isDefinite;

            Articles.Add(this);
        }

        public override string ToString()
        {
            return this.Word;
        }

        public static bool IsArticle(string article)
        {
            return Articles.Any(a => a.Word == article.ToLower());
        }
    }
}
