using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkService service = new LinkService();
            service.Start();

            Console.WriteLine("Click any button to close...");
            Console.Read();
        }
    }
}
