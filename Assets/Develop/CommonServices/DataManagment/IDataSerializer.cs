using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.DataManagment
{
    public interface IDataSerializer
    {
        string Serialize<TData>(TData data);

        TData Deserialize<TData>(string serializedData);
    }
}
