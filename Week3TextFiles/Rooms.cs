using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal class Rooms
    {
        //set properties of rooms
        public string RoomName { get; set; }

        public Monsters Monster { get; set; }

        public bool PlayerWin { get; set; }

        //create room
        public Rooms(string _roomname, Monsters _monster)
        {
            RoomName = _roomname;
            Monster = _monster;
        }

        //method with main logic of game
        public bool Fight(Player player)
        {
            //if player is alive, player will hit monster
            if(player.CheckAlive())
            {
                this.Monster.HP -= player.AP - this.Monster.DEF;
            }

            //if monster is alive, monster will hit player
            if(this.Monster.CheckAlive())
            {
                player.HP -= this.Monster.AP - player.DEF;
            }

            //if monster has died, player wins and moves on
            if(!this.Monster.CheckAlive())
            {
                this.PlayerWin = true;
                return true;
            }

            //if player has died, player loses
            else if(!player.CheckAlive())
            {
                this.PlayerWin = false;
                return true;
            }

            //If both are still alive, do it again
            return Fight(player);
        }
    }
}
