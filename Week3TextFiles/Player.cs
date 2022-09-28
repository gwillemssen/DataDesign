using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal class Player : ICreatures
    {
        //set properties of player
        public string Type { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int AP { get; set; }
        public int DEF { get; set; }

        //make player and populate properties
        public Player()
        {
            Type = "George";
            Random rand = new Random();
            HP = 200;
            MP = 50;
            AP = rand.Next(40, 50);
            DEF = rand.Next(15, 30);
        }

        //method to check if player is alive
        public bool CheckAlive()
        {
            if (this.HP > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
