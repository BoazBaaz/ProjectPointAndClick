using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Puzzel : GameObject
    {
        private GameCore core;

        public Puzzel(GameCore c)
        {
            core = c;
        }

        public void Updater()
        {
            core.RoomButton(RoomManager.RoomStatus.Room2, 1220, 0, 60, 60);
            core.room1.PuzzelSolved = true;
        }

        public void Painter()
        {
            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 360, 70, 0, 0, 200, 200); //1
            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 560, 70, 200, 0, 200, 200); //2
            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 760, 70, 400, 0, 200, 200); //3

            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 360, 270, 0, 200, 200, 200); //4
            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 560, 270, 200, 200, 200, 200); //5
            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 760, 270, 400, 200, 200, 200); //6

            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 360, 470, 0, 400, 200, 200); //7
            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 560, 470, 200, 400, 200, 200); //8
            GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 760, 470, 400, 400, 200, 200); //9
        }

    }
}
