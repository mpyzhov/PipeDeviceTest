using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.Responses
{
    internal class GetLastSensorValuesResponse : ResponseBase<Dictionary<string, List<object>>>
    {
        internal GetLastSensorValuesResponse(int requestNumber)
            : base(requestNumber)
        {

        }
    }
}
