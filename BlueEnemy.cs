using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class BlueEnemy : Enemy
    {
        public int _posX;
        public int _posY;

        public int _attack;

        ConsoleColor _blue;
        public BlueEnemy(int posX, int posY, int attack)
            : base(5, 5, posX, posY, ConsoleColor.Blue, attack)
        {
            _blue = base._color;

            _posX = posX;
            _posY = posY;
            _attack = attack;
        }

        public override void MoveEnemy(Player player)
        {
            base.MoveEnemy(player);
        }

        public override void UpdateHealth(int amount)
        {
            amount = _attack;
            base.UpdateHealth(amount);
        }

        public override void DrawEnemy()
        {
            base.DrawEnemy();
        }
    }
}
