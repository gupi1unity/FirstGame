using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Assets.Develop.CommonServices.DataManagment
{
    public class LocalDataRepository : IDataRepository
    {
        private const string SaveFileExtension = "json";

        private string FolderPath => Application.persistentDataPath;

        public bool Exists(string key)
        {
            return File.Exists(FullPathFor(key));
        }

        public string Read(string key)
        {
            return File.ReadAllText(FullPathFor(key));
        }

        public void Remove(string key)
        {
            File.Delete(FullPathFor(key));
        }

        public void Write(string key, string serializedData)
        {
            File.WriteAllText(FullPathFor(key), serializedData);
        }

        private string FullPathFor(string key)
        {
            return Path.Combine(FolderPath, key) + '.' + SaveFileExtension;
        }
    }
}
