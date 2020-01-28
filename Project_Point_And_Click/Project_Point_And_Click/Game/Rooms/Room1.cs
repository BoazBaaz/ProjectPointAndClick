using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Room1 : GameObject
    {
        private GameCore core;

        public Room1(GameCore c)
        {
            core = c;
        }

        public bool PuzzelSolved = false;

        public void Updater()
        {
            if (!PuzzelSolved)
                core.RoomButton(RoomManager.RoomStatus.Puzzel, 680, 470, 130, 75);
            else
                core.RoomButton(RoomManager.RoomStatus.Room2, 680, 470, 130, 75);
            core.RoomButton(RoomManager.RoomStatus.Room3, 280, 105, 80, 360);
            core.RoomButton(RoomManager.RoomStatus.Room4, 1080, 20, 180, 380);
            core.ItemButton(core.m_Bread, 410, 290, 70, 40);
            core.ItemButton(core.m_CandleNotLit, 640, 290, 70, 80);
            core.ItemButton(core.m_Matches, 230, 380, 50, 50);
        }

        public void Painter()
        {
            #region CanDeleteSoon
            //Doors
            core.DrawRoomButton(280, 105, 80, 360);
            core.DrawRoomButton(680, 470, 130, 85);
            core.DrawRoomButton(1080, 20, 180, 380);
            //Items
            core.DrawItemButton(core.m_Bread, 410, 290, 70, 40);
            core.DrawItemButton(core.m_CandleNotLit, 640, 290, 70, 80);
            core.DrawItemButton(core.m_Matches, 230, 380, 50, 50);
            //Amulet
            //GAME_ENGINE.DrawBitmap(core.m_AmuletActive)
            #endregion 
        }

    }
}
