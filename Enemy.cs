using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Enemy
    {
        int _enemyPosX;
        int _enemyPosY;

        ConsoleColor _color;

        public Enemy(int enemyPosX, int enemyPosY, ConsoleColor color)
        {
            _enemyPosX = enemyPosX;
            _enemyPosY = enemyPosY;

            _color = color;
        }

        void MoveEnemy()
        {

        }

        void DrawEnemy()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(_enemyPosX, _enemyPosY);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }
    }
}
