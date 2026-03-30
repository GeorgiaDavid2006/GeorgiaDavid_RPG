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
        public BlueEnemy blueEnemy3 = new BlueEnemy(4, 3, 1);
        public BlueEnemy blueEnemy4 = new BlueEnemy(8, 10, 1);
        public BlueEnemy blueEnemy5 = new BlueEnemy(51, 15, 1);
        public BlueEnemy blueEnemy6 = new BlueEnemy(51, 12, 1);
        public BlueEnemy blueEnemy7 = new BlueEnemy(5, 15, 1);
        public BlueEnemy blueEnemy8 = new BlueEnemy(11, 6, 1);
        public BlueEnemy blueEnemy9 = new BlueEnemy(14, 12, 1);
        public BlueEnemy blueEnemy10 = new BlueEnemy(9, 9, 1);
        public BlueEnemy blueEnemy11 = new BlueEnemy(12, 7, 1);
        public BlueEnemy blueEnemy12 = new BlueEnemy(26, 7, 1);
        public BlueEnemy blueEnemy13 = new BlueEnemy(23, 10, 1);
        public BlueEnemy blueEnemy14 = new BlueEnemy(10, 12, 1);
        public BlueEnemy blueEnemy15 = new BlueEnemy(5, 13, 1);
        public BlueEnemy blueEnemy16 = new BlueEnemy(31, 15, 1);
        public BlueEnemy blueEnemy17 = new BlueEnemy(31, 12, 1);
        public BlueEnemy blueEnemy18 = new BlueEnemy(45, 5, 1);
        public BlueEnemy blueEnemy19 = new BlueEnemy(49, 2, 1);
        public BlueEnemy blueEnemy20 = new BlueEnemy(41, 7, 1);
        public BlueEnemy blueEnemy21 = new BlueEnemy(50, 9, 1);
        public BlueEnemy blueEnemy22 = new BlueEnemy(55, 7, 1);
        public BlueEnemy blueEnemy23 = new BlueEnemy(58, 3, 1);
        public BlueEnemy blueEnemy24 = new BlueEnemy(39, 1, 1);
        public BlueEnemy blueEnemy25 = new BlueEnemy(42, 8, 1);

        public PinkEnemy pinkEnemy1 = new PinkEnemy(18, 0, 2);
        public PinkEnemy pinkEnemy2 = new PinkEnemy(23, 8, 2);
        public PinkEnemy pinkEnemy3 = new PinkEnemy(30, 10, 2);
        public PinkEnemy pinkEnemy4 = new PinkEnemy(28, 5, 2);
        public PinkEnemy pinkEnemy5 = new PinkEnemy(28, 8, 2);

        public GreenEnemy greenEnemy1 = new GreenEnemy(10, 0, 3);
        public GreenEnemy greenEnemy2 = new GreenEnemy(43, 4, 3);
        public GreenEnemy greenEnemy3 = new GreenEnemy(55, 2, 3);

        public Gold gold1 = new Gold(3, 3, 1);
        public Gold gold2 = new Gold(5, 6, 1);
        public Gold gold3 = new Gold(10, 8, 1);
        public Gold gold4 = new Gold(11, 2, 1);
        public Gold gold5 = new Gold(6, 9, 1);
        public Gold gold6 = new Gold(7, 8, 1);
        public Gold gold7 = new Gold(9, 9, 1);
        public Gold gold8 = new Gold(15, 7, 1);
        public Gold gold9 = new Gold(11, 6, 1);
        public Gold gold10 = new Gold(40, 9, 1);
        public Gold gold11 = new Gold(1, 8, 1);
        public Gold gold12 = new Gold(9, 15, 1);
        public Gold gold13 = new Gold(45, 7, 1);
        public Gold gold14 = new Gold(52, 9, 1);
        public Gold gold15 = new Gold(50, 6, 1);
        public Gold gold16 = new Gold(49, 9, 1);
        public Gold gold17 = new Gold(48, 5, 1);
        public Gold gold18 = new Gold(56, 6, 1);
        public Gold gold19 = new Gold(59, 9, 1);
        public Gold gold20 = new Gold(20, 1, 1);
        public Gold gold21 = new Gold(24, 2, 1);
        public Gold gold22 = new Gold(30, 2, 1);
        public Gold gold23 = new Gold(16, 1, 1);
        public Gold gold24 = new Gold(51, 3, 1);
        public Gold gold25 = new Gold(47, 3, 1);

        public HealthItem healthItem1 = new HealthItem(25, 14, 1);
        public HealthItem healthItem2 = new HealthItem(7, 10, 1);
        public HealthItem healthItem3 = new HealthItem(30, 7, 1);

        public Gem gem = new Gem(59, 15);

        public Sign sign = new Sign(1, 4);
    }
}
