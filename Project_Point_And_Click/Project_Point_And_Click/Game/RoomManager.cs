﻿namespace GameEngine
{
    public class RoomManager : GameObject
    {
        public enum RoomStatus
        {
            MainMenu = 0,
            Room1,
            Room2,
            Room3,
            Room4,
            Dialog,
            Endscreen,
            Settings,
            Puzzel
        };
        public RoomStatus ActiveScene;
        private int ActiveSceneSave;
        public bool SettingsStatus;

        private GameCore core;
        public RoomManager(GameCore c)
        {
            core = c;
        }

        public void MainUpdater()
        {
            switch (ActiveScene)
            {
                case RoomStatus.MainMenu:
                    core.main.Updater();
                    break;
                case RoomStatus.Room1:
                    core.room1.Updater();
                    core.invmenager.Updater();
                    core.FunctionButton(GameCore.m_Functions.settings, 10, 10, 60, 60);
                    break;
                case RoomStatus.Room2:
                    core.room2.Updater();
                    core.invmenager.Updater();
                    core.FunctionButton(GameCore.m_Functions.settings, 10, 10, 60, 60);
                    break;
                case RoomStatus.Room3:
                    core.room3.Updater();
                    core.invmenager.Updater();
                    core.FunctionButton(GameCore.m_Functions.settings, 10, 10, 60, 60);
                    break;
                case RoomStatus.Room4:
                    core.room4.Updater();
                    core.invmenager.Updater();
                    core.FunctionButton(GameCore.m_Functions.settings, 10, 10, 60, 60);
                    break;
                case RoomStatus.Dialog:
                    core.dialog.Updater();
                    break;
                case RoomStatus.Endscreen:
                    core.end.Updater();
                    break;
                case RoomStatus.Settings:
                    core.settings.Updater();
                    break;
                case RoomStatus.Puzzel:
                    core.puzzel.Updater();
                    break;
                default:
                    break;
            }
        }
        public void MainPainter()
        {
            switch (ActiveScene)
            {
                case RoomStatus.MainMenu:
                    core.main.Painter();
                    break;
                case RoomStatus.Room1:
                    core.room1.Painter();
                    core.invmenager.Painter();
                    core.DrawFunctionButton(GameCore.m_Functions.gear, 10, 10, 60, 60);
                    DrawAmulet();
                    break;
                case RoomStatus.Room2:
                    DrawBackground();
                    core.room2.Painter();
                    core.invmenager.Painter();
                    core.DrawFunctionButton(GameCore.m_Functions.gear, 10, 10, 60, 60);
                    DrawAmulet();
                    break;
                case RoomStatus.Room3:
                    core.room3.Painter();
                    core.invmenager.Painter();
                    core.DrawFunctionButton(GameCore.m_Functions.gear, 10, 10, 60, 60);
                    DrawAmulet();
                    break;
                case RoomStatus.Room4:
                    core.room4.Painter();
                    core.invmenager.Painter();
                    core.DrawFunctionButton(GameCore.m_Functions.gear, 10, 10, 60, 60);
                    DrawAmulet();
                    break;
                case RoomStatus.Endscreen:
                    core.end.Painter();
                    break;
                case RoomStatus.Dialog:
                    core.dialog.Painter();
                    break;
                case RoomStatus.Settings:
                    core.settings.Painter();
                    break;
                case RoomStatus.Puzzel:
                    core.puzzel.Painter();
                    break;
                default:
                    break;
            }
        }
        public void DrawBackground()
        {
            switch (ActiveScene)
            {
                case RoomStatus.MainMenu:
                    GAME_ENGINE.DrawBitmap(core.m_StartScreen, 0, 0);
                    break;
                case RoomStatus.Room1:
                    GAME_ENGINE.DrawBitmap(core.m_Room1Bitmap, 0, 0);
                    break;
                case RoomStatus.Room2:
                    if (core.m_AmuletActive)
                    {
                        GAME_ENGINE.DrawBitmap(core.m_Room2Bitmap2, 0, 0);
                    }
                    else
                    {
                        GAME_ENGINE.DrawBitmap(core.m_Room2Bitmap, 0, 0);
                    }
                    break;
                case RoomStatus.Room3:
                    GAME_ENGINE.DrawBitmap(core.m_Room3Bitmap, 0, 0);
                    break;
                case RoomStatus.Room4:
                    GAME_ENGINE.DrawBitmap(core.m_Room4Bitmap, 0, 0);
                    break;
                case RoomStatus.Dialog:
                    break;
                case RoomStatus.Endscreen:
                    GAME_ENGINE.DrawBitmap(core.m_DeathScreen, 0, 0);
                    break;
                case RoomStatus.Settings:
                    GAME_ENGINE.DrawBitmap(core.m_SettingsMenuInterface, 0, 0);
                    break;
                case RoomStatus.Puzzel:
                    break;
                default:
                    break;
            }
        }
        public void DrawRoomStatus()
        {
            Font font = new Font("Arial", 50);

            GAME_ENGINE.SetColor(Color.Red);
            GAME_ENGINE.DrawString(font, ActiveScene.ToString(), 100, 0, 400, 100);
        }
        public void SettingsSwitchOnOff()
        {
            if (SettingsStatus == false)
            {
                SettingsStatus = true;
            }
            else if (SettingsStatus == true)
            {
                SettingsStatus = false;
            }
        }
        public void SaveLoadLastRoom()
        {
            if (SettingsStatus == false)
            {
                ActiveSceneSave = (int)ActiveScene;
            }
            else if (SettingsStatus == true)
            {
                ActiveScene = (RoomStatus)ActiveSceneSave;
            }
        }
        public void SetRoom(RoomStatus roomInput)
        {
            ActiveScene = (RoomStatus)roomInput;
        }

        Font amulet = new Font("", 20);

        private void DrawAmulet()
        {
            GAME_ENGINE.SetColor(Color.Gray);
            GAME_ENGINE.FillRoundedRectangle(20, 550, 150, 150, 10, 10);
            GAME_ENGINE.DrawBitmap(core.m_Amulet, 20, 550);
            GAME_ENGINE.SetColor(Color.White);
            GAME_ENGINE.DrawString(amulet, "E", 140, 670, 50, 50);
        }
    }
}
