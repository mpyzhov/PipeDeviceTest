using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    public enum SensorType
    {
        [EnumMember(Value = "fan")]
        Fan,
        [EnumMember(Value = "pump")]
        Pump,
        [EnumMember(Value = "temperature")]
        Temperature,
    }
}
