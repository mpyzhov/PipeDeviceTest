using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    public class Message
    {
        private readonly string data;
        private readonly Connection connection;

        public Message(Connection connection, string data)
        {
            this.data = data;
            this.connection = connection;
        }

        public string Data
        {
            get
            {
                return data;
            }
        }

        public Connection Connection
        {
            get
            {
                return connection;
            }
        }
    }
}
