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

        private enum m_CurserState
        {
            FreeState = 0,
            ClickState
        }
        private m_CurserState activeCurserState;

        private int curserPixelSize = 40;

        public void CurserSwitchState()
        {
            if (GAME_ENGINE.GetMouseButton(0))
            {
                activeCurserState = m_CurserState.ClickState;
            }
            else
            {
                activeCurserState = m_CurserState.FreeState;
            }
        }

        public void ShowCurser()
        {
            switch (activeCurserState)
            {
                case m_CurserState.FreeState:
                    GAME_ENGINE.DrawBitmap(core.m_CurserFree, core.m_MousePosition.X - (curserPixelSize / 2), core.m_MousePosition.Y - (curserPixelSize / 2));
                    break;
                case m_CurserState.ClickState:
                    GAME_ENGINE.DrawBitmap(core.m_CurserClick, core.m_MousePosition.X - (curserPixelSize / 2), core.m_MousePosition.Y - (curserPixelSize / 2));
                    break;
                default:
                    break;
            }
        }
    }
}
