using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PactNet.Mocks.MockHttpService.Models;

namespace PactNet.Matchers
{
    [JsonConverter(typeof(MatcherConverter))]
    internal interface IMatcher
    {
        [JsonProperty("match")]
        string Type { get; }

        MatcherResult Match(string path, JToken expected, JToken actual);
    }
}