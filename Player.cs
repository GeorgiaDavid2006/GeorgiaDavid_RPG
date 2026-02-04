using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Player
    {
        public Player()
        {

        }

        void PlayerInput()
        {

        }

        void DrawPlayer(int playerPosX, int playerPosY, ConsoleColor color)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(playerPosX, playerPosY);
            Console.ForegroundColor = color;
            Console.WriteLine("O");
        }
    }
}
