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

        public Bitmap[] puzzelBitmaps = new Bitmap[9];

        private int[,] PuzzelMap = new int[,]
        {
            {1, 2, 3},
            {2, 2, 3},
            {3, 3, 3}
        };


        public void Updater()
        {
            core.RoomButton(RoomManager.RoomStatus.Room2, 1220, 0, 60, 60);
            core.room1.PuzzelSolved = true;

            for (int i = 0; i < 3; i++)
            {
                for (int i = 0; i < 3; i++)
                {

                }
            }
        }

        public void Painter()
        {
            
        }

    }
}
