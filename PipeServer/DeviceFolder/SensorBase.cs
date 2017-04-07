using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    internal abstract class SensorBase
    {
        private readonly string id;

        protected SensorBase(string id)
        {
            this.id = id;
        }

        [JsonProperty("id")]
        public string Id { get { return id; } }

        [JsonProperty("sensor-type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract SensorType SensorType { get; }
    }
}
