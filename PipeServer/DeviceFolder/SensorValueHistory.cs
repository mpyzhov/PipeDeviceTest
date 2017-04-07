using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    public class SensorValueHistory<T>
    {
        private const int maxValue = 50;

        private LinkedList<T> list = new LinkedList<T>();

        public void Push(T value)
        {
            list.AddFirst(value);

            if (list.Count > maxValue)
            {
                list.RemoveLast();
            }
        }

        public T GetCurrentValue()
        {
            return list.FirstOrDefault();
        }

        public IEnumerable<T> GetHistory()
        {
            return list.AsEnumerable();
        }
    }
}
