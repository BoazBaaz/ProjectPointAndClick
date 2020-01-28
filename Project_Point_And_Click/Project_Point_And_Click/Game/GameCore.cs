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
        //Huge thx to Steven from 1GD2 for helping me with the roommanager and the inventory.

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
        public Bitmap m_Amulet = null;
        public Bitmap m_Room1Bitmap = null;
        public Bitmap m_Room2Bitmap = null;
        public Bitmap m_Room2Bitmap2 = null;
        public Bitmap m_Room3Bitmap = null;
        public Bitmap m_Room4Bitmap = null;
        public Bitmap m_BlackScreen = null;
        public Bitmap m_CurserFree = null;
        public Bitmap m_CurserClick = null;
        public Bitmap m_DeathScreen = null;
        public Bitmap m_FireFrame1 = null;
        public Bitmap m_FireFrame2 = null;
        public Bitmap m_FireFrame3 = null;
        public Bitmap m_Gear = null;
        public Bitmap m_ItemBread = null;
        public Bitmap m_ItemCage = null;
        public Bitmap m_ItemCandleLit = null;
        public Bitmap m_ItemCandleNotlit = null;
        public Bitmap m_ItemKnife = null;
        public Bitmap m_ItemMatches = null;
        public Bitmap m_ItemPuzzel = null;
        public Bitmap m_ItemRabbitAlive = null;
        public Bitmap m_ItemRabbitDead = null;
        public Bitmap m_StartScreen = null;
        public Bitmap m_StartButton = null;
        public Bitmap m_ExitButton = null;
        public Bitmap m_PuzzelGoat = null;
        public Bitmap m_SettingsMenuInterface = null;
        public Bitmap m_SettingsMenuVolume1 = null;
        public Bitmap m_SettingsMenuVolume2 = null;
        public Bitmap m_SettingsMenuVolume3 = null;
        public Bitmap m_SettingsMenuVolumeMute = null;
        public Bitmap m_SettingsMenuVolumePin = null;
        public Bitmap m_SettingsButton = null;

        //Items
        public Items m_Bread;
        public Items m_Cage;
        public Items m_CandleLit;
        public Items m_CandleNotLit;
        public Items m_Knife;
        public Items m_Matches;
        public Items m_PuzzelPiece;
        public Items m_RabbitAlive;
        public Items m_RabbitDead;

        //Mouselocation
        public Vector2 m_MousePosition = new Vector2();

        public bool m_AmuletActive = false;

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
            m_Amulet = new Bitmap("amulet.png");
            m_Room1Bitmap = new Bitmap("background_mainroom.png");
            m_Room2Bitmap = new Bitmap("background_basement_dark.png");
            m_Room2Bitmap2 = new Bitmap("backround_basement_clear.png");
            m_Room3Bitmap = new Bitmap("background_summoningroom.png");
            m_Room4Bitmap = new Bitmap("background_garden.png");
            m_CurserFree = new Bitmap("curser_1.png");
            m_CurserClick = new Bitmap("curser_2.png");
            m_DeathScreen = new Bitmap("death_screen.png");
            m_FireFrame1 = new Bitmap("fire_frame1.png");
            m_FireFrame2 = new Bitmap("fire_frame2.png");
            m_FireFrame3 = new Bitmap("fire_frame3.png");
            m_Gear = new Bitmap("gear.png");
            m_ItemBread = new Bitmap("item_bread.png");
            m_ItemCage = new Bitmap("item_cage.png");
            m_ItemCandleLit = new Bitmap("item_candle_lit.png");
            m_ItemCandleNotlit = new Bitmap("item_candle_notlit.png");
            m_ItemKnife = new Bitmap("item_knife.png");
            m_ItemMatches = new Bitmap("item_matches.png");
            m_ItemPuzzel = new Bitmap("item_puzzel.png");
            m_ItemRabbitAlive = new Bitmap("item_rabbit_alive.png");
            m_ItemRabbitDead = new Bitmap("item_rabbit_dead.png");
            m_StartButton = new Bitmap("mainscreen_play_button.png");
            m_SettingsButton = new Bitmap("mainscreen_options_button.png");
            m_ExitButton = new Bitmap("mainscreen_exit_button.png");
            m_PuzzelGoat = new Bitmap("puzzel_goat.png");
            m_SettingsMenuInterface = new Bitmap("settings_menu_interface.png");
            m_SettingsMenuVolume1 = new Bitmap("settings_menu_volume_1.png");
            m_SettingsMenuVolume2 = new Bitmap("settings_menu_volume_2.png");
            m_SettingsMenuVolume3 = new Bitmap("settings_menu_volume_3.png");
            m_SettingsMenuVolumeMute = new Bitmap("settings_menu_volume_mute.png");
            m_SettingsMenuVolumePin = new Bitmap("settings_menu_volume_pin.png");
            m_StartScreen = new Bitmap("start_screen.png");

            //FlameAnimation
            main.m_FlameAnimation[0] = m_FireFrame1;
            main.m_FlameAnimation[1] = m_FireFrame2;
            main.m_FlameAnimation[2] = m_FireFrame3;

            //Items
            m_Bread = new Items(Items.itemNames.Bread, Items.itemKinds.material, m_ItemBread);
            m_Cage = new Items(Items.itemNames.Cage, Items.itemKinds.material, m_ItemCage);
            m_CandleLit = new Items(Items.itemNames.Candlelit, Items.itemKinds.questItem, m_ItemCandleLit);
            m_CandleNotLit = new Items(Items.itemNames.Candle, Items.itemKinds.material, m_ItemCandleNotlit);
            m_Knife = new Items(Items.itemNames.Knife, Items.itemKinds.material, m_ItemKnife);
            m_Matches = new Items(Items.itemNames.Matches, Items.itemKinds.material, m_ItemMatches);
            m_PuzzelPiece = new Items(Items.itemNames.Puzzel, Items.itemKinds.questItem, m_ItemPuzzel);
            m_RabbitAlive = new Items(Items.itemNames.RabbitAlive, Items.itemKinds.material, m_ItemRabbitAlive);
            m_RabbitDead = new Items(Items.itemNames.RabbitDead, Items.itemKinds.questItem, m_ItemRabbitDead);
        }

        public override void GameEnd()
        {
            m_Amulet.Dispose();
            m_Room1Bitmap.Dispose();
            m_Room2Bitmap.Dispose();
            m_Room2Bitmap2.Dispose();
            m_Room3Bitmap.Dispose();
            m_Room4Bitmap.Dispose();
            m_CurserFree.Dispose();
            m_CurserClick.Dispose();
            m_DeathScreen.Dispose();
            m_FireFrame1.Dispose();
            m_FireFrame2.Dispose();
            m_FireFrame3.Dispose();
            m_Gear.Dispose();
            m_ItemBread.Dispose();
            m_ItemCage.Dispose();
            m_ItemCandleLit.Dispose();
            m_ItemCandleNotlit.Dispose();
            m_ItemKnife.Dispose();
            m_ItemMatches.Dispose();
            m_ItemPuzzel.Dispose();
            m_ItemRabbitAlive.Dispose();
            m_ItemRabbitDead.Dispose();
            m_StartButton.Dispose();
            m_SettingsButton.Dispose();
            m_ExitButton.Dispose();
            m_PuzzelGoat.Dispose();
            m_SettingsMenuInterface.Dispose();
            m_SettingsMenuVolume1.Dispose();
            m_SettingsMenuVolume2.Dispose();
            m_SettingsMenuVolume3.Dispose();
            m_SettingsMenuVolumeMute.Dispose();
            m_SettingsMenuVolumePin.Dispose();
            m_StartScreen.Dispose();
        }

        public override void Update()
        {
            m_MousePosition = GAME_ENGINE.GetMousePosition();

            if (GAME_ENGINE.GetKeyDown(Key.E))
            {
                if (!m_AmuletActive)
                    m_AmuletActive = true;
                else
                    m_AmuletActive = false;
            }

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
            if (roomInput == RoomManager.RoomStatus.MainMenu)
            {
                invmenager.ClearInventory();
            }

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
