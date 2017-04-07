using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.Responses
{
    internal class GetDeviceResponse : ResponseBase<List<Device>>
    {
        internal GetDeviceResponse(int requestNumber)
            : base(requestNumber)
        {

        }
    }
}
