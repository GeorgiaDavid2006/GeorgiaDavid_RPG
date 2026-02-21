using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Gold
    {
        public int _goldPosX;
        public int _goldPosY;
        public int _goldValue;

        public bool collected = false;

        public Gold(int goldPosX, int goldPosY, int goldValue)
        {
            _goldPosX = goldPosX;
            _goldPosY = goldPosY;
            _goldValue = goldValue;
        }

        public void OnCollected()
        {
            if (collected == true)
            {
                _goldValue = 0;
            }
        }

        public void DrawGold()
        {
            if (collected == true)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_goldPosX, _goldPosY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("#");
        }
    }
}