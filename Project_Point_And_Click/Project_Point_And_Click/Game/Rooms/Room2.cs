using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Room2 : GameObject
    {
        private GameCore core;

        public Room2(GameCore c)
        {
            core = c;
        }

        public void Updater()
        {
            core.RoomButton(RoomManager.RoomStatus.Room1, 1120, 0, 160, 720);
        }

        public void Painter()
        {
            #region CanDeleteSoon
            core.DrawRoomButton(1120, 0, 160, 720);
            #endregion
        }

    }
}