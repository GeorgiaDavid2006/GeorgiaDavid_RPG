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
                player.PlayerInput(enemy);
                levelMap.DrawMap();
                ShowHUD();
                player.DrawPlayer();
                enemy.MoveEnemy(player);
                enemy.DrawEnemy();
                Thread.Sleep(100);
            }
        }

        static void ShowHUD()
        {
            
        }
    }
}
