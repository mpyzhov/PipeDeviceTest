using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    public class Connection : IDisposable
    {
        private readonly NamedPipeServerStream stream;

        private Subject<Message> onMessage = new Subject<Message>();

        public Connection(NamedPipeServerStream stream)
        {
            this.stream = stream;

            Start();
        }

        public IObservable<Message> OnMessage
        {
            get { return onMessage; }
        }

        public bool IsConnected
        {
            get { return stream.IsConnected; }
        }

        public async void Send(string data)
        {
            if(stream.IsConnected)
            {
                var dataBytes = Encoding.UTF8.GetBytes(data);
                await stream.WriteAsync(dataBytes, 0, dataBytes.Length); 
            }
        }

        public void Dispose()
        {
            stream.Dispose();
        }

        private async void Start()
        {
            while (stream.IsConnected)
            {
                StringBuilder messageBuilder = new StringBuilder();
                string messageChunk = string.Empty;
                byte[] messageBuffer = new byte[5];
                do
                {
                    await stream.ReadAsync(messageBuffer, 0, messageBuffer.Length);
                    messageChunk = Encoding.UTF8.GetString(messageBuffer);
                    messageBuilder.Append(messageChunk);
                    messageBuffer = new byte[messageBuffer.Length];
                }
                while (!stream.IsMessageComplete);

                onMessage.OnNext(new Message(this, messageBuilder.ToString()));
            }

            Stop();
        }

        private void Stop()
        {
            stream.Disconnect();
            Dispose();
        }
    }
}
