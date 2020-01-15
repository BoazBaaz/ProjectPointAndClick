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


        //FlameAnimation
        private float m_FlameFPS = 5f;
        private float m_FlameControlTimer = 0f;

        private int flameTimer;

        public Bitmap[] m_FlameAnimation = new Bitmap[3];

        public void Updater()
        {
            FlameTimer();
        }

        public void Painter()
        {
            FlameAnimation();
        }

        public void StartGame()
        {
            core.startGameButton.SetActive(false);
            core.exitGameButton.SetActive(false);
            core.settingsButton.SetActive(false);
            core.manager.SetRoom(RoomManager.RoomStatus.Dialog); //Dialog
        }

        public void ExitGame()
        {
            GAME_ENGINE.Quit();
        }

        private void FlameTimer()
        {
            m_FlameControlTimer += GAME_ENGINE.GetDeltaTime();

            if (m_FlameControlTimer > (1f / m_FlameFPS))
            {
                flameTimer++;

                m_FlameControlTimer = 0;
            }


            if (flameTimer >= 3)
                flameTimer = 0;
        }
        public void FlameAnimation()
        {
            GAME_ENGINE.DrawBitmap(m_FlameAnimation[flameTimer], 0, 0);  
        }
    }
}
