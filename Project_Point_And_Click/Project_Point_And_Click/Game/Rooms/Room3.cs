﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Room3 : GameObject
    {
        private GameCore core;

        public Room3(GameCore c)
        {
            core = c;
        }

        public void Updater()
        {
            if (core.m_Bread.isClicked == true)
            {
                if (core.m_CandleNotLit.isClicked == true)
                {
                    if (core.m_Matches.isClicked == true)
                    {
                        core.manager.SetRoom(RoomManager.RoomStatus.Endscreen);
                    }
                }
            }

            core.RoomButton(RoomManager.RoomStatus.Room1, 1055, 25, 225, 625);
        }

        public void Painter()
        {
            #region CanDeleteSoon
            core.DrawRoomButton(1055, 25, 225, 625);
            #endregion
        }

    }
}