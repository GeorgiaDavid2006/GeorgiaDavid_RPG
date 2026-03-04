using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class PinkEnemy : Enemy
    {
        public int _pinkEnemyPosX;
        public int _pinkEnemyPosY;

        public int _posX;
        public int _posY;

        public int _attack;

        ConsoleColor _pink;

        public PinkEnemy(int posX, int posY, int attack)
            :base(8, 8, posX, posY, ConsoleColor.Magenta, attack)
        {
            _pinkEnemyPosX = base._enemyPosX;
            _pinkEnemyPosY = base._enemyPosY;

            _pink = base._color;
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
