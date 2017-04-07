using Newtonsoft.Json;
using Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Console.WriteLine("Click any button to close...");
            Console.Read();
        }

        private static async void Test1()
        {
            Console.WriteLine("---Test1---");

            NamedPipeClientStream client = PrepareClient();

            //Request request = new Request()
            //{
            //    MethodName = "cl.sensor.get-last-values",
            //    Number = 1,
            //    Params = new string[]
            //    {
            //        "1",
            //        "2",
            //        "11",
            //        "22",
            //        "3"
            //    }
            //};1.	cl.device.get-list


            Request request = new Request()
            {
                MethodName = "cl.device.get-list",
                Number = 1,
                Params = null
            };

    //        Request request = new Request()
    //        {
    //            MethodName = "cl.device.get-device-sensors",
    //            Number = 4,
    //            Params = new string[]
    //            {
    //                        "vid<6940>pid<787515>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&F9B17DA&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>", }
    //                        "2",
    //        }
    //                        "11",
    //                        "22",
    //                        "3"
    //                    }
    //};

    //    Request request = new Request()
    //    {
    //        MethodName = "cl.sensor.get-last-values",
    //        Number = 4,
    //        Params = new string[]
    //        {
    //    "vid<6940>pid<787515>serial<\\\\.\\HID#VID_1B1C&PID_0C04#6&F9B17DA&0&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}0>index<0>senstype<Fan>sensindex<1>", }
    ////    "2", }
    ////    "11",
    ////    "22",
    ////    "3"
    ////}
    //    };



    string serialised = JsonConvert.SerializeObject(request);

            byte[] messageBytes = Encoding.UTF8.GetBytes(serialised);
            await client.WriteAsync(messageBytes, 0, messageBytes.Length);

            StringBuilder messageBuilder = new StringBuilder();
            string messageChunk = string.Empty;
            byte[] messageBuffer = new byte[5];
            do
            {
                await client.ReadAsync(messageBuffer, 0, messageBuffer.Length);
                messageChunk = Encoding.UTF8.GetString(messageBuffer);
                messageBuilder.Append(messageChunk);
                messageBuffer = new byte[messageBuffer.Length];
            }
            while (!client.IsMessageComplete);

            Console.WriteLine(messageBuilder.ToString());

            Console.WriteLine("---Test1 competed---");
            Console.WriteLine();
        }

        private static NamedPipeClientStream PrepareClient()
        {
            NamedPipeClientStream client = new NamedPipeClientStream(".", "CLinkServicePipeService", PipeDirection.InOut);

            client.Connect();

            client.ReadMode = PipeTransmissionMode.Message;
            return client;
        }
    }
}
