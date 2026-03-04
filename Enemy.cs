using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Enemy : HealthSystem
    {
        public int _enemyPosX;
        public int _enemyPosY;

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
            if (player.isPlayersTurn == true)
            {
                return;
            }

            if (_currentHealth <= 0)
            {
                return;
            }

            if (_enemyPosX < player._currentPlayerPosX)
            {
                _enemyPosX += 1;
                player.isPlayersTurn = true;
            }
           if (_enemyPosX > player._currentPlayerPosX)
            {
                _enemyPosX -= 1;
                player.isPlayersTurn = true;
            }
           if (_enemyPosY < player._currentPlayerPosY)
            {
                _enemyPosY += 1;
                player.isPlayersTurn = true;
            }
           if (_enemyPosY > player._currentPlayerPosY)
            {
                _enemyPosY -= 1;
                player.isPlayersTurn = true;
            }

           if (_enemyPosX == player._currentPlayerPosX && _enemyPosY == player._currentPlayerPosY)
            {
                player.UpdateHealth(-1);
                player._currentPlayerPosX = 0;
                player._currentPlayerPosY = 0;
            }
        }

        public void DrawEnemy()
        {
            if (_currentHealth <= 0)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_enemyPosX + 1, _enemyPosY + 1);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }
    }
}
