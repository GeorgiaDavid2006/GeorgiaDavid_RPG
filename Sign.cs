using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Sign : Item
    {
        public int _signPosX;
        public int _signPosY;

        ConsoleColor _signColor;
        public string _signSprite;

        public bool wasRead = false;

        public Sign(int signPosX, int signPosY)
            : base(signPosX, signPosY, ConsoleColor.DarkMagenta, "!")
        {
            _signPosX = signPosX;
            _signPosY = signPosY;

            _signColor = base._color;
            _signSprite = base._sprite;
        }
        public override void DrawItem()
        {
            if (wasRead == true)
            {
                return;
            }

            base.DrawItem();
        }

        public override void CollectItem(Player player)
        {
            if (wasRead == true)
            {
                return;
            }

            if (player._currentPlayerPosX == _signPosX && player._currentPlayerPosY == _signPosY)
            {
                if (player.lastTurnWasX == true)
                {
                    player._currentPlayerPosX = player._previousPlayerPosX;
                    wasRead = true;
                }
                else if (player.lastTurnWasX == false)
                {
                    player._currentPlayerPosY = player._previousPlayerPosY;
                    wasRead = true;
                }
            }
        }
    }
}
