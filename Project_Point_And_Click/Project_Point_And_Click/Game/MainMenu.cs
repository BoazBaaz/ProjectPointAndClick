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

        public void FlameAnimation()
        {
            core.m_FlameControlTimer += GAME_ENGINE.GetDeltaTime();

            if (core.m_FlameControlTimer > (1f / core.m_FlameFPS))
            {
                if (core.ActiveFlame == GameCore.flameState.flame1)
                {
                    core.ActiveFlame = GameCore.flameState.flame2;
                }
                else if (core.ActiveFlame == GameCore.flameState.flame2)
                {
                    core.ActiveFlame = GameCore.flameState.flame3;
                }
                else if (core.ActiveFlame == GameCore.flameState.flame3)
                {
                    core.ActiveFlame = GameCore.flameState.flame1;
                }
                core.m_FlameControlTimer = 0;
            }

            switch (core.ActiveFlame)
            {
                case GameCore.flameState.flame1:
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame1, 0, 0);
                    break;
                case GameCore.flameState.flame2:
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame2, 0, 0);
                    break;
                case GameCore.flameState.flame3:
                    GAME_ENGINE.DrawBitmap(core.m_FireFrame3, 0, 0);
                    break;
                default:
                    break;
            }
        }
    }

}
