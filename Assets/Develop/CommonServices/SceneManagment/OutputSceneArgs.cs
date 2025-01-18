using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public abstract class OutputSceneArgs : IOutputSceneArgs
    {
        public IInputSceneArgs NextSceneInputArgs { get; }

        protected OutputSceneArgs(IInputSceneArgs nextSceneInputArgs)
        {
            NextSceneInputArgs = nextSceneInputArgs;
        }
    }
}
