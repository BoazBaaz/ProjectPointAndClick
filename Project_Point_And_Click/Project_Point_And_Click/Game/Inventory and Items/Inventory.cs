using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Inventory : GameObject
    {
        public Items items;
        public Vector2 position;

        public Inventory(Vector2 invPosition)
        {
               position = invPosition;
        }
    }
}
