using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Enemy
    {
        public Enemy()
        {

        }

        void MoveEnemy()
        {

        }

        void DrawEnemy(int enemyPosX, int enemyPosY, ConsoleColor color)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(enemyPosX, enemyPosY);
            Console.ForegroundColor = color;
            Console.WriteLine("O");
        }
    }
}
