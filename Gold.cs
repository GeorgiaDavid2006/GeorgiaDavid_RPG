using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Gold : Item
    {
        public int _goldPosX;
        public int _goldPosY;
        public int _goldValue;

        ConsoleColor _goldColor;

        public string _goldSprite;

        public Gold(int goldPosX, int goldPosY, int goldValue)
            : base(goldPosX, goldPosY, ConsoleColor.Yellow, "#")
        {
            _goldPosX = goldPosX;
            _goldPosY = goldPosY;
            _goldValue = goldValue;

            _goldColor = base._color;
            _goldSprite = base._sprite;
        }

        public override void OnCollected()
        {
            if (base.collected == true)
            {
                _goldValue = 0;
            }
        }

        public override void DrawItem()
        {
            base.DrawItem();
        }

        public void CollectGold(Player player)
        {
            if (_goldPosX == player._currentPlayerPosX && _goldPosY == player._currentPlayerPosY)
            {
                player._amountOfGold = player._amountOfGold + _goldValue;
                base.collected = true;

                if (player.lastTurnWasX == true && _goldValue > 0)
                {
                    player._currentPlayerPosX = player._previousPlayerPosX;
                    OnCollected();
                }
                else if (player.lastTurnWasX == false && _goldValue > 0)
                {
                    player._currentPlayerPosY = player._previousPlayerPosY;
                    OnCollected();
                }
            }
        }
    }
}