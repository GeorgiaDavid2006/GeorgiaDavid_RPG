using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Player : HealthSystem
    {
        public int _playerPosX;
        public int _playerPosY;

        ConsoleColor _color;

        public bool isPlayersTurn = true;

        public Player(int playerMaxHealth, int playerCurrentHealth, int playerPosX, int playerPosY, ConsoleColor color)
            : base(playerMaxHealth, playerCurrentHealth)
        {
            _playerPosX = playerPosX;
            _playerPosY = playerPosY;

            _color = color;
        }

        public void PlayerInput(Enemy enemy)
        {
            if (_currentHealth <= 0)
            {
                return;
            }

            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.A)
            {
                _playerPosX = _playerPosX - 1;
                isPlayersTurn = false;
            }

            if (inputKey.Key == ConsoleKey.D)
            {
                _playerPosX = _playerPosX + 1;
                isPlayersTurn = false;
            }


            if (inputKey.Key == ConsoleKey.W)
            {
                _playerPosY = _playerPosY - 1;
                isPlayersTurn = false;
            }


            if (inputKey.Key == ConsoleKey.S)
            {
                _playerPosY = _playerPosY + 1;
                isPlayersTurn = false;
            }

            if (_playerPosX < 1)
            {
                _playerPosX = 1;
            }

            if (_playerPosY < 1)
            {
                _playerPosY = 1;
            }

            if (_playerPosX > 30)
            {
                _playerPosX = 30;
            }

            if (_playerPosY > 12)
            {
                _playerPosY = 12;
            }

            if (_playerPosX == enemy._enemyPosX && _playerPosY == enemy._enemyPosY)
            {
                enemy.UpdateHealth(-1);
                enemy._enemyPosX = 30;
                enemy._enemyPosY = 1;
            }
        }

        public void DrawPlayer()
        {
            if (_currentHealth <= 0)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_playerPosX, _playerPosY);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }
    }
}
