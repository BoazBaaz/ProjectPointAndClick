using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameEngine
{
    public class GameCore : AbstractGame
    {
        //Huge thx to Steven from 1GD2 for helping me with teh roommanager and the inventory.

        //Classes
        public Curser curser;
        public BackgroundDialog dialog;
        public EndGameScreen end;
        public InventoryManager invmenager;
        public MainMenu main;
        public Room1 room1;
        public Room2 room2;
        public Room3 room3;
        public Room4 room4;
        public RoomManager manager;
        public SettingsMenu settings;

        //Bitmap
        public Bitmap m_CurserFree = null;
        public Bitmap m_CurserClick = null;
        public Bitmap m_FireFrame1 = null;
        public Bitmap m_FireFrame2 = null;
        public Bitmap m_FireFrame3 = null;
        public Bitmap m_GearActive = null;
        public Bitmap m_GearInActive = null;
        public Bitmap m_Room1Bitmap = null;
        public Bitmap m_Room2Bitmap = null;
        public Bitmap m_Room3Bitmap = null;
        public Bitmap m_Room4Bitmap = null;
        public Bitmap m_SettingsMenuInterface = null;
        public Bitmap m_SettingsMenuVolume1 = null;
        public Bitmap m_SettingsMenuVolume2 = null;
        public Bitmap m_SettingsMenuVolume3 = null;
        public Bitmap m_SettingsMenuVolumeMute = null;
        public Bitmap m_SettingsMenuVolumePin = null;
        public Bitmap m_StartScreen = null;
        public Bitmap m_StartScreenButton = null;
        public Bitmap m_TestBread = null;
        public Bitmap m_TestMatches = null;

        //Button
        public Button startGameButton = null;
        public Button exitGameButton = null;
        public Button settingsButton = null;
        public Button m_StaticSettingsButton = null;

        //Items
        public Items m_Bread;
        public Items m_Matches;

        //Mouselocation
        public Vector2 m_MousePosition = new Vector2();

        public override void GameStart()
        {
            //Classes
            Cursor.Hide();
            curser = new Curser(this);
            dialog = new BackgroundDialog(this);
            end = new EndGameScreen(this);
            invmenager = new InventoryManager(this);
            main = new MainMenu(this);
            room1 = new Room1(this);
            room2 = new Room2(this);
            room3 = new Room3(this);
            room4 = new Room4(this);
            manager = new RoomManager(this);
            settings = new SettingsMenu(this);

            //Bitmaps
            m_CurserFree = new Bitmap("cursertest1.png");
            m_CurserClick = new Bitmap("cursertest2.png");
            m_FireFrame1 = new Bitmap("fire_frame1.png");
            m_FireFrame2 = new Bitmap("fire_frame2.png");
            m_FireFrame3 = new Bitmap("fire_frame3.png");
            m_GearActive = new Bitmap("gear_active.png");
            m_GearInActive = new Bitmap("gear_inactive.png");
            m_Room1Bitmap = new Bitmap("rough_sketch_mainroom.png");
            m_Room2Bitmap = new Bitmap("rough_sketch_basement.png");
            m_Room3Bitmap = new Bitmap("rough_sketch_summoning_room.png");
            m_Room4Bitmap = new Bitmap("rough_sketch_garden.png");
            m_SettingsMenuInterface = new Bitmap("settings_menu_interface.png");
            m_SettingsMenuVolume1 = new Bitmap("settings_menu_volume_1.png");
            m_SettingsMenuVolume2 = new Bitmap("settings_menu_volume_2.png");
            m_SettingsMenuVolume3 = new Bitmap("settings_menu_volume_3.png");
            m_SettingsMenuVolumeMute = new Bitmap("settings_menu_volume_mute.png");
            m_SettingsMenuVolumePin = new Bitmap("settings_menu_volume_pin.png");
            m_StartScreen = new Bitmap("start_screen.png");
            m_StartScreenButton = new Bitmap("start_screen_play.png");
            m_TestBread = new Bitmap("test_bread.png");
            m_TestMatches = new Bitmap("test_matches.png");

            //Buttons
            startGameButton = new Button(main.StartGame, " ", 525, 380, 285, 80);
            startGameButton.SetBitmap(m_StartScreenButton);

            exitGameButton = new Button(main.ExitGame, " ", 345, 525, 285, 85);
            //exitGameButton.SetBitmap(m_Start_Exit_Button);

            settingsButton = new Button(settings.GoToSettings, " ", 705, 525, 285, 85);
            //settingsButton.SetBitmap(m_Start_Exit_Button);

            m_StaticSettingsButton = new Button(settings.GoToSettings, " ", 10, 10, 60, 60);
            m_StaticSettingsButton.SetBitmap(m_GearInActive);

            //Items
            m_Bread = new Items(Items.itemNames.Bread, Items.itemKinds.material, m_TestBread);
            m_Matches = new Items(Items.itemNames.Matches, Items.itemKinds.material, m_TestMatches);
        }

        public override void GameEnd()
        {
            m_CurserFree.Dispose();
            m_CurserClick.Dispose();
            m_FireFrame1.Dispose();
            m_FireFrame2.Dispose();
            m_FireFrame3.Dispose();
            m_GearActive.Dispose();
            m_GearInActive.Dispose();
            m_Room1Bitmap.Dispose();
            m_Room2Bitmap.Dispose();
            m_Room3Bitmap.Dispose();
            m_Room4Bitmap.Dispose();
            m_SettingsMenuInterface.Dispose();
            m_SettingsMenuVolume1.Dispose();
            m_SettingsMenuVolume2.Dispose();
            m_SettingsMenuVolume3.Dispose();
            m_SettingsMenuVolumeMute.Dispose();
            m_SettingsMenuVolumePin.Dispose();
            m_StartScreen.Dispose();
            m_StartScreenButton.Dispose();
            m_TestBread.Dispose();
            m_StartScreen.Dispose();
        }

        public override void Update()
        {
            Vector2 tempMouseLoc = GAME_ENGINE.GetMousePosition();

            m_MousePosition.X = tempMouseLoc.X;
            m_MousePosition.Y = tempMouseLoc.Y;

            curser.CurserSwitchState();
            manager.MainUpdater();
        }

        public override void Paint()
        {
            manager.DrawBackground();
            manager.DrawRoomStatus();
            manager.MainPainter();

            GAME_ENGINE.DrawBitmap(m_GearActive, 10, 10);

            curser.ShowCurser();
        }



        //VERYIMPORTANT
        #region RoomButton
        public void RoomButton(RoomManager.RoomStatus roomInput, int x, int y, int width, int height)
        {
            if (m_MousePosition.X > x && m_MousePosition.X < x + width)
            {
                if (m_MousePosition.Y > y && m_MousePosition.Y < y + height)
                {
                    if (GAME_ENGINE.GetMouseButtonDown(0))
                    {
                        manager.SetRoom(roomInput);
                    }
                }
            }
        }

        public void DrawRoomButton(int x, int y, int width, int height)
        {
            //TestLines
            GAME_ENGINE.SetColor(Color.Green);
            GAME_ENGINE.DrawRectangle(x, y, width, height, 3);
        }
        #endregion
        #region ItemButton
        public void ItemButton(Items item, int x, int y, int width, int height)
        {
            if (m_MousePosition.X > x && m_MousePosition.X < x + width)
            {
                if (m_MousePosition.Y > y && m_MousePosition.Y < y + height)
                {
                    if (GAME_ENGINE.GetMouseButtonDown(0))
                    {
                        if (item.isClicked == false)
                        {
                            invmenager.AddItemToInventory(item);
                            item.isClicked = true;
                        }
                    }
                }
            }
        }

        public void DrawItemButton(int x, int y, int width, int height)
        {
            GAME_ENGINE.SetColor(Color.Cyan);
            GAME_ENGINE.DrawRectangle(x, y, width, height, 2);
        }
        #endregion
    }
}
