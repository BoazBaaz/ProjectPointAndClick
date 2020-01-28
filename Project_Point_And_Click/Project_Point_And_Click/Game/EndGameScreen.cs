using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class EndGameScreen : GameObject
    {
        private GameCore core;

        public EndGameScreen(GameCore c)
        {
            core = c;
        }

        public void Updater()
        {
            core.RoomButton(RoomManager.RoomStatus.MainMenu, 217, 462, 401, 167);
            core.FunctionButton(GameCore.m_Functions.exit, 732, 462, 400, 167);
        }

        public void Painter()
        {
            
        }

    }
}
