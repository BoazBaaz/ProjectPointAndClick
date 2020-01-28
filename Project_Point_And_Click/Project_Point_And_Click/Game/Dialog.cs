using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class BackgroundDialog : GameObject
    {
        private GameCore core;

        public BackgroundDialog(GameCore c)
        {
            core = c;
        }

        private float m_FPS = 1f;
        private float m_ControlTimer = 0f;

        private int totalSeconds = 0;

        public void Updater()
        {
            m_ControlTimer += GAME_ENGINE.GetDeltaTime();

            if (m_ControlTimer > (1f / m_FPS))
            {

                totalSeconds++;

                m_ControlTimer = 0;
            }
        }

        public void Painter()
        {
            if (totalSeconds < 2)
            {
                GAME_ENGINE.DrawBitmap(core.m_Cutscene1, 0, 0);
            }
            else if (totalSeconds < 4)
            {
                GAME_ENGINE.DrawBitmap(core.m_Cutscene2, 0, 0);
            }
            else if (totalSeconds < 5)
            {
                GAME_ENGINE.DrawBitmap(core.m_Cutscene3, 0, 0);
            }
            else if (totalSeconds < 7)
            {
                GAME_ENGINE.DrawBitmap(core.m_Cutscene4, 0, 0);
            }
            else
            {
                core.manager.SetRoom(RoomManager.RoomStatus.Room1);
            }
        }
    }
}
