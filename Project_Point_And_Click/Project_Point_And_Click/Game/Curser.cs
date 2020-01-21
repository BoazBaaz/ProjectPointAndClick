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

        private bool curserClickState;

        private int curserPixelSize = 40;

        public void CurserSwitchState()
        {
            if (GAME_ENGINE.GetMouseButton(0))
            {
                curserClickState = true;
            }
            else
            {
                curserClickState = false;
            }
        }

        public void ShowCurser()
        {
            switch (curserClickState)
            {
                case false:
                    GAME_ENGINE.DrawBitmap(core.m_CurserFree, core.m_MousePosition.X - (curserPixelSize / 2), core.m_MousePosition.Y - (curserPixelSize / 2));
                    break;
                case true:
                    GAME_ENGINE.DrawBitmap(core.m_CurserClick, core.m_MousePosition.X - (curserPixelSize / 2), core.m_MousePosition.Y - (curserPixelSize / 2));
                    break;
                default:
                    break;
            }
        }
    }
}
