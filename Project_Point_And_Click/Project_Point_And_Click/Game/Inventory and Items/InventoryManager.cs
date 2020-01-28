using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class InventoryManager : GameObject
    {
        private GameCore core;

        public InventoryManager(GameCore c)
        {
            core = c;
        }
        List<Inventory> m_InventoryList = new List<Inventory>();
        Items[] m_MerdgeArray = new Items[2];
        Items savedItem;


        public void Updater()
        {
            ClickItem();
            //if (m_InventoryList.Contains(Inventory(new Vector2(10, 10), core.m_Bread)))
            //{

            //}
        }

        public void Painter()
        {
            PaintInventory();
        }

        public void AddItemToInventory(Items item)
        {
            m_InventoryList.Add(new Inventory(new Vector2(640 + (100 * m_InventoryList.Count), 620), item));
        }

        public void PaintInventory()
        {
            GAME_ENGINE.SetColor(Color.Red);

            foreach (Inventory item in m_InventoryList)
            {

                GAME_ENGINE.DrawRectangle(item.position.X - Times50(), item.position.Y, 100, 100);

                if (item.items != null)
                {
                    GAME_ENGINE.DrawBitmap(item.items.bitmap, item.position.X - Times50(), item.position.Y);
                }
            }
        }

        private int Times50()
        {
            return (50 * m_InventoryList.Count);
        }

        private void ClickItem()
        {

            foreach (Inventory item in m_InventoryList)
            {
                //Console.WriteLine(item.position.X + ": X  " + item.position.Y + ": Y");

                if (core.m_MousePosition.X > item.position.X - Times50() && core.m_MousePosition.X < item.position.X + 100 - Times50())
                {
                    if (core.m_MousePosition.Y > item.position.Y && core.m_MousePosition.Y < item.position.Y + 100)
                    {
                        if (GAME_ENGINE.GetMouseButtonDown(0))
                        {
                            switch (item.items.name)
                            {
                                case Items.itemNames.Bread:
                                    savedItem = core.m_Bread;
                                    break;
                                case Items.itemNames.Cage:
                                    savedItem = core.m_Cage;
                                    break;
                                case Items.itemNames.Candle:
                                    savedItem = core.m_CandleNotLit;
                                    break;
                                case Items.itemNames.Candlelit:
                                    savedItem = core.m_CandleLit;
                                    break;
                                case Items.itemNames.Knife:
                                    savedItem = core.m_Knife;
                                    break;
                                case Items.itemNames.Matches:
                                    savedItem = core.m_Matches;
                                    break;
                                case Items.itemNames.Puzzel:
                                    savedItem = core.m_PuzzelPiece;
                                    break;
                                case Items.itemNames.RabbitAlive:
                                    savedItem = core.m_RabbitAlive;
                                    break;
                                case Items.itemNames.RabbitDead:
                                    savedItem = core.m_RabbitDead;
                                    break;
                                default:
                                    break;
                            }
                            Console.WriteLine(savedItem.name);
                        }
                    }
                }
            }
        }

        public void ClearInventory()
        {
            foreach (Inventory item in m_InventoryList)
            {
                item.items.isClicked = false;

            }
            m_InventoryList.Clear();
        }
    }
}
