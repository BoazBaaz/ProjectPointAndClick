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

        //Deltatime
        public float m_FlameFPS = 1f;
        public float m_FlameControlTimer = 0f;
        public int flameTik = 0;

        //Bitmap
        public Bitmap m_FireFrame1 = null;
        public Bitmap m_FireFrame2 = null;
        public Bitmap m_FireFrame3 = null;
        public Bitmap m_GearActive = null;
        public Bitmap m_GearInActive = null;
        public Bitmap m_Room1Bitmap = null;
        public Bitmap m_Room2Bitmap = null;
        public Bitmap m_Room3Bitmap = null;
        public Bitmap m_Room4Bitmap = null;
        public Bitmap m_StartScreen = null;
        public Bitmap m_Start_Stop_Button = null;
        public Bitmap m_TestBread = null;
        public Bitmap m_TestMatches = null;

        //Button
        public Button m_StartGameButton = null;
        public Button m_StopGameButton = null;
        public Button m_SettingsButton = null;
        public Button m_ToRoom1 = null;
        public Button m_ToRoom2 = null;
        public Button m_ToRoom3 = null;
        public Button m_ToRoom4 = null;

        public Vector2 m_MousePosition = new Vector2();

        public override void GameStart()
        {
            //Classes]
            //Cursor.Hide();
            dialog = new BackgroundDialog(this);
            end = new EndGameScreen(this);
            invmenager = new InventoryManager();
            main = new MainMenu(this);
            room1 = new Room1(this);
            room2 = new Room2(this);
            room3 = new Room3(this);
            room4 = new Room4(this);
            manager = new RoomManager(this);
            settings = new SettingsMenu(this);

            //Bitmaps
            m_FireFrame1 = new Bitmap("fire_frame1.png");
            m_FireFrame2 = new Bitmap("fire_frame2.png");
            m_FireFrame3 = new Bitmap("fire_frame3.png");
            m_GearActive = new Bitmap("gear_active.png");
            m_GearInActive = new Bitmap("gear_inactive.png");
            m_Room1Bitmap = new Bitmap("rough_sketch_mainroom.png");
            m_Room2Bitmap = new Bitmap("rough_sketch_basement.png");
            m_Room3Bitmap = new Bitmap("rough_sketch_summoning_room.png");
            m_Room4Bitmap = new Bitmap("rough_sketch_garden.png");
            m_StartScreen = new Bitmap("start_screen.png");
            m_Start_Stop_Button = new Bitmap("start_stop_button.png");
            m_TestBread = new Bitmap("test_bread.png");
            m_TestMatches = new Bitmap("test_matches.png");

            //Buttons
            m_StartGameButton = new Button(main.StartGame, " ", 525, 380, 285, 80);
            m_StartGameButton.SetBitmap(m_Start_Stop_Button);
            m_StopGameButton = new Button(main.StopGame, " ", 345, 525, 285, 80);
            m_StopGameButton.SetBitmap(m_Start_Stop_Button);
            m_SettingsButton = new Button(settings.OnGearClick, " ", 10, 10, 60, 60);
            m_SettingsButton.SetBitmap(m_GearInActive);
        }

        public override void GameEnd()
        {
            m_FireFrame1.Dispose();
            m_FireFrame2.Dispose();
            m_FireFrame3.Dispose();
            m_GearActive.Dispose();
            m_GearInActive.Dispose();
            m_Room1Bitmap.Dispose();
            m_Room2Bitmap.Dispose();
            m_Room3Bitmap.Dispose();
            m_Room4Bitmap.Dispose();
            m_StartScreen.Dispose();
            m_Start_Stop_Button.Dispose();
            m_TestBread.Dispose();
            m_StartScreen.Dispose();
        }

        public override void Update()
        {
            Vector2 tempMouseLoc = GAME_ENGINE.GetMousePosition();

            m_MousePosition.X = tempMouseLoc.X;
            m_MousePosition.Y = tempMouseLoc.Y;

            manager.MainUpdater();
        }

        public override void Paint()
        {
            manager.MainPainter();
            manager.DrawRoomStatus();

            GAME_ENGINE.DrawBitmap(m_GearActive, 10, 10);
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
        public void ItemButton(Items.itemNames itemName, Items.itemKinds itemKind, Bitmap bitmap, int x, int y, int width, int height)
        {
            if (m_MousePosition.X > x && m_MousePosition.X < x + width)
            {
                if (m_MousePosition.Y > y && m_MousePosition.Y < y + height)
                {
                    if (GAME_ENGINE.GetMouseButtonDown(0))
                    {
                        invmenager.AddItemToInventory(new Items(itemName, itemKind, bitmap));
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
