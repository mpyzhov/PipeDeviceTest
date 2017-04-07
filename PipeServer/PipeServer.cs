using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    public class PipeServer
    {
        private const string PipeName = "CLinkServicePipeService";
        private readonly List<Connection> connections = new List<Connection>();

        private Subject<Message> onMessage = new Subject<Message>();

        public IObservable<Message> OnMessage
        {
            get { return onMessage; }
        }

        public void Start()
        {
            OnStart();
        }

        private async void OnStart()
        {
            await Task.Run(() => WaitForConnection());

            OnStart();
        }

        private void WaitForConnection()
        {
            var serverStream = new NamedPipeServerStream(PipeName, PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message);

            serverStream.WaitForConnection();

            ClientIsConnected(serverStream);
        }

        private void ClientIsConnected(NamedPipeServerStream serverStream)
        {
            var connection = new Connection(serverStream);
            connection.OnMessage.Subscribe(OnMessageArrived);

            connections.Add(connection);
        }

        private void OnMessageArrived(Message message)
        {
            onMessage.OnNext(message);
        }
    }
}
