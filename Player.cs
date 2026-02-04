using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Player
    {
        int _playerPosX;
        int _playerPosY;
        ConsoleColor _color;

        public Player(int playerPosX, int playerPosY, ConsoleColor color)
        {
            _playerPosX = playerPosX;
            _playerPosY = playerPosY;

            _color = color;
        }

        void PlayerInput()
        {

        }

        void DrawPlayer()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(_playerPosX, _playerPosY);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }
    }
}
