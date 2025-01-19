using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.DataManagment
{
    public interface ISaveLoadService
    {
        bool TryLoad<TData>(out TData data) where TData : ISaveData;

        void Save<TData>(TData data) where TData : ISaveData;
    }
}
