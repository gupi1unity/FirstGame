﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public class OutputGameplayArgs : OutputSceneArgs
    {
        public OutputGameplayArgs(IInputSceneArgs nextSceneInputArgs) : base(nextSceneInputArgs)
        {

        }
    }
}
