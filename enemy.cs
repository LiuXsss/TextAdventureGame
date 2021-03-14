using System;
using System.Collections.Generic;
using System.Text;

namespace A3_TextAdventure
{
    public class enemy: IAttackable
    {
        public string name;

        public Room currentRoom;

        public bool IsDestroyed { get; set; }
        public void move()
        {
            if (!this.IsDestroyed) 
            {
                Random move = new Random();

                int validDirection = 0;

                List<Room> moveTo = new List<Room>();

                if (currentRoom.NorthRoom != null)
                {
                    validDirection++;
                    moveTo.Add(currentRoom.NorthRoom);
                }
                if (currentRoom.SouthRoom != null)
                {
                    validDirection++;
                    moveTo.Add(currentRoom.SouthRoom);
                }
                if (currentRoom.EastRoom != null)
                {
                    validDirection++;
                    moveTo.Add(currentRoom.EastRoom);
                }
                if (currentRoom.WestRoom != null)
                {
                    validDirection++;
                    moveTo.Add(currentRoom.WestRoom);
                }
                if (currentRoom.UpRoom != null)
                {
                    validDirection++;
                    moveTo.Add(currentRoom.UpRoom);
                }
                if (currentRoom.DownRoom != null)
                {
                    validDirection++;
                    moveTo.Add(currentRoom.DownRoom);
                }

                int randIndex = move.Next(validDirection);
                currentRoom = moveTo[randIndex];
            }
            
        }
    }
}
