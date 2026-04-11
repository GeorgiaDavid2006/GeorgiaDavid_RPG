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
            gameManager.healthItem2, gameManager.healthItem3, gameManager.gem, gameManager.sign, gameManager.key};

            gameManager.Init(gameManager, enemyManager, itemManager);

            while (gameManager.isGameActive && gameManager.player.hasWon == false)
            {
                gameManager.Update(gameManager, enemyManager, itemManager);
            }

            if (gameManager.isGameActive == false)
            {
                gameManager.GameOver();
            }

            if(gameManager.player.hasWon == true)
            {
                gameManager.Win();
            }
        }
    }
}
