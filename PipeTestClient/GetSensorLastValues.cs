using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeTestClient
{
    class GetSensorLastValues
    {
        public void RunTest(LinkClient client)
        {
            var response = client.Send("cl.device.get-list", null).GetAwaiter().GetResult();

            List<string> deviceIds = new List<string>();

            foreach (var obj in response.Result as dynamic)
            {
                deviceIds.Add(obj.id.ToString());
            }

            response = client.Send("cl.device.get-device-sensors", deviceIds).GetAwaiter().GetResult();

            List<string> sensorIds = new List<string>();

            foreach (var obj in response.Result as dynamic)
            {
                foreach (var sensorValue in obj.Value)
                {
                    sensorIds.Add(sensorValue.id.ToString());
                }
            }

            response = client.Send("cl.sensor.get-last-values", sensorIds).GetAwaiter().GetResult();

            if (response.Error == null)
            {
                Console.WriteLine("GetSensorLastValues Correct");
            }
            else
            {
                Console.WriteLine("GetSensorLastValues Incorrect");
            }

            List<string> fakeSensorId = new List<string>()
            {
                "fake1",
                "fake2",
                "fake3"
            };

            response = client.Send("cl.sensor.get-last-values", sensorIds.Union(fakeSensorId)).GetAwaiter().GetResult();

            if (response.Error == null)
            {
                Console.WriteLine("GetSensorLastValues Incorrect");
            }
            else
            {
                Console.WriteLine("GetSensorLastValues Correct");
            }

            response = client.Send("cl.sensor.get-last-values", fakeSensorId).GetAwaiter().GetResult();

            if (response.Error == null)
            {
                Console.WriteLine("GetSensorLastValues Incorrect");
            }
            else
            {
                Console.WriteLine("GetSensorLastValues Correct");
            }
        }
    }
}
