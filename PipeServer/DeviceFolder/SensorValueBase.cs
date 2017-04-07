using Newtonsoft.Json;
using PipeServer.DeviceFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{
    internal abstract class SensorValueBase<T> : SensorBase, ISensorValue
    {

        private readonly SensorValueHistory<T> history = new SensorValueHistory<T>();

        protected SensorValueBase(string id)
            :base(id)
        {
        }

        [JsonProperty("value")]
        public T Value { get { return history.GetCurrentValue(); } }

        public object GetSensorValue()
        {
            return Value;
        }

        public List<object> GetLastSensorValues()
        {
            return history.GetHistory().Cast<object>().ToList();
        }

        public void SetCurrentValue(T value)
        {
            history.Push(value);
        }
    }
}
