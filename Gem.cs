using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Gem : Item
    {
        public int _gemPosX;
        public int _gemPosY;

        ConsoleColor _gemColor;

        public string _gemSprite;

        public Gem(int gemPosX, int gemPosY)
            :base (gemPosX, gemPosY, ConsoleColor.Green, "*")
            
        {
            _gemPosX = gemPosX;
            _gemPosY = gemPosY;

            _gemColor = base._color;
            _gemSprite = base._sprite;
        }

        public override void DrawItem()
        {
            base.DrawItem();
        }

        public void CollectGem(Player player)
        {
            if (player._currentPlayerPosX == _gemPosX && player._currentPlayerPosY == _gemPosY)
            {
                base.collected = true;
                player.hasWon = true;

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
