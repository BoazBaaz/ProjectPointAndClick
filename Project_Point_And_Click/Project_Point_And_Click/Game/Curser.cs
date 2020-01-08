using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Curser : GameObject
    {
        private GameCore core;

        public Curser(GameCore c)
        {
            core = c;
        }

        private int curserPixelSize = 40;

        public void DrawCurser()
        {
            GAME_ENGINE.DrawBitmap(core.m_Curser_1, core.m_MousePosition.X - (curserPixelSize / 2), core.m_MousePosition.Y - (curserPixelSize / 2));
        }
    }
}
