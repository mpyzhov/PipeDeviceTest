using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeClient
{
    public class Request
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("method")]
        public string MethodName { get; set; }

        [JsonProperty("parameters")]
        public object[] Params { get; set; }

    }
}
