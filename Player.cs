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

        public int _previousPlayerPosX;
        public int _previousPlayerPosY;

        private int _borderLeft = 0;
        private int _borderDown = 23;
        private int _borderUp = 0;
        private int _borderRight = 92;

        public int _amountOfGold = 0;

        ConsoleColor _color;

        public bool isPlayersTurn = true;
        public bool lastTurnWasX = false;
        public bool hasWon = false;
        public bool hasKey = false;

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

            bool canMoveToPosition = true;

            foreach(Enemy enemy in enemies)
            {
                if (_currentPlayerPosX == enemy._enemyPosX && _currentPlayerPosY == enemy._enemyPosY)
                {
                    canMoveToPosition = false;
                    enemy.enemyHealthSystem.UpdateHealth(-1);
                    enemy._enemyPosX = 59;
                    enemy._enemyPosY = 0;
                    break;
                }
                
            }

            if (canMoveToPosition == false)
            {
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
    }
}
