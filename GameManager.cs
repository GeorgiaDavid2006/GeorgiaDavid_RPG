using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    class GameManager
    {
        public Map levelMap = new Map();
        public Player player = new Player(5, 5, 0, 0, ConsoleColor.Red);

        public BlueEnemy blueEnemy1 = new BlueEnemy(29, 0, 1);
        public BlueEnemy blueEnemy2 = new BlueEnemy(6, 8, 1);
        public BlueEnemy blueEnemy3 = new BlueEnemy(7, 9, 1);

        public PinkEnemy pinkEnemy1 = new PinkEnemy(18, 0, 2);
        public PinkEnemy pinkEnemy2 = new PinkEnemy(23, 8, 2);

        public GreenEnemy greenEnemy1 = new GreenEnemy(10, 0, 3);
        public GreenEnemy greenEnemy2 = new GreenEnemy(11, 8, 3);

        public Gold gold1 = new Gold(3, 3, 1);
        public Gold gold2 = new Gold(5, 6, 1);
        public Gold gold3 = new Gold(10, 8, 1);
        public Gold gold4 = new Gold(11, 2, 1);
        public Gold gold5 = new Gold(6, 4, 1);

        public HealthItem healthItem1 = new HealthItem(7, 8, 1);
        public HealthItem healthItem2 = new HealthItem(2, 11, 1);
        public HealthItem healthItem3 = new HealthItem(8, 9, 1);

        public Gem gem = new Gem(59, 15, ConsoleColor.Green);
    }
}
