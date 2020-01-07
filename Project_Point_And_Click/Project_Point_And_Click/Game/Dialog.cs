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

        public void Updater()
        {
            #region CanDeleteSoon
            core.RoomButton(RoomManager.RoomStatus.Room1, 1220, 00, 50, 50);
            #endregion
        }

        public void Painter()
        {
            #region CanDeleteSoon
            GAME_ENGINE.SetColor(Color.Black);
            GAME_ENGINE.DrawString("Skip", 1230, 10, 50, 50);
            core.DrawRoomButton(1220, 00, 50, 50);
            #endregion
        }
    }
}
