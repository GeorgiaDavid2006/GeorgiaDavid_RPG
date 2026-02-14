using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Enemy : HealthSystem
    {
        int _enemyPosX;
        int _enemyPosY;

        int _playerPosX;
        int _playerPosY;

        ConsoleColor _color;
        public Enemy(int enemyMaxHealth, int enemyCurrentHealth, int enemyPosX, int enemyPosY, ConsoleColor color)
            : base(enemyMaxHealth, enemyCurrentHealth)
        {
            _enemyPosX = enemyPosX;
            _enemyPosY = enemyPosY;

            _color = color;
        }

        public void MoveEnemy(Player player)
        {
           
        }

        public void DrawEnemy()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(_enemyPosX, _enemyPosY);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }
    }
}
