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
        Map levelMap = new Map();

        int turnNumber = 0;

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
            if (player.isPlayersTurn == true)
            {
                return;
            }

            if (enemyHealthSystem._currentHealth <= 0)
            {
                return;
            }

            turnNumber += 1;

            bool isEven = (turnNumber % 2 == 0);

            if (!isEven)
            {
                return;
            }

            if (_enemyPosX < player._currentPlayerPosX)
            {
                if (_enemyPosX + 1 <= _borderRight)
                {
                    if (levelMap.map[_enemyPosY][_enemyPosX + 1] != '▓')
                    {
                        _enemyPosX = _enemyPosX + 1;
                    }
                }
            }
            if (_enemyPosX > player._currentPlayerPosX)
            {
                if (_enemyPosX - 1 >= _borderLeft)
                {
                    if (levelMap.map[_enemyPosY][_enemyPosX - 1] != '▓')
                    {
                        _enemyPosX = _enemyPosX - 1;
                    }
                }
            }
            if (_enemyPosY < player._currentPlayerPosY)
            {
                if (_enemyPosY + 1 <= _borderDown)
                {
                    if (levelMap.map[_enemyPosY + 1][_enemyPosX] != '▓')
                    {
                        _enemyPosY = _enemyPosY + 1;
                    }
                }
            }
            if (_enemyPosY > player._currentPlayerPosY)
            {
                if (_enemyPosY - 1 >= _borderUp)
                {
                    if (levelMap.map[_enemyPosY - 1][_enemyPosX] != '▓')
                    {
                        _enemyPosY = _enemyPosY - 1;
                    }
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
