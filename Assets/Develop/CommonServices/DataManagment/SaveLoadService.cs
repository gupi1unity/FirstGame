﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;

namespace Assets.Develop.CommonServices.DataManagment
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IDataSerializer _serializer;
        private readonly IDataRepository _repository;

        public SaveLoadService(IDataSerializer serializer, IDataRepository repository)
        {
            _serializer = serializer;
            _repository = repository;
        }

        public void Save<TData>(TData data) where TData : ISaveData
        {
            string serializedData = _serializer.Serialize(data);

            _repository.Write(SaveDataKeys.GetKeyFor<TData>(), serializedData);
        }

        public bool TryLoad<TData>(out TData data) where TData : ISaveData
        {
            string key = SaveDataKeys.GetKeyFor<TData>();

            if (_repository.Exists(key) == false)
            {
                data = default(TData);
                return false;
            }

            string serializedData = _repository.Read(key);
            data = _serializer.Deserialize<TData>(serializedData);
            return true;
        }
    }
}
