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
        static Enemy enemy = new Enemy(5, 5, 30, 1, ConsoleColor.Blue);

        static bool isGameActive = true;
        static bool isEnemyAlive = true;

        static void Main(string[] args)
        {
            levelMap.DrawMap();
            ShowHUD();
            player.DrawPlayer();
            enemy.DrawEnemy();

            while (isGameActive && isEnemyAlive)
            {
                
            }

            while(isGameActive && !isEnemyAlive)
            {

            }
        }

        static void ShowHUD()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player Health: " + player._currentHealth);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enemy Health: " + enemy._currentHealth);
        }
    }
}
