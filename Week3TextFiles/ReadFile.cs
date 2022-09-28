using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3TextFiles
{
    internal static class ReadFile
    {
        //method to get monsters from file and put them into a list
        public static List<Monsters> GetMonsters()
        {
            //create the list monsters will go into
            List<Monsters> monsters = new List<Monsters>();
            //find the origin file for the monsters
            string path = $@"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\Stats.txt";

            //read file
            //create streamreader
            using (StreamReader sr = new StreamReader(path))
            {
                //while there is a line to read, read it
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //only read lines with a number in them so that the header is ignored
                    if (line.Any(char.IsDigit))
                    {
                        //list items are differentiated by spaces
                        var stats = line.Split(' ');

                        //read each item for each monster
                        string type = stats[0];
                        int hp = int.Parse(stats[1]);
                        int mp = int.Parse(stats[2]);
                        int ap = int.Parse(stats[3]);
                        int def = int.Parse(stats[4]);

                        //create a monster based on stats read
                        Monsters monster = new Monsters(type, hp, mp, ap, def);
                        //add monster to the list
                        monsters.Add(monster);
                    }
                    //stop reading file once there are no more lines to be read
                    else
                    {
                        continue;
                    }
                }

                //dispose of and close the reader
                sr.Dispose();
                sr.Close();
            }

            //return the list of monsters
            return monsters;
        }
    }
}
