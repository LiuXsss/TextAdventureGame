using System;
using System.Collections.Generic;
using System.Text;

namespace A3_TextAdventure
{
    public class Room
    {
        public string name { get; set; }
        public bool EndRoom { get; set; }
        public string Description { get; set; }

        public Room NorthRoom { get; set; }

        public Room SouthRoom { get; set; }

        public Room EastRoom { get; set; }

        public Room WestRoom { get; set; }

        public Room UpRoom { get; set; }

        public Room DownRoom { get; set; }

        public List<item> items { get; set; }

        public string enemyText { get; set; }

        public void printRoom()
        {
            Console.WriteLine(this.Description);
            if (items.Count > 0)
            {
                foreach (item item in items)
                {
                    Console.WriteLine(item.printText());
                }
            }
            Console.Write(this.enemyText);
        }

    }
}
