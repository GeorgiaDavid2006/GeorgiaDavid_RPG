using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Program
    {
        static bool isGameActive = true;

        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            List<Gold> goldToSpawn = new List<Gold> { gameManager.gold1, gameManager.gold2, gameManager.gold3, gameManager.gold4, gameManager.gold5 };
            List<HealthItem> healthItemsToSpawn = new List<HealthItem> { gameManager.healthItem1, gameManager.healthItem2, gameManager.healthItem3 };

            gameManager.levelMap.DrawMap();
            ShowHUD(gameManager);
            gameManager.player.DrawPlayer();
            gameManager.enemy1.DrawEnemy();
            foreach(Gold gold in goldToSpawn)
            {
                gold.DrawGold();
            }
            foreach(HealthItem healthItem in healthItemsToSpawn)
            {
                healthItem.DrawHealthItem();
            }

            while (isGameActive && gameManager.enemy1._currentHealth > 0)
            {
                Console.SetCursorPosition(0, 0);
                gameManager.player.PlayerInput(gameManager.enemy1);
                gameManager.player.CollectGold(gameManager.gold1);
                gameManager.player.CollectGold(gameManager.gold2);
                gameManager.player.CollectGold(gameManager.gold3);
                gameManager.player.CollectGold(gameManager.gold4);
                gameManager.player.CollectGold(gameManager.gold5);
                gameManager.player.CollectHealthItem(gameManager.healthItem1);
                gameManager.player.CollectHealthItem(gameManager.healthItem2);
                gameManager.player.CollectHealthItem(gameManager.healthItem3);
                gameManager.levelMap.DrawMap();
                ShowHUD(gameManager);
                gameManager.player.DrawPlayer();
                gameManager.enemy1.MoveEnemy(gameManager.player);
                gameManager.enemy1.DrawEnemy();
                foreach(Gold gold in goldToSpawn)
                {
                    gold.DrawGold();
                }
                foreach (HealthItem healthItem in healthItemsToSpawn)
                {
                    healthItem.DrawHealthItem();
                }
                Thread.Sleep(100);

                if (gameManager.player._currentHealth <= 0)
                {
                    isGameActive = false;
                }
            }

            if (!isGameActive)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Game Over!");
                Console.ReadKey();
            }

            while (isGameActive && gameManager.enemy1._currentHealth <= 0)
            {
                Console.SetCursorPosition(0, 0);
                gameManager.player.PlayerInput(gameManager.enemy2);
                gameManager.player.CollectGold(gameManager.gold1);
                gameManager.player.CollectGold(gameManager.gold2);
                gameManager.player.CollectGold(gameManager.gold3);
                gameManager.player.CollectGold(gameManager.gold4);
                gameManager.player.CollectGold(gameManager.gold5);
                gameManager.player.CollectHealthItem(gameManager.healthItem1);
                gameManager.player.CollectHealthItem(gameManager.healthItem2);
                gameManager.player.CollectHealthItem(gameManager.healthItem3);
                gameManager.levelMap.DrawMap();
                ShowHUD(gameManager);
                gameManager.player.DrawPlayer();
                gameManager.enemy2.MoveEnemy(gameManager.player);
                gameManager.enemy2.DrawEnemy();
                foreach (Gold gold in goldToSpawn)
                {
                    gold.DrawGold();
                }
                foreach (HealthItem healthItem in healthItemsToSpawn)
                {
                    healthItem.DrawHealthItem();
                }
                Thread.Sleep(100);

                if (gameManager.player._currentHealth <= 0)
                {
                    isGameActive = false;
                }
            }

            if (!isGameActive)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Game Over!");
                Console.ReadKey();
            }
        }

        static void ShowHUD(GameManager gameManager)
        {
            if (gameManager.enemy1._currentHealth > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player Health: " + gameManager.player._currentHealth);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enemy1 Health: " + gameManager.enemy1._currentHealth);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Gold = " + gameManager.player._amountOfGold);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player Health: " + gameManager.player._currentHealth);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enemy2 Health: " + gameManager.enemy2._currentHealth);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Gold = " + gameManager.player._amountOfGold);
            }
        }
    }
}
