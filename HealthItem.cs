using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class HealthItem
    {
        public int _healthItemPosX;
        public int _healthItemPosY;
        public int _healthValue;

        public bool collected = false;

        public HealthItem(int healthItemPosX, int healthItemPosY, int healthValue)
        {
            _healthItemPosX = healthItemPosX;
            _healthItemPosY = healthItemPosY;
            _healthValue = healthValue;
        }

        public void OnCollected()
        {
            if (collected == true)
            {
                _healthValue = 0;
            }
        }

        public void DrawHealthItem()
        {
            if (collected == true)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_healthItemPosX + 1, _healthItemPosY + 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("+");
        }
    }
}
