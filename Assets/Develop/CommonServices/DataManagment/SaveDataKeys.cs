using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.DataManagment
{
    public static class SaveDataKeys
    {
        private static Dictionary<Type, string> Keys = new Dictionary<Type, string>();

        public static string GetKeyFor<TData>() where TData : ISaveData
        {
            return Keys[typeof(TData)];
        }
    }
}
