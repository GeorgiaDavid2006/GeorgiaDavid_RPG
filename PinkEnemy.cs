using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class PinkEnemy : Enemy
    {
        public int _posX;
        public int _posY;

        public int _attack;

        ConsoleColor _pink;

        public PinkEnemy(int posX, int posY, int attack)
            :base(8, 8, posX, posY, ConsoleColor.Magenta, attack)
        {
            _pink = base._color;

            _posX = posX;
            _posY = posY;
            _attack = attack;
        }

        public override void MoveEnemy(Player player)
        {
            if (player.isPlayersTurn == true)
            {
                return;
            }

            if (enemyHealthSystem._currentHealth <= 0)
            {
                return;
            }

            if (_enemyPosX < player._currentPlayerPosX)
            {
                if (_enemyPosX + 1 <= _borderRight)
                {
                    _enemyPosX = _enemyPosX + 1;
                    player.isPlayersTurn = true;
                }
            }
            if (_enemyPosX > player._currentPlayerPosX)
            {
                if (_enemyPosX - 1 >= _borderLeft)
                {
                    _enemyPosX = _enemyPosX - 1;
                    player.isPlayersTurn = true;
                }
            }
            if (_enemyPosY < player._currentPlayerPosY)
            {
                if (_enemyPosY + 1 <= _borderDown)
                {
                    _enemyPosY = _enemyPosY + 1;
                    player.isPlayersTurn = true;
                }
            }
            if (_enemyPosY > player._currentPlayerPosY)
            {
                if (_enemyPosY - 1 >= _borderUp)
                {
                    _enemyPosY = _enemyPosY - 1;
                    player.isPlayersTurn = true;
                }
            }

            if (_enemyPosX < _borderLeft)
            {
                _enemyPosX = _borderLeft;
            }

            if (_enemyPosY < _borderUp)
            {
                _enemyPosY = _borderUp;
            }

            if (_enemyPosX > _borderRight)
            {
                _enemyPosX = _borderRight;
            }

            if (_enemyPosY > _borderDown)
            {
                _enemyPosY = _borderDown;
            }

            if (_enemyPosX == player._currentPlayerPosX && _enemyPosY == player._currentPlayerPosY)
            {
                player.playerHealthSystem.UpdateHealth(-_attackPower);
                player._currentPlayerPosX = 0;
                player._currentPlayerPosY = 0;
            }
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
