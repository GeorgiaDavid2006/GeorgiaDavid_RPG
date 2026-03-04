using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Gem
    {
        public int _gemPosX;
        public int _gemPosY;

        ConsoleColor _color;

        public bool collected = false;

        public Gem(int gemPosX, int gemPosY, ConsoleColor consoleColor)
        {
            _gemPosX = gemPosX;
            _gemPosY = gemPosY;

            _color = consoleColor;
        }

        public void DrawGem()
        {
            if (collected == true)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_gemPosX + 1, _gemPosY + 1);
            Console.ForegroundColor = _color;
            Console.WriteLine("*");
        }
    }
}
