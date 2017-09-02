using Grimm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Util
{
    public class Response
    {
        public List<string> Lines { get; } = new List<string>();

        public Response WithLine(string response)
        {
            this.Lines.Add(response);

            return this;
        }

        public void OutputResponse(params string[] stringsToInsert)
        {
            var objectsToInsert = stringsToInsert.Cast<object>().ToArray();

            this.Lines.ForEach(l => Output.WriteLine(string.Format(l, objectsToInsert)));
            Output.WriteLine();
        }
    }
}
