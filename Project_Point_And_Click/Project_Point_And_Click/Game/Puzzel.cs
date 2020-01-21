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
            //l++;

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int u = 0; u < 3; u++)
            //    {
            //        GAME_ENGINE.DrawBitmap(puzzelBitmaps[l], 340 * u, 120 * i);
            //    }
            //}
        }

    }
}
