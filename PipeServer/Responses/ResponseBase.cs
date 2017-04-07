using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.Responses
{
    internal abstract class ResponseBase<T>
    {
        protected ResponseBase(int requestNumber)
        {
            Number = requestNumber;
        }

        [JsonProperty("number")]
        public int Number { get; private set; }

        [JsonProperty("error")]
        public ResponseError Error { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
