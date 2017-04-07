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

        public async void Send(Request request)
        {
            string serialized = JsonConvert.SerializeObject(request);

            byte[] messageBytes = Encoding.UTF8.GetBytes(serialized);
            await client.WriteAsync(messageBytes, 0, messageBytes.Length);

            await Read();
        }

        private static NamedPipeClientStream PrepareClient()
        {
            NamedPipeClientStream client = new NamedPipeClientStream(".", "CLinkServicePipeService", PipeDirection.InOut);

            client.Connect();
            client.ReadMode = PipeTransmissionMode.Message;

            return client;
        }

        private async Task Read()
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

            Console.WriteLine(messageBuilder.ToString());
        }
    }
}
