using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Player
    {
        Map levelMap = new Map();

        public HealthSystem playerHealthSystem = new HealthSystem(5, 5);

        public int _currentHealth;
        public int _maxHealth;

        public int _currentPlayerPosX;
        public int _currentPlayerPosY;

        private int _previousPlayerPosX;
        private int _previousPlayerPosY;

        private int _borderLeft = 0;
        private int _borderDown = 15;
        private int _borderUp = 0;
        private int _borderRight = 59;

        public int _amountOfGold = 0;

        ConsoleColor _color;

        public bool isPlayersTurn = true;
        private bool lastTurnWasX = false;
        public bool hasWon = false;

        public Player(int playerMaxHealth, int playerCurrentHealth, int playerPosX, int playerPosY, ConsoleColor color)
        {
            _currentPlayerPosX = playerPosX;
            _currentPlayerPosY = playerPosY;

            _color = color;

            _currentHealth = playerHealthSystem._currentHealth;
            _maxHealth = playerHealthSystem._maxHealth;
        }

        public void PlayerInput(List<Enemy> enemies)
        {
            if (playerHealthSystem._currentHealth <= 0)
            {
                return;
            }

            if (!Console.KeyAvailable)
            {
                return;
            }

            ConsoleKeyInfo inputKey = Console.ReadKey(true);

            if (inputKey.Key == ConsoleKey.A)
            {
                _previousPlayerPosX = _currentPlayerPosX;
                lastTurnWasX = true;
                if (_currentPlayerPosX - 1 >= _borderLeft)
                {
                    if (levelMap.map[_currentPlayerPosY][_currentPlayerPosX - 1] != '▓')
                    {
                        _currentPlayerPosX = _currentPlayerPosX - 1;
                        isPlayersTurn = false;
                    }
                }
            }

            if (inputKey.Key == ConsoleKey.D)
            {
                _previousPlayerPosX = _currentPlayerPosX;
                lastTurnWasX = true;
                if (_currentPlayerPosX + 1 <= _borderRight)
                {
                    if (levelMap.map[_currentPlayerPosY][_currentPlayerPosX + 1] != '▓')
                    {
                        _currentPlayerPosX = _currentPlayerPosX + 1;
                        isPlayersTurn = false;
                    }
                }
            }

            if (inputKey.Key == ConsoleKey.W)
            {
                _previousPlayerPosY = _currentPlayerPosY;
                lastTurnWasX = false;
                if (_currentPlayerPosY - 1 >= _borderUp)
                {
                    if (levelMap.map[_currentPlayerPosY - 1][_currentPlayerPosX] != '▓')
                    {
                        _currentPlayerPosY = _currentPlayerPosY - 1;
                        isPlayersTurn = false;
                    }
                }
            }

            if (inputKey.Key == ConsoleKey.S)
            {
                _previousPlayerPosY = _currentPlayerPosY;
                lastTurnWasX = false;
                if (_currentPlayerPosY + 1 <= _borderDown)
                {
                    if (levelMap.map[_currentPlayerPosY + 1][_currentPlayerPosX] != '▓')
                    {
                        _currentPlayerPosY = _currentPlayerPosY + 1;
                        isPlayersTurn = false;
                    }
                }
            }

            if (_currentPlayerPosX < _borderLeft)
            {
                _currentPlayerPosX = _borderLeft;
            }

            if (_currentPlayerPosY < _borderUp)
            {
                _currentPlayerPosY = _borderUp;
            }

            if (_currentPlayerPosX > _borderRight)
            {
                _currentPlayerPosX = _borderRight;
            }

            if (_currentPlayerPosY > _borderDown)
            {
                _currentPlayerPosY = _borderDown;
            }

            if (_currentPlayerPosX == enemies[0]._enemyPosX && _currentPlayerPosY == enemies[0]._enemyPosY)
            {
                enemies[0].enemyHealthSystem.UpdateHealth(-1);
                enemies[0]._enemyPosX = 30;
                enemies[0]._enemyPosY = 0;

                if (lastTurnWasX == true)
                {
                    _currentPlayerPosX = _previousPlayerPosX;
                }
                else
                {
                    _currentPlayerPosY = _previousPlayerPosY;
                }
            }
        }

        public void DrawPlayer()
        {
            if (playerHealthSystem._currentHealth <= 0)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_currentPlayerPosX + 1, _currentPlayerPosY + 1);
            Console.ForegroundColor = _color;
            Console.WriteLine("O");
        }

        public void CollectGold(Gold gold)
        {
            if (_currentPlayerPosX == gold._goldPosX && _currentPlayerPosY == gold._goldPosY)
            {
                _amountOfGold = _amountOfGold + gold._goldValue;
                gold.collected = true;

                if (lastTurnWasX == true && gold._goldValue > 0)
                {
                    _currentPlayerPosX = _previousPlayerPosX;
                    gold.OnCollected();
                }
                else if (lastTurnWasX == false && gold._goldValue > 0)
                {
                    _currentPlayerPosY = _previousPlayerPosY;
                    gold.OnCollected();
                }
            }
        }

        public void CollectHealthItem(HealthItem healthItem)
        {
            if (_currentPlayerPosX == healthItem._healthItemPosX && _currentPlayerPosY == healthItem._healthItemPosY)
            {
                playerHealthSystem.UpdateHealth(healthItem._healthValue);
                healthItem.collected = true;

                if (lastTurnWasX == true && healthItem._healthValue > 0)
                {
                    _currentPlayerPosX = _previousPlayerPosX;
                    healthItem.OnCollected();
                }
                else if (lastTurnWasX == false && healthItem._healthValue > 0)
                {
                    _currentPlayerPosY = _previousPlayerPosY;
                    healthItem.OnCollected();
                }
            }
        }

        public void CollectGem(Gem gem)
        {
            if (_currentPlayerPosX == gem._gemPosX && _currentPlayerPosY == gem._gemPosY)
            {
                gem.collected = true;
                hasWon = true;

                if (lastTurnWasX == true)
                {
                    _currentPlayerPosX = _previousPlayerPosX;
                }
                else if (lastTurnWasX == false)
                {
                    _currentPlayerPosY = _previousPlayerPosY;
                }
            }
        }
    }
}
