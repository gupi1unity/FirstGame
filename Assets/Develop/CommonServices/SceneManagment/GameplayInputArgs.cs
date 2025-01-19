using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public string LevelName { get; }

        public GameplayInputArgs(string levelName)
        {
            LevelName = levelName;
        }
    }
}
