using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.Responses
{
    internal class GetSensorValuesResponse : ResponseBase<Dictionary<string, object>>
    {
        internal GetSensorValuesResponse(int requestNumber)
            : base(requestNumber)
        {

        }
    }
}
