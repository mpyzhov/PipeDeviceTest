using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer.Responses
{
    internal class UnknownResponse : ResponseBase<object>
    {
        public UnknownResponse(int requestNumber)
            : base(requestNumber)
        {
            Error = new ResponseError
            {
                Code = ErrorCode.UnknownMethod,
                Text = "Method is absent on server"
            };
        }
    }
}
