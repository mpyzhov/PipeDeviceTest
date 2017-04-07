using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            byte[] messageBytes = Encoding.UTF8.GetBytes(serialized);

            client.WriteAsync(messageBytes, 0, messageBytes.Length).GetAwaiter().GetResult();

            return await Read();
        }

        //public void SendWithoutRead(Request request)
        //{
        //    string serialized = JsonConvert.SerializeObject(request);

        //    byte[] messageBytes = Encoding.UTF8.GetBytes(serialized);

        //    client.WriteAsync(messageBytes, 0, messageBytes.Length).GetAwaiter().GetResult();
        //}

        private static NamedPipeClientStream PrepareClient()
        {
            NamedPipeClientStream client = new NamedPipeClientStream(".", "CLinkPipeService", PipeDirection.InOut);

            client.Connect();
            client.ReadMode = PipeTransmissionMode.Message;

            return client;
        }

        private async Task<Response> Read()
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

            return JsonConvert.DeserializeObject<Response>(messageBuilder.ToString());
        }
    }
}
