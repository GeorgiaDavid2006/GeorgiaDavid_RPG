using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Key : Item
    {
        public int _keyPosX;
        public int _keyPosY;

        ConsoleColor _keyColor;

        public string _keySprite;

        public Key(int keyPosX, int keyPosY)
            :base(keyPosX, keyPosY, ConsoleColor.DarkRed, "^")
        {
            _keyPosX = keyPosX;
            _keyPosY = keyPosY;

            _keyColor = base._color;

            _keySprite = base._sprite;
        }

        public override void DrawItem()
        {
            base.DrawItem();
        }

        public override void CollectItem(Player player)
        {
            if (player._currentPlayerPosX == _keyPosX && player._currentPlayerPosY == _keyPosY)
            {
                base.collected = true;
                player.hasKey = true;

                if (player.lastTurnWasX == true)
                {
                    player._currentPlayerPosX = player._previousPlayerPosX;
                }
                else if (player.lastTurnWasX == false)
                {
                    player._currentPlayerPosY = player._previousPlayerPosY;
                }
            }
        }
    }
}
