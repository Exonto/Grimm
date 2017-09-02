using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimm.Game.GameWorld.Util
{
    public class RandomResponse
    {
        private List<Response> Responses { get; } = new List<Response>();

        public RandomResponse WithResponse(Response response)
        {
            this.Responses.Add(response);

            return this;
        }

        public RandomResponse WithResponse(string singleLineResponse)
        {
            this.Responses.Add(new Response().WithLine(singleLineResponse));

            return this;
        }

        public Response GetResponse()
        {
            var randomGenerator = new Random();

            var index = randomGenerator.Next(this.Responses.Count);

            return this.Responses[index];
        }

        public void OutputResponse(params string[] stringsToInsert)
        {
            var randomResponse = GetResponse();
            randomResponse.OutputResponse(stringsToInsert);
        }
    }
}
