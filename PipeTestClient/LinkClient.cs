using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeTestClient
{
    public class LinkClient
    {
        private NamedPipeClientStream client;
        private int number = 1;
        public LinkClient()
        {

        }

        public async void Start()
        {
            if(client == null)
            {
                client = PrepareClient();
            }
        }

        public async Task<Response> Send(string method, object parameters)
        {
            string serialized = JsonConvert.SerializeObject(new Request
            {
                MethodName = method,
                Number = number++,
                Params = parameters
            });

            //Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine(serialized);
            //Console.ForegroundColor = ConsoleColor.DarkGreen;

            byte[] messageBytes = ConvertToPipeBytes(serialized);

            Stopwatch sw = Stopwatch.StartNew();
            client.WriteAsync(messageBytes.ToArray(), 0, messageBytes.Length)
                .GetAwaiter()
                .GetResult();
            client.Flush();

            var read = await Read();
            sw.Stop();

            //Console.WriteLine("Ellapsed: " + sw.ElapsedMilliseconds);
            return read;
        }

        internal static byte[] ConvertToPipeBytes(string value)
        {
            byte[] intBytes = BitConverter.GetBytes(value.Length);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(intBytes);
            }

            var dataBytes = Encoding.UTF8.GetBytes(value);

            var resultBytes = new byte[4 + dataBytes.Length];
            intBytes.CopyTo(resultBytes, 0);
            dataBytes.CopyTo(resultBytes, 4);

            return resultBytes;
        }

        //public void SendWithoutRead(Request request)
        //{
        //    string serialized = JsonConvert.SerializeObject(request);

        //    byte[] messageBytes = Encoding.UTF8.GetBytes(serialized);

        //    client.WriteAsync(messageBytes, 0, messageBytes.Length).GetAwaiter().GetResult();
        //}

        private static NamedPipeClientStream PrepareClient()
        {
            //var process = Process.GetProcessesByName("CorsairLink4.LinkService").Count();

            NamedPipeClientStream client = new NamedPipeClientStream(".", "CLinkPipeService", PipeDirection.InOut);

            client.Connect();
            client.ReadMode = PipeTransmissionMode.Message;

            return client;
        }

        public async Task<Response> Read()
        {
            StringBuilder messageBuilder = new StringBuilder();
            string messageChunk = string.Empty;
            byte[] messageBuffer = new byte[1024];
            do
            {
                await client.ReadAsync(messageBuffer, 0, messageBuffer.Length);
                messageChunk = Encoding.UTF8.GetString(messageBuffer);
                messageBuilder.Append(messageChunk);
                messageBuffer = new byte[messageBuffer.Length];
            }
            while (!client.IsMessageComplete);

            messageBuilder.Remove(0, 4);

            return JsonConvert.DeserializeObject<Response>(messageBuilder.ToString());
        }

        public async Task<Request> ReadRequest()
        {
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

            messageBuilder.Remove(0, 4);

            return JsonConvert.DeserializeObject<Request>(messageBuilder.ToString());
        }
    }
}
