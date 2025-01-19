using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assets.Develop.CommonServices.DataManagment
{
    public class JsonSerializer : IDataSerializer
    {
        public TData Deserialize<TData>(string serializedData)
        {
            return JsonConvert.DeserializeObject<TData>(serializedData);
        }

        public string Serialize<TData>(TData data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}
