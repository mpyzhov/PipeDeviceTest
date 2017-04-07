using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.DeviceFolder
{
    internal interface ISensorValue
    {
        object GetSensorValue();

        List<object> GetLastSensorValues();
    }
}
