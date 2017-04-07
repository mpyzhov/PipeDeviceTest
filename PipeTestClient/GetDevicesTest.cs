using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeTestClient
{
    public class GetDevicesTest
    {
        public void RunTest(LinkClient client)
        {
            RunCorrectTest(client);
        }

        private void RunCorrectTest(LinkClient client)
        {
            var response = client.Send("cl.device.get-list", null).GetAwaiter().GetResult();

            if(response.Error == null)
            {
                Console.WriteLine("GetDevicesTest Correct");
            }
            else
            {
                Console.WriteLine("GetDevicesTest Incorrect");
            }
        }
    }
}
