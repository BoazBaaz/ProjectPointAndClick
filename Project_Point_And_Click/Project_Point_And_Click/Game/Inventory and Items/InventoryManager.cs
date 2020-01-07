using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class InventoryManager : GameObject
    {
        List<Inventory> m_InventoryList = new List<Inventory>();

        public InventoryManager()
        {

        }

        public void Updater()
        {

        }

        public void Painter()
        {
            PaintInventory();
        }

        public void AddItemToInventory(Items item)
        {
            for (int i = 0; i < 2; i++)
            {
                m_InventoryList.Add(new Inventory(new Vector2(440 + 100 * i, 640)));

                m_InventoryList[i].items = item;
            }
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
    }
}
