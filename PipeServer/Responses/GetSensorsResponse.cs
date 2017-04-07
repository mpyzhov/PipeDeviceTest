using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.Responses
{
    internal class GetSensorsResponse : ResponseBase<Dictionary<string, List<SensorBase>>>
    {
        internal GetSensorsResponse(int requestNumber)
            : base(requestNumber)
        {

        }
    }
}
