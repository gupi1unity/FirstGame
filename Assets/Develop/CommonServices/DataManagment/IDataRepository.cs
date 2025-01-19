﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.DataManagment
{
    public interface IDataRepository
    {
        string Read(string key);

        void Write(string key, string serializedData);

        void Remove(string key);

        bool Exists(string key);
    }
}
