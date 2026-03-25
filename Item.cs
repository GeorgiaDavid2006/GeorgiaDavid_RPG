using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Item
    {
        public int _itemPosX;
        public int _itemPosY;

        public ConsoleColor _color;

        public string _sprite;

        public bool collected = false;

        public Item(int itemPosX, int itemPosY, ConsoleColor color, string sprite)
        {
            _itemPosX = itemPosX;
            _itemPosY = itemPosY;
            _color = color;
            _sprite = sprite;
        }

        public virtual void OnCollected()
        {

        }

        public virtual void DrawItem()
        {
            if (collected == true)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_itemPosX + 1, _itemPosY + 1);
            Console.ForegroundColor = _color;
            Console.WriteLine(_sprite);
        }

        public virtual void CollectItem(Player player)
        {

        }
    }
}
