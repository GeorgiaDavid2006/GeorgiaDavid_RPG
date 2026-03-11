using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class GreenEnemy : Enemy
    {
        public int _posX;
        public int _posY;

        public int _attack;

        ConsoleColor _green;

        public GreenEnemy(int posX, int posY, int attack)
            : base(10, 10, posX, posY, ConsoleColor.Green, attack)
        {
            _green = base._color;

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
            base.UpdateHealth(amount);
        }

        public override void DrawEnemy()
        {
            base.DrawEnemy();
        }
    }
}
