using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal class Game
    {
        //create list for rooms
        public List<Rooms> Rooms { get; set; }

        //create a list and adding room objects after creating the room objects
        public Game(List<Monsters> _monsters)
        {
            Rooms = new List<Rooms>();
            Rooms.Add(new Rooms("Knight Room", _monsters[0]));
            Rooms.Add(new Rooms("Mage Room", _monsters[1]));
            Rooms.Add(new Rooms("Dwarf Room", _monsters[2]));
        }

        //starts game and waits until game has ended, then ends the game
        public void GameObserver(Player _player)
        {
            bool isGameGo = true;

            while(isGameGo)
            {
                isGameGo = PlayGame(_player);
            }

            GameEnd();
        }

        //method to play game
        public bool PlayGame(Player _player)
        {
            //gets room player has chosen and sets it equal to chosen room
            Rooms chosenRoom = ShowRooms(this.Rooms);
            //number of rooms player has completed thus far
            int roomsCompleted = 0;

            //if fight is over, decide who won
            if (chosenRoom.Fight(_player) == true)
            {
                //increase number of rooms completed and tell player they have won
                if(chosenRoom.PlayerWin)
                {
                    roomsCompleted++;
                    Console.WriteLine("Player has won against the monster!");
                    //see if there are more rooms for player to complete
                    //if so, continue fight
                    if (roomsCompleted >= this.Rooms.Count)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                //if player has lost, tell them and end the game
                else if(!chosenRoom.PlayerWin)
                {
                    Console.WriteLine("Monster has triumphed! Try again.");
                    return false;
                }
            }

            return false;
        }

        //method creating nodes for linked list and exporting results to file
        public void GameEnd()
        {
            //create list
            List<DoublyList> nodes = new List<DoublyList>();

            //create each node
            DoublyList roomOneNode = new DoublyList(true, false, this.Rooms[0]);
            DoublyList roomTwoNode = new DoublyList(false, false, this.Rooms[1]);
            DoublyList roomThreeNode = new DoublyList(false, true, this.Rooms[2]);

            //tell nodes where they are pointing
            roomOneNode.Next = roomTwoNode;
            roomTwoNode.Next = roomThreeNode;
            roomTwoNode.Previous = roomOneNode;
            roomThreeNode.Previous = roomTwoNode;

            //add created nodes to list
            nodes.Add(roomOneNode);
            nodes.Add(roomTwoNode);
            nodes.Add(roomThreeNode);

            //print results for each node
            foreach (var node in nodes)
            {
                if (node.Room.PlayerWin)
                {
                    node.Result = $"Player survived in {node.Room.RoomName}!";
                }
                else
                {
                    node.Result = $"Player did not survive in {node.Room.RoomName}";
                }
            }

            //write nodes to result file and tell player game is over
            WriteFile.WriteResult(roomOneNode);
            Console.WriteLine("Game has finished. Results have been recorded inside Results file in directory!");
        }

        //show player rooms to choose from
        public Rooms ShowRooms(List<Rooms> _rooms)
        {
            //hide rooms player has already completed from player choice
            foreach (Rooms room in _rooms.Where(r => !r.PlayerWin))
            {
                Console.WriteLine($"{room.RoomName} - {_rooms.IndexOf(room)}");
            }

            Console.WriteLine("Enter the number of the room you wish to enter.");
            return _rooms[CheckInput()];
            
        }

        //check that the player enters a valid room number
        public int CheckInput()
        {
            string input = Console.ReadLine();
            if(input == "0" || input == "1" || input == "2")
            {
                return Int32.Parse(input);
            }
            else
            {
                Console.WriteLine("Please enter a valid room number.");
                return CheckInput();
            }
        }
    }
}
