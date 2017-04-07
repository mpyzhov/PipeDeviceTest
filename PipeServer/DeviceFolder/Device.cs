using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    internal class Device
    {
        internal Device()
        {
            Sensors = new List<SensorBase>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("vid")]
        public int Vid { get; set; }

        [JsonProperty("pid")]
        public int Pid { get; set; }

        [JsonProperty("firmware-version")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("bootloader-version")]
        public string BootloaderVersion { get; set; }

        [JsonProperty("capabilities")]
        public object Capabilities { get; set; }

        [JsonIgnore]
        public List<SensorBase> Sensors { get; set; }
    }
}
