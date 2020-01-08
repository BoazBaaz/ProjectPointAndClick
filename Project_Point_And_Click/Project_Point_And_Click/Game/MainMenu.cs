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

        private enum flameState : int
        {
            flame1 = 0,
            flame2,
            flame3
        }
        private flameState ActiveFlame;

        public void Updater()
        {

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

        public void FlameAnimation()
        {
            m_FlameControlTimer += GAME_ENGINE.GetDeltaTime();

            if (m_FlameControlTimer > (1f / m_FlameFPS))
            {
                if (ActiveFlame == flameState.flame1)
                {
                    ActiveFlame = flameState.flame2;
                }
                else if (ActiveFlame == flameState.flame2)
                {
                    ActiveFlame = flameState.flame3;
                }
                else if (ActiveFlame == flameState.flame3)
                {
                    ActiveFlame = flameState.flame1;
                }
                m_FlameControlTimer = 0;
            }

            switch (ActiveFlame)
            {
                case flameState.flame1:
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame1, 0, 0);
                    break;
                case flameState.flame2:
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame2, 0, 0);
                    break;
                case flameState.flame3:
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame3, 0, 0);
                    break;
                default:
                    break;
            }
        }
    }

}
