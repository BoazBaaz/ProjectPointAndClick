﻿using System;
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
            CreateButtons();

            FlameTimer();
        }

        public void Painter()
        {
            FlameAnimation();

            PaintButtons();
        }

        private void CreateButtons()
        {
            core.FunctionButton(GameCore.m_Functions.start, 505, 370, 330, 105);

            core.FunctionButton(GameCore.m_Functions.exit, 325, 515, 330, 105);

            core.FunctionButton(GameCore.m_Functions.settings, 685, 515, 330, 105);
        }

        private void PaintButtons()
        {
            core.DrawFunctionButton(GameCore.m_Functions.start, 505, 370, 330, 105);

            core.DrawFunctionButton(GameCore.m_Functions.exit, 325, 515, 330, 105);

            core.DrawFunctionButton(GameCore.m_Functions.settings, 685, 515, 330, 105);
        }

        public void StartGame()
        {
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
