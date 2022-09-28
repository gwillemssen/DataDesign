using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal interface ICreatures
    {
        //set properties of all creatures in game (player and monsters)
        public string Type { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int AP { get; set; }
        public int DEF { get; set; }

        //method to check if creature is alive
        public bool CheckAlive();
    }
}
