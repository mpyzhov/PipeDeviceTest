using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Objects
{
    public enum ObjectType
    {
        Regular,   
        Irregular
    }

    public class GeneralObject
    {
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ObjectType Type { get; set; }

        public int Value { get; set; }
    }
}
