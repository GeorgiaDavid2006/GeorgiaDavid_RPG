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

            EnemyManager enemyManager = new EnemyManager();

            ItemManager itemManager = new ItemManager();

            enemyManager.enemies = new List<Enemy>{ gameManager.blueEnemy1, gameManager.blueEnemy2, gameManager.blueEnemy3, gameManager.blueEnemy4, gameManager.blueEnemy5, gameManager.blueEnemy6,
            gameManager.blueEnemy7, gameManager.blueEnemy8, gameManager.blueEnemy9, gameManager.blueEnemy10, gameManager.blueEnemy11, gameManager.blueEnemy12, gameManager.blueEnemy13, gameManager.blueEnemy14,
            gameManager.blueEnemy15, gameManager.blueEnemy16, gameManager.blueEnemy17, gameManager.blueEnemy18, gameManager.blueEnemy19, gameManager.blueEnemy20, gameManager.blueEnemy21,
            gameManager.blueEnemy22, gameManager.blueEnemy23, gameManager.blueEnemy24, gameManager.blueEnemy25, gameManager.pinkEnemy1, gameManager.pinkEnemy2, gameManager.pinkEnemy3, gameManager.pinkEnemy4,
            gameManager.pinkEnemy5, gameManager.greenEnemy1, gameManager.greenEnemy2, gameManager.greenEnemy3};

            itemManager.items = new List<Item> { gameManager.gold1, gameManager.gold2, gameManager.gold3, gameManager.gold4, gameManager.gold5, gameManager.gold6, gameManager.gold7, gameManager.gold8,
            gameManager.gold9, gameManager.gold10, gameManager.gold11, gameManager.gold12, gameManager.gold13, gameManager.gold14, gameManager.gold15, gameManager.gold16, gameManager.gold17,
            gameManager.gold18, gameManager.gold19, gameManager.gold20, gameManager.gold21, gameManager.gold22, gameManager.gold23, gameManager.gold24, gameManager.gold25, gameManager.healthItem1, 
            gameManager.healthItem2, gameManager.healthItem3, gameManager.gem, gameManager.sign};

            gameManager.levelMap.DrawMap();
            ShowHUD(gameManager);
            gameManager.player.DrawPlayer();
            //foreach(Enemy enemiesToSpawn in enemyManager.enemies)
            //{
            //    enemiesToSpawn.DrawEnemy();
            //}
            //foreach(Item item in itemManager.items)
            //{
            //    item.DrawItem();
            //}

            while (isGameActive && gameManager.player.hasWon == false)
            {
                Console.SetCursorPosition(0, 0);
                gameManager.player.PlayerInput(enemyManager.enemies);
                //foreach(Item item in itemManager.items)
                //{
                //    item.CollectItem(gameManager.player);
                //}
                gameManager.levelMap.DrawMap();
                ShowHUD(gameManager);
                gameManager.player.DrawPlayer();
                //foreach (Enemy enemiesToSpawn in enemyManager.enemies)
                //{
                //    enemiesToSpawn.MoveEnemy(gameManager.player);
                //    enemiesToSpawn.DrawEnemy();
                //}
                gameManager.player.isPlayersTurn = true;
                //foreach (Item item in itemManager.items)
                //{
                //    item.DrawItem();
                //}
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
                Console.WriteLine("Play again?");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    isGameActive = true;
                }

                else if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.Clear();
                }
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
            if (gameManager.sign.wasRead == true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Many powerful enemies inside of the treasure trove, enter at your own risk");
            }
        }
    }
}
