using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class MainMenu : GameObject
    {
        private GameCore core;

        public MainMenu(GameCore c)
        {
            core = c;
        }


        public void Updater()
        {

        }

        public void Painter()
        {
            
        }

        public void StartGame()
        {
            core.m_StartGameButton.SetActive(false);
            core.m_StopGameButton.SetActive(false);
            core.manager.SetRoom(RoomManager.RoomStatus.Dialog); //Dialog
        }

        public void StopGame()
        {
            GAME_ENGINE.Quit();
        }
    }

}
