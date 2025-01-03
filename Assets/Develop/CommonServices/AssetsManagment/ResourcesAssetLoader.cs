﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Develop.CommonServices.AssetsManagment
{
    public class ResourcesAssetLoader
    {
        public T LoadResource<T>(string resourcePath) where T : Object
        {
            return Resources.Load<T>(resourcePath);
        }
    }
}
