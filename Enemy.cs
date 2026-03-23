using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Enemy
    {
        Map levelMap = new Map();

        public int _enemyPosX;
        public int _enemyPosY;

        public int _attackPower;

        public HealthSystem enemyHealthSystem = new HealthSystem(5, 5);

        public int _currentHealth;
        public int _maxHealth;

        public ConsoleColor _color;

        private int _borderLeft = 0;
        private int _borderDown = 15;
        private int _borderUp = 0;
        private int _borderRight = 59;

        public Enemy(int enemyMaxHealth, int enemyCurrentHealth, int enemyPosX, int enemyPosY, ConsoleColor color, int attackPower)
        {
            _enemyPosX = enemyPosX;
            _enemyPosY = enemyPosY;

            _attackPower = attackPower;

            _color = color;

            _currentHealth = enemyHealthSystem._currentHealth;
            _maxHealth = enemyHealthSystem._maxHealth;
        }

        public virtual void MoveEnemy(Player player)
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
                    if (levelMap.map[_enemyPosY][_enemyPosX + 1] != '▓')
                    {
                        _enemyPosX = _enemyPosX + 1;
                        player.isPlayersTurn = true;
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
                        player.isPlayersTurn = true;
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
                        player.isPlayersTurn = true;
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
                        player.isPlayersTurn = true;
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

        public virtual void UpdateHealth(int amount)
        {
            enemyHealthSystem._currentHealth = enemyHealthSystem._currentHealth + amount;

            if (enemyHealthSystem._currentHealth > enemyHealthSystem._maxHealth)
            {
                enemyHealthSystem._currentHealth = enemyHealthSystem._maxHealth;
            }

            else if (enemyHealthSystem._currentHealth < 0)
            {
                enemyHealthSystem._currentHealth = 0;
            }
        }

        public virtual void DrawEnemy()
        {
            if (enemyHealthSystem._currentHealth <= 0)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_enemyPosX + 1, _enemyPosY + 1);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }
    }
}
