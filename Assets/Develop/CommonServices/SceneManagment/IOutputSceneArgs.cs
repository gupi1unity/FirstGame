﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public interface IOutputSceneArgs
    {
        IInputSceneArgs NextSceneInputArgs { get; }
    }
}
