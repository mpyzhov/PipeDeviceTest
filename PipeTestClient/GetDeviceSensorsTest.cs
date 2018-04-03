using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeTestClient
{
    //public class GetDeviceSensorsTest
    //{
    //    public void RunTest(LinkClient client)
    //    {
    //        var response = client.Send("cl.device.get-list", null).GetAwaiter().GetResult();

    //        List<string> deviceIds = new List<string>();

    //        foreach (var obj in response.Result as dynamic)
    //        {
    //            deviceIds.Add(obj.id.ToString());
    //        }

    //        var count = RunExistingDevices(client, deviceIds);

    //        List<string> missingDevices = new List<string>()
    //        {
    //            "fake1",
    //            "fake2",
    //            "fake3"
    //        };

    //        response = client.Send("cl.device.get-device-sensors", deviceIds.Union(missingDevices)).GetAwaiter().GetResult();

    //        if (response.Error == null)
    //        {
    //            Console.WriteLine("GetDeviceSensors Incorrect");
    //        }
    //        else
    //        {
    //            int c = 0;
    //            foreach (var obj in response.Result as dynamic)
    //            {
    //                c++;
    //            }
    //            if (c != count)
    //            {
    //                Console.WriteLine("GetDeviceSensors Incorrect");
    //            }
    //            else
    //            {
    //                Console.WriteLine("GetDeviceSensors Correct");
    //            }
    //        }

    //        response = client.Send("cl.device.get-device-sensors", missingDevices).GetAwaiter().GetResult();

    //        if (response.Error == null)
    //        {
    //            Console.WriteLine("GetDeviceSensors Incorrect");
    //        }
    //        else
    //        {
    //            Console.WriteLine("GetDeviceSensors Correct");
    //        }
    //    }

    //    private static int RunExistingDevices(LinkClient client, List<string> deviceIds)
    //    {
    //        Response response = client.Send("cl.device.get-device-sensors", deviceIds).GetAwaiter().GetResult();
    //        if (response.Error == null)
    //        {
    //            Console.WriteLine("GetDeviceSensors Correct");

    //            int c = 0;
    //            foreach(var obj in response.Result as dynamic)
    //            {
    //                c++;
    //            }
    //            return c;
    //        }
    //        else
    //        {
    //            Console.WriteLine("GetDeviceSensors Incorrect");
    //            return 0;
    //        }
    //    }
    //}
}
