using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    internal abstract class FloatSensorBase : SensorValueBase<float>
    {
        public FloatSensorBase(string id) 
            : base(id)
        {
        }
    }
}
