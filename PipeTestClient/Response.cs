using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeTestClient
{
    public class Response
    {
        [JsonProperty("number")]
        public int Number { get; private set; }

        [JsonProperty("error")]
        public ResponseError Error { get; set; }

        [JsonProperty("result")]
        public object Result { get; set; }
    }

    public class ResponseError
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}
