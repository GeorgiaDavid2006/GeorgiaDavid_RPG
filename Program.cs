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

        static bool isGameActive = true;

        static void Main(string[] args)
        {
            levelMap.DrawMap();
            ShowHUD();
            player.DrawPlayer();
            enemy1.DrawEnemy();

            while (isGameActive && enemy1._currentHealth > 0)
            {
                Console.SetCursorPosition(0, 0);
                player.PlayerInput(enemy1);
                levelMap.DrawMap();
                ShowHUD();
                player.DrawPlayer();
                enemy1.MoveEnemy(player);
                enemy1.DrawEnemy();
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
                levelMap.DrawMap();
                ShowHUD();
                player.DrawPlayer();
                enemy2.MoveEnemy(player);
                enemy2.DrawEnemy();
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
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player Health: " + player._currentHealth);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enemy2 Health: " + enemy2._currentHealth);
            }
        }
    }
}
