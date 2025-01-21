using Assets.Develop.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Develop.CommonServices.SceneManagment
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public Gamemods Gamemode { get; }

        public GameplayInputArgs(Gamemods gamemode)
        {
            Gamemode = gamemode;
        }
    }
}
