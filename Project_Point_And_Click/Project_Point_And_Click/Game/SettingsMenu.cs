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
                if (core.manager.ActiveScene == RoomManager.RoomStatus.MainMenu)
                {
                    core.startGameButton.SetActive(false);
                    core.exitGameButton.SetActive(false);
                    core.settingsButton.SetActive(false);
                }
                core.manager.SaveLoadLastRoom();
                core.manager.SettingsSwitchOnOff();
                core.manager.SetRoom(RoomManager.RoomStatus.Settings);
            }
            else if (core.manager.SettingsStatus == true)
            {
                core.manager.SaveLoadLastRoom();
                core.manager.SettingsSwitchOnOff();
                if (core.manager.ActiveScene == RoomManager.RoomStatus.MainMenu)
                {
                    core.startGameButton.SetActive(true);
                    core.exitGameButton.SetActive(true);
                    core.settingsButton.SetActive(true);
                }
            }
        }
    }
}
