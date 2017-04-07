using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReader
{
    public abstract class Device
    {
        internal Device()
        {
            Sensors = new List<object>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("vid")]
        public int Vid { get; set; }

        [JsonProperty("pid")]
        public int Pid { get; set; }

        [JsonProperty("device-name")]
        public string DeviceName { get; set; }

        [JsonProperty("firmware-version")]
        public string FirmwareVersion { get; set; }

        [JsonProperty("bootloader-version")]
        public string BootloaderVersion { get; set; }

        [JsonProperty("capabilities")]
        public Dictionary<string, object> Capabilities { get; set; }

        [JsonIgnore]
        public List<object> Sensors { get; set; }
    }
}
