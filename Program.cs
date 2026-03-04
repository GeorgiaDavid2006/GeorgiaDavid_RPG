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
        static Map levelMap = new Map();
        static Player player = new Player(5, 5, 1, 1, ConsoleColor.Red);
        static Enemy enemy1 = new Enemy(5, 5, 30, 1, ConsoleColor.Blue);
        static Enemy enemy2 = new Enemy(8, 8, 30, 12, ConsoleColor.Magenta);

        static Gold gold1 = new Gold(3, 3, 1);
        static Gold gold2 = new Gold(5, 6, 1);
        static Gold gold3 = new Gold(10, 8, 1);
        static Gold gold4 = new Gold(11, 2, 1);
        static Gold gold5 = new Gold(6, 4, 1);

        static List<Gold> goldToSpawn = new List<Gold> { gold1, gold2, gold3, gold4, gold5 };

        static HealthItem healthItem1 = new HealthItem(7, 8, 1);
        static HealthItem healthItem2 = new HealthItem(2, 11, 1);
        static HealthItem healthItem3 = new HealthItem(8, 9, 1);

        static List<HealthItem> healthItemsToSpawn = new List<HealthItem> { healthItem1, healthItem2, healthItem3 };

        static bool isGameActive = true;

        static void Main(string[] args)
        {
            levelMap.DrawMap();
            ShowHUD();
            player.DrawPlayer();
            enemy1.DrawEnemy();
            foreach(Gold gold in goldToSpawn)
            {
                gold.DrawGold();
            }
            foreach(HealthItem healthItem in healthItemsToSpawn)
            {
                healthItem.DrawHealthItem();
            }

            while (isGameActive && enemy1._currentHealth > 0)
            {
                Console.SetCursorPosition(0, 0);
                player.PlayerInput(enemy1);
                player.CollectGold(gold1);
                player.CollectGold(gold2);
                player.CollectGold(gold3);
                player.CollectGold(gold4);
                player.CollectGold(gold5);
                player.CollectHealthItem(healthItem1);
                player.CollectHealthItem(healthItem2);
                player.CollectHealthItem(healthItem3);
                levelMap.DrawMap();
                ShowHUD();
                player.DrawPlayer();
                enemy1.MoveEnemy(player);
                enemy1.DrawEnemy();
                foreach(Gold gold in goldToSpawn)
                {
                    gold.DrawGold();
                }
                foreach (HealthItem healthItem in healthItemsToSpawn)
                {
                    healthItem.DrawHealthItem();
                }
                Thread.Sleep(100);

                if (player._currentHealth <= 0)
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

            while (isGameActive && enemy1._currentHealth <= 0)
            {
                Console.SetCursorPosition(0, 0);
                player.PlayerInput(enemy2);
                player.CollectGold(gold1);
                player.CollectGold(gold2);
                player.CollectGold(gold3);
                player.CollectGold(gold4);
                player.CollectGold(gold5);
                player.CollectHealthItem(healthItem1);
                player.CollectHealthItem(healthItem2);
                player.CollectHealthItem(healthItem3);
                levelMap.DrawMap();
                ShowHUD();
                player.DrawPlayer();
                enemy2.MoveEnemy(player);
                enemy2.DrawEnemy();
                foreach (Gold gold in goldToSpawn)
                {
                    gold.DrawGold();
                }
                foreach (HealthItem healthItem in healthItemsToSpawn)
                {
                    healthItem.DrawHealthItem();
                }
                Thread.Sleep(100);

                if (player._currentHealth <= 0)
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

        static void ShowHUD()
        {
            if (enemy1._currentHealth > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player Health: " + player._currentHealth);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enemy1 Health: " + enemy1._currentHealth);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Gold = " + player._amountOfGold);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player Health: " + player._currentHealth);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enemy2 Health: " + enemy2._currentHealth);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Gold = " + player._amountOfGold);
            }
        }
    }
}
