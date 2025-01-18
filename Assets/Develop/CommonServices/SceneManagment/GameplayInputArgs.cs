using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public int LevelNumber { get; }

        public GameplayInputArgs(int levelNumber)
        {
            LevelNumber = levelNumber;
        }
    }
}
