using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Room4 : GameObject
    {
        private GameCore core;

        public Room4(GameCore c)
        {
            core = c;
        }

        public void Updater()
        {
            core.RoomButton(RoomManager.RoomStatus.Room1, 140, 50, 220, 240);
        }

        public void Painter()
        {
            #region CanDeleteSoon
            core.DrawRoomButton(140, 50, 220, 230);
            #endregion
        }

    }
}