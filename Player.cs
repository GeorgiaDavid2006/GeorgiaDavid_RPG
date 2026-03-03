using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class Player : HealthSystem
    {
        public int _currentPlayerPosX;
        public int _currentPlayerPosY;

        private int _previousPlayerPosX;
        private int _previousPlayerPosY;

        private int _borderLeft = 1;
        private int _borderDown = 12;
        private int _borderUp = 1;
        private int _borderRight = 30;

        public int _amountOfGold = 0;

        ConsoleColor _color;

        public bool isPlayersTurn = true;
        private bool lastTurnWasX = false;

        public Player(int playerMaxHealth, int playerCurrentHealth, int playerPosX, int playerPosY, ConsoleColor color)
            : base(playerMaxHealth, playerCurrentHealth)
        {
            _currentPlayerPosX = playerPosX;
            _currentPlayerPosY = playerPosY;

            _color = color;
        }

        public void PlayerInput(Enemy enemy)
        {
            if (_currentHealth <= 0)
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
                _currentPlayerPosX = _currentPlayerPosX - 1;
                isPlayersTurn = false;
            }

            if (inputKey.Key == ConsoleKey.D)
            {
                _previousPlayerPosX = _currentPlayerPosX;
                lastTurnWasX = true;
                _currentPlayerPosX = _currentPlayerPosX + 1;
                isPlayersTurn = false;
            }


            if (inputKey.Key == ConsoleKey.W)
            {
                _previousPlayerPosY = _currentPlayerPosY;
                lastTurnWasX = false;
                _currentPlayerPosY = _currentPlayerPosY - 1;
                isPlayersTurn = false;
            }


            if (inputKey.Key == ConsoleKey.S)
            {
                _previousPlayerPosY = _currentPlayerPosY;
                lastTurnWasX = false;
                _currentPlayerPosY = _currentPlayerPosY + 1;
                isPlayersTurn = false;
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

            if (_currentPlayerPosX == enemy._enemyPosX && _currentPlayerPosY == enemy._enemyPosY)
            {
                enemy.UpdateHealth(-1);
                enemy._enemyPosX = 30;
                enemy._enemyPosY = 1;

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
            if (_currentHealth <= 0)
            {
                return;
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(_currentPlayerPosX, _currentPlayerPosY);
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
    }
}
