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
            core.startGameButton.SetActive(false);
            core.exitGameButton.SetActive(false);
            core.manager.SetRoom(RoomManager.RoomStatus.Dialog); //Dialog
        }

        public void ExitGame()
        {
            GAME_ENGINE.Quit();
        }

        public void CreateFlameAnimation()
        {
            core.m_FlameControlTimer += GAME_ENGINE.GetDeltaTime();

            if (core.m_FlameControlTimer > (1f / core.m_FlameFPS))
            {
                if (core.flameTik == 0)
                {
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame1, 0, 0);
                }
                else if (core.flameTik == 1)
                {
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame2, 0, 0);
                }
                else if (core.flameTik == 2)
                {
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame3, 0, 0);
                }

                if (core.flameTik >= 2)
                    core.flameTik = 0;
                else
                    core.flameTik++;
            }
        }
    }

}
