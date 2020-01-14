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

        public void Updater()
        {
            ClickItem();
        }

        public void Painter()
        {
            PaintInventory();
        }

        public void AddItemToInventory(Items item)
        {
            m_InventoryList.Add(new Inventory(new Vector2(440 + 100 * m_InventoryList.Count, 620), item));
        }

        public void PaintInventory()
        {
            GAME_ENGINE.SetColor(Color.Red);

            foreach (Inventory item in m_InventoryList)
            {
                GAME_ENGINE.DrawRectangle(item.position.X, item.position.Y, 100, 100);

                if (item.items != null)
                {
                    GAME_ENGINE.DrawBitmap(item.items.bitmap, item.position.X, item.position.Y);
                }
            }

        }

        private void ClickItem()
        {
            foreach (Inventory item in m_InventoryList)
            {
                if (core.m_MousePosition.X > item.position.X && core.m_MousePosition.X < item.position.X)
                {
                    if (core.m_MousePosition.Y > item.position.Y && core.m_MousePosition.Y < item.position.Y)
                    {
                        if (GAME_ENGINE.GetMouseButtonDown(0))
                        {
                            Console.WriteLine("it's a " + item.ToString());
                        }
                    }
                }
            }
        }
    }
}
