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

            List<Enemy> enemies = new List<Enemy> { gameManager.blueEnemy1, gameManager.blueEnemy2, gameManager.blueEnemy3, gameManager.pinkEnemy1, gameManager.pinkEnemy2,
            gameManager.greenEnemy1, gameManager.greenEnemy2};

            List<Gold> goldToSpawn = new List<Gold> { gameManager.gold1, gameManager.gold2, gameManager.gold3, gameManager.gold4, gameManager.gold5 };

            List<HealthItem> healthItemsToSpawn = new List<HealthItem> { gameManager.healthItem1, gameManager.healthItem2, gameManager.healthItem3 };

            gameManager.levelMap.DrawMap();
            ShowHUD(gameManager);
            gameManager.player.DrawPlayer();
            foreach(Enemy enemiesToSpawn in enemies)
            {
                enemiesToSpawn.DrawEnemy();
            }
            foreach(Gold gold in goldToSpawn)
            {
                gold.DrawGold();
            }
            foreach(HealthItem healthItem in healthItemsToSpawn)
            {
                healthItem.DrawHealthItem();
            }
            gameManager.gem.DrawGem();

            while (isGameActive && gameManager.player.hasWon == false)
            {
                Console.SetCursorPosition(0, 0);
                gameManager.player.PlayerInput(enemies);
                gameManager.player.CollectGold(gameManager.gold1);
                gameManager.player.CollectGold(gameManager.gold2);
                gameManager.player.CollectGold(gameManager.gold3);
                gameManager.player.CollectGold(gameManager.gold4);
                gameManager.player.CollectGold(gameManager.gold5);
                gameManager.player.CollectHealthItem(gameManager.healthItem1);
                gameManager.player.CollectHealthItem(gameManager.healthItem2);
                gameManager.player.CollectHealthItem(gameManager.healthItem3);
                gameManager.player.CollectGem(gameManager.gem);
                gameManager.levelMap.DrawMap();
                ShowHUD(gameManager);
                gameManager.player.DrawPlayer();
                foreach (Enemy enemiesToSpawn in enemies)
                {
                    enemiesToSpawn.MoveEnemy(gameManager.player);
                    enemiesToSpawn.DrawEnemy();
                }
                foreach (Gold gold in goldToSpawn)
                {
                    gold.DrawGold();
                }
                foreach (HealthItem healthItem in healthItemsToSpawn)
                {
                    healthItem.DrawHealthItem();
                }
                gameManager.gem.DrawGem();
                Thread.Sleep(100);

                if (gameManager.player.playerHealthSystem._currentHealth <= 0)
                {
                    isGameActive = false;
                }
            }

            if (isGameActive == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Game Over!");
                Console.ReadKey();
            }

            if(gameManager.player.hasWon == true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Level Clear");
                Console.ReadKey();
            }
        }

        static void ShowHUD(GameManager gameManager)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player Health: " + gameManager.player.playerHealthSystem._currentHealth);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Gold = " + gameManager.player._amountOfGold);
        }
    }
}
