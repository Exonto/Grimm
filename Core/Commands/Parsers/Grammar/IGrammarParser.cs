using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Core.Commands.Parsers.Grammar
{
    public interface IGrammarParser
    {
        bool HasSubject();
        Noun GetSubject();

        bool HasAnyPreposition();
        bool HasPreposition(string preposition);
        int TotalPrepositions();
        int GetPrepositionPosition(string preposition);
        bool HasPrepositionAt(int position);
        bool HasPrepositionAt(string preposition, int position);
        string GetPreposition(int position);
        bool HasPrepositionBefore(string preposition);
        bool HasPrepositionAfter(string preposition);
        string GetPrepositionBefore(string preposition);
        string GetPrepositionAfter(string preposition);
        bool HasObjectOfPreposition(string preposition);
        Noun GetObjectOfPreposition(string preposition);
    }
}
