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

        string puzzelTip = " ";

        public void Updater()
        {
            core.RoomButton(RoomManager.RoomStatus.Room2, 1220, 0, 60, 60);
            core.room1.PuzzelSolved = true;

            ClickPuzzel(360, 70, 200);

        }

        public void Painter()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    GAME_ENGINE.DrawBitmap(core.m_PuzzelGoat, 360 + (200 * x), 70 + (200 * y), 200 * x, 200 * y, 200, 200);
                    GAME_ENGINE.DrawRectangle(360 + (200 * x), 70 + (200 * y), 200, 200, 2);
                }
            }

            GAME_ENGINE.DrawString(puzzelTip, 840, 0, 100, 50);
        }

        void ClickPuzzel(int startX, int startY, int size)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (core.m_MousePosition.X > startX + (size * x) && core.m_MousePosition.X < startX + size + (size * x))
                    {
                        if (core.m_MousePosition.Y > startY + (size * y) && core.m_MousePosition.Y < startY + size + (size * y))
                        {
                            if (GAME_ENGINE.GetMouseButtonDown(0))
                            {
                                puzzelTip = "Click rechts boven in je scherm!";
                            }
                        }
                    }
                }
            }
        }
    }
}
