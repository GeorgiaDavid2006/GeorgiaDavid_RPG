using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_RPG
{
    internal class Map
    {
        string[] map;

        public Map()
        {
            string path = @"Map.Txt";

            map = File.ReadAllLines(path);
        }

        void DrawMap()
        {

        }
    }
}
