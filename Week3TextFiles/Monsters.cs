using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal class Monsters : ICreatures
    {
        //set properties of monsters
        public string Type { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int AP { get; set; }
        public int DEF { get; set; }

        //create monster
        public Monsters(string _type, int _hp, int _mp, int _ap, int _def)
        {
            Type = _type;
            HP = _hp; 
            MP = _mp; 
            AP = _ap; 
            DEF = _def;
        }

        //method to check if monster is alive
        public bool CheckAlive()
        {
            if(this.HP > 0)
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
