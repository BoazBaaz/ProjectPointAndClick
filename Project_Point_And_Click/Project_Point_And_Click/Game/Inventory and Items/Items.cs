using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Items : GameObject
    {
        public enum itemNames : int
        {
            Bread = 0,
            Cage,
            Candle,
            Candlelit,
            Knife,
            Matches,
            Puzzel,
            RabbitAlive,
            RabbitDead
        }
        public enum itemKinds : int
        {
            questItem = 0,
            material
        }

        public itemNames name;
        public itemKinds kind;
        public Bitmap bitmap;
        public bool isClicked = false;

        public Items(itemNames itemName, itemKinds itemKind, Bitmap itemBitmap)
        {
            name = itemName;
            kind = itemKind;
            bitmap = itemBitmap;
        }
    }
}
