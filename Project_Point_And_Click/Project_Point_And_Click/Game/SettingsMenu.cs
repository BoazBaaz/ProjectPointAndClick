using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class SettingsMenu : GameObject
    {
        private GameCore core;
        public SettingsMenu(GameCore c)
        {
            core = c;
        }

        public void Updater()
        {

        }

        public void Painter()
        {

        }

        public void GoToSettings()
        {
            if (core.manager.SettingsStatus == false)
            {
                core.manager.SaveLoadLastRoom();
                core.manager.SettingsSwitchOnOff();
                core.manager.SetRoom(RoomManager.RoomStatus.Settings);
            }
            else if (core.manager.SettingsStatus == true)
            {
                core.manager.SaveLoadLastRoom();
                core.manager.SettingsSwitchOnOff();
            }
        }
    }
}
