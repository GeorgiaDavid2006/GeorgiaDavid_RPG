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

        public Player(int playerMaxHealth, int playerCurrentHealth, int playerPosX, int playerPosY, ConsoleColor color)
            : base(playerMaxHealth, playerCurrentHealth)
        {
            _playerPosX = playerPosX;
            _playerPosY = playerPosY;

            _color = color;
        }

        public void PlayerInput(Enemy enemy, ConsoleKey inputKey)
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            if (inputKey == ConsoleKey.A)
            {
                _playerPosX = _playerPosX - 1;
            }


            if (inputKey == ConsoleKey.D)
            {
                _playerPosX = _playerPosX + 1;
            }


            if (inputKey == ConsoleKey.W)
            {
                _playerPosY = _playerPosY - 1;
            }


            if (inputKey == ConsoleKey.S)
            {
                _playerPosY = _playerPosY + 1;
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
            Console.CursorVisible = false;
            Console.SetCursorPosition(_playerPosX, _playerPosY);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }
    }
}
