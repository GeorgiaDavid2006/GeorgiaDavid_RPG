using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Player : HealthSystem
    {
        int _playerPosX;
        int _playerPosY;

        ConsoleColor _color;

        public Player(int playerMaxHealth, int playerCurrentHealth, int playerPosX, int playerPosY, ConsoleColor color)
            : base(playerMaxHealth, playerCurrentHealth)
        {
            _playerPosX = playerPosX;
            _playerPosY = playerPosY;

            _color = color;
        }

        public void PlayerInput()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.A) _playerPosX -= 1;


            if (inputKey.Key == ConsoleKey.D) _playerPosX += 1;


            if (inputKey.Key == ConsoleKey.W) _playerPosY -= 1;


            if (inputKey.Key == ConsoleKey.S) _playerPosY += 1;


            if (_playerPosX <= 1)
            {
                _playerPosX = 1;
            }

            if (_playerPosY <= 1)
            {
                _playerPosY = 1;
            }

            if (_playerPosX >= 30)
            {
                _playerPosX = 30;
            }

            if (_playerPosY >= 12)
            {
                _playerPosY = 12;
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
