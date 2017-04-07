using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    internal enum MethodType
    {
        Unknown,
        GetDevices,
        GetSensors,
        GetSensorValues,
        GetLastSensorValues
    }
}
