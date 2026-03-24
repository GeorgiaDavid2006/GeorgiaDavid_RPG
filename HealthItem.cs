using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class HealthItem : Item
    {
        public int _healthItemPosX;
        public int _healthItemPosY;
        public int _healthValue;

        ConsoleColor _healthColor;

        public string _healthSprite;

        public HealthItem(int healthItemPosX, int healthItemPosY, int healthValue)
            :base (healthItemPosX, healthItemPosY, ConsoleColor.Magenta, "+")
        {
            _healthItemPosX = healthItemPosX;
            _healthItemPosY = healthItemPosY;
            _healthValue = healthValue;

            _healthColor = base._color;
            _healthSprite = base._sprite;
        }

        public override void OnCollected()
        {
            if (base.collected == true)
            {
                _healthValue = 0;
            }
        }

        public override void DrawItem()
        {
            base.DrawItem();
        }

        public void CollectHealthItem(Player player)
        {
            if (player._currentPlayerPosX == _healthItemPosX && player._currentPlayerPosY == _healthItemPosY)
            {
                player.playerHealthSystem.UpdateHealth(_healthValue);
                base.collected = true;

                if (player.lastTurnWasX == true && _healthValue > 0)
                {
                    player._currentPlayerPosX = player._previousPlayerPosX;
                    OnCollected();
                }
                else if (player.lastTurnWasX == false && _healthValue > 0)
                {
                    player._currentPlayerPosY = player._previousPlayerPosY;
                    OnCollected();
                }
            }
        }
    }
}
