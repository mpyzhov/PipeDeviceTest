using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    internal class TempSensor : FloatSensorBase
    {
        public TempSensor(string id) 
            : base(id)
        {
        }

        public override SensorType SensorType
        {
            get
            {
                return SensorType.Temperature;
            }
        }
    }
}
