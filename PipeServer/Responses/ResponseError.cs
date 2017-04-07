using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.Responses
{
    internal enum ErrorCode
    {
        [EnumMember(Value ="unknown-method")]
        UnknownMethod = 1,
    }

    internal class ResponseError
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("code")]
        public ErrorCode Code { get; set; }
    }
}
