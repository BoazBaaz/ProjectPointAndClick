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
        public Puzzel puzzel;
        public RoomManager manager;
        public SettingsMenu settings;

        //Bitmap
        public Bitmap m_CurserFree = null;
        public Bitmap m_CurserClick = null;
        public Bitmap m_FireFrame1 = null;
        public Bitmap m_FireFrame2 = null;
        public Bitmap m_FireFrame3 = null;
        public Bitmap m_Gear = null;
        public Bitmap m_StartScreen = null;
        public Bitmap m_StartButton = null;
        public Bitmap m_ExitButton = null;
        public Bitmap m_Puzzel1 = null;
        public Bitmap m_Puzzel2 = null;
        public Bitmap m_Puzzel3 = null;
        public Bitmap m_Puzzel4 = null;
        public Bitmap m_Puzzel5 = null;
        public Bitmap m_Puzzel6 = null;
        public Bitmap m_Puzzel7 = null;
        public Bitmap m_Puzzel8 = null;
        public Bitmap m_Puzzel9 = null;
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
        public Bitmap m_SettingsButton = null;
        public Bitmap m_TestBread = null;
        public Bitmap m_TestMatches = null;

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
            puzzel = new Puzzel(this);
            manager = new RoomManager(this);
            settings = new SettingsMenu(this);

            //Bitmaps
            m_CurserFree = new Bitmap("cursertest1.png");
            m_CurserClick = new Bitmap("cursertest2.png");
            m_FireFrame1 = new Bitmap("fire_frame1.png");
            m_FireFrame2 = new Bitmap("fire_frame2.png");
            m_FireFrame3 = new Bitmap("fire_frame3.png");
            m_Gear = new Bitmap("gear.png");
            m_StartButton = new Bitmap("mainscreen_play_button.png");
            m_SettingsButton = new Bitmap("mainscreen_options_button.png");
            m_ExitButton = new Bitmap("mainscreen_exit_button.png");
            m_Puzzel1 = new Bitmap("puzzel1.png");
            m_Puzzel2 = new Bitmap("puzzel2.png");
            m_Puzzel3 = new Bitmap("puzzel3.png");
            m_Puzzel4 = new Bitmap("puzzel4.png");
            m_Puzzel5 = new Bitmap("puzzel5.png");
            m_Puzzel6 = new Bitmap("puzzel6.png");
            m_Puzzel7 = new Bitmap("puzzel7.png");
            m_Puzzel8 = new Bitmap("puzzel8.png");
            m_Puzzel9 = new Bitmap("puzzel9.png");
            m_Room2Bitmap = new Bitmap("rough_sketch_basement.png");
            m_Room4Bitmap = new Bitmap("background_garden.png");
            m_Room1Bitmap = new Bitmap("rough_sketch_mainroom.png");
            m_Room3Bitmap = new Bitmap("rough_sketch_summoning_room.png");
            m_SettingsMenuInterface = new Bitmap("settings_menu_interface.png");
            m_SettingsMenuVolume1 = new Bitmap("settings_menu_volume_1.png");
            m_SettingsMenuVolume2 = new Bitmap("settings_menu_volume_2.png");
            m_SettingsMenuVolume3 = new Bitmap("settings_menu_volume_3.png");
            m_SettingsMenuVolumeMute = new Bitmap("settings_menu_volume_mute.png");
            m_SettingsMenuVolumePin = new Bitmap("settings_menu_volume_pin.png");
            m_StartScreen = new Bitmap("start_screen.png");
            m_TestBread = new Bitmap("test_bread.png");
            m_TestMatches = new Bitmap("test_matches.png");

            //FlameAnimation
            main.m_FlameAnimation[0] = m_FireFrame1;
            main.m_FlameAnimation[1] = m_FireFrame2;
            main.m_FlameAnimation[2] = m_FireFrame3;

            //PuzzelBitmaps
            puzzel.puzzelBitmaps[1] = m_Puzzel1;
            puzzel.puzzelBitmaps[2] = m_Puzzel2;
            puzzel.puzzelBitmaps[3] = m_Puzzel3;
            puzzel.puzzelBitmaps[4] = m_Puzzel4;
            puzzel.puzzelBitmaps[5] = m_Puzzel5;
            puzzel.puzzelBitmaps[6] = m_Puzzel6;
            puzzel.puzzelBitmaps[7] = m_Puzzel7;
            puzzel.puzzelBitmaps[8] = m_Puzzel8;
            puzzel.puzzelBitmaps[9] = m_Puzzel9;

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
            m_Gear.Dispose();
            m_StartButton.Dispose();
            m_SettingsButton.Dispose();
            m_ExitButton.Dispose();
            m_Puzzel1.Dispose();
            m_Puzzel2.Dispose();
            m_Puzzel3.Dispose();
            m_Puzzel4.Dispose();
            m_Puzzel5.Dispose();
            m_Puzzel6.Dispose();
            m_Puzzel7.Dispose();
            m_Puzzel8.Dispose();
            m_Puzzel9.Dispose();
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
            m_TestBread.Dispose();
            m_StartScreen.Dispose();
        }

        public override void Update()
        {
            m_MousePosition = GAME_ENGINE.GetMousePosition();

            curser.CurserSwitchState();
            manager.MainUpdater();
        }

        public override void Paint()
        {
            manager.DrawBackground();
            manager.DrawRoomStatus();
            manager.MainPainter();

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

        public void DrawItemButton(Items item, int x, int y, int width, int height)
        {
            if (!item.isClicked)
            {
                switch (item.name)
                {
                    case Items.itemNames.Bread:
                        GAME_ENGINE.DrawBitmap(m_TestBread, x, y);
                        break;
                    case Items.itemNames.Matches:
                        GAME_ENGINE.DrawBitmap(m_TestMatches, x, y);
                        break;
                    case Items.itemNames.Candle:
                        break;
                    case Items.itemNames.Puzzel:
                        break;
                    case Items.itemNames.Rabbit:
                        break;
                    case Items.itemNames.Cage:
                        break;
                    default:
                        break;
                }
            }

            GAME_ENGINE.SetColor(Color.Cyan);
            GAME_ENGINE.DrawRectangle(x, y, width, height, 2);
        }
        #endregion
        #region FunctionButton
        public enum m_Functions
        {
            start = 0,
            exit,
            settings,
            gear,
            empty
        }

        public void FunctionButton(m_Functions functions, int x, int y, int width, int height)
        {
            if (m_MousePosition.X > x && m_MousePosition.X < x + width)
            {
                if (m_MousePosition.Y > y && m_MousePosition.Y < y + height)
                {
                    if (GAME_ENGINE.GetMouseButtonUp(0))
                    {
                        switch (functions)
                        {
                            case m_Functions.start:
                                main.StartGame();
                                break;
                            case m_Functions.exit:
                                main.ExitGame();
                                break;
                            case m_Functions.settings:
                                settings.GoToSettings();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void DrawFunctionButton(m_Functions functions, int x, int y, int width, int height)
        {
            GAME_ENGINE.SetColor(Color.Magenta);

            GAME_ENGINE.DrawRectangle(x, y, width, height, 2);

            switch (functions)
            {
                case m_Functions.start:
                    GAME_ENGINE.DrawBitmap(m_StartButton, x, y);
                    break;
                case m_Functions.exit:
                    GAME_ENGINE.DrawBitmap(m_ExitButton, x, y);
                    break;
                case m_Functions.settings:
                    GAME_ENGINE.DrawBitmap(m_SettingsButton, x, y);
                    break;
                case m_Functions.gear:
                    GAME_ENGINE.DrawBitmap(m_Gear, x, y);
                    break;
                case m_Functions.empty:
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
