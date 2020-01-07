using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    //Hides the basic setup from the GameCore class.
    public class AbstractGame : GameObject
    {
        public override void GameInitialize()
        {
            // Set the required values
            GAME_ENGINE.SetTitle("Project Point And Click Advanture Game");
            GAME_ENGINE.SetIcon("icon.ico");

            // Set the optional values
            GAME_ENGINE.SetScreenWidth(1280);
            GAME_ENGINE.SetScreenHeight(720);
            GAME_ENGINE.SetBackgroundColor(Color.White);
            //GAME_ENGINE.SetBackgroundColor(49, 77, 121); //The Unity background color
        }
    }
}
