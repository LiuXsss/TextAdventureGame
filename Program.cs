using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace A3_TextAdventure
{
    class Program
    {
        const string N = "north";
        const string S = "south";
        const string E = "east";
        const string W = "west";
        const string U = "up";
        const string D = "down";
                
        /*
        public const string Entrance_Hall = "You are in the entrance hall. There is a door to the north.";
        public const string Living_Room = "You are in the living room. There are doors to the north, south, east, and west. There is a trophy case here, and a large oriental rug in the center of the room. Above the trophy case hangs an elvish sword of great antiquity.";
        public const string Kitchen = "You are in the kitchen. A table seems to have been used recently for the preparation of food. A passage leads to the west. Sitting on the kitchen table is a brown sack smelling of peppers, and a glass of water.";
        public const string Paiting_Room = "You are in the painting room. There is a harpsichord, and a large medieval oil painting. The painting depicts a skeleton holding open a gateway to an underground passage. A male elf is entering the passage. A female elf is holding a strange orb. A human man stands to the side observing.";
        public const string Fancy_Bedroom = "You are in the fancy bedroom. There is a four-poster bed with red sheets. There is a closed chest at the foot of the bed. There are a set of boots with climbing spikes next to the chest.";
        public const string Error_Message = "Cannot move in that direction.";
        */
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine(game.begain);

            static void ErrorMessage()
            {
                Console.WriteLine("Cannot move in that direction.");
            };

            while (true)
            {

                game._currentRoom.printRoom();
                if (game._currentRoom == game.Troll.currentRoom && game.Troll.IsDestroyed == false)
                {
                    Console.WriteLine("A Troll is in the same room with you! Be careful!");
                }
                if (game._currentRoom.EndRoom)
                {
                    break;
                }



                Console.Write(">");

               

                string input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    game.gamer.point = 0;
                    Console.WriteLine("You lost in that house, and have no chance to escape...");
                    Console.WriteLine("'Try again player' you hear some voice from the darkness...");
                    break;
                }

                if (input == "save game")
                {
                    TextWriter writer = null;
                    try
                    {
                        var serializer = new XmlSerializer(typeof(Game));
                        writer = new StreamWriter("SaveGame.xml");
                        serializer.Serialize(writer, game);
                        Console.WriteLine("Your game is saved!");
                    }
                    finally
                    {
                        if (writer != null)
                            writer.Close();
                    }
                    

                    //LoadGame load = LoadGame.Instance;
                    //load.Save(game);
                    //game.Save(game);
                    continue;
                }

                if(input == "load game")
                {
                    //game = game.Load(game);
                    //LoadGame load = LoadGame.Instance;
                    //load.Load(game);
                    TextReader reader = null;
                    try
                    {
                        var serializer = new XmlSerializer(typeof(Game));
                        reader = new StreamReader("SaveGame.xml");
                        game = (Game)serializer.Deserialize(reader);
                    }
                    finally
                    {
                        if (reader != null)
                            reader.Close();
                    }
                    Console.WriteLine("You load your previous game!");



                    continue;
                }

                if (input.StartsWith("pick up "))
                {
                    string target = input.Substring(8).ToLower();
                    if (game._currentRoom.items.Count > 0)
                    {
                        bool CanPick = false;
                        foreach (item item in game._currentRoom.items.ToList())
                        {
                            if (item.name == target)
                            {
                                CanPick = true;
                                game.gamer.Bag.Add(item);
                                game.gamer.point += item.value;
                                game._currentRoom.items.Remove(item);
                                if (target == "elven book")
                                {
                                    Console.WriteLine("You pick up a book and suddenly a seccret path apear.");
                                    if (game.Troll.currentRoom == game._currentRoom && !game.Troll.IsDestroyed)
                                    {
                                        Console.WriteLine("Now, you escape from the monster, but you don't know if it still behind you!");
                                    }
                                    game._currentRoom = game._currentRoom.NorthRoom;
                                    game.Troll.move();
                                }
                            }
                        }
                        if (!CanPick)
                        {
                            Console.WriteLine("Can't find the item!");
                        }
                    }
                    
                    continue;
                }
                else if (input.StartsWith("drop "))
                {
                    if (game.gamer.Bag.Count > 0)
                    {
                        bool CanDrop = false;
                        string target = input.Substring(5).ToLower();
                        foreach (item item in game.gamer.Bag.ToList())
                        {
                            if (item.name == target)
                            {
                                CanDrop = true;
                                game._currentRoom.items.Add(item);
                                game.gamer.Bag.Remove(item);
                                game.gamer.point -= item.value;
                            }
                        }
                        if (!CanDrop)
                        {
                            Console.WriteLine("Can't find the item!");
                        }
                    }
                    continue;
                }
                else if (input.StartsWith("describe "))
                {

                    bool CanDes = false;
                    string target = input.Substring(9).ToLower();
                    if (game.gamer.Bag.Count > 0)
                    {
                        foreach (item item in game.gamer.Bag.ToList())
                        {
                            if (item.name == target)
                            {
                                CanDes = true;
                                Console.WriteLine($"{item.name}: {item.description}");
                            }
                        }
                    }
                    if (game._currentRoom.items.Count > 0)
                    {
                        foreach (item item in game._currentRoom.items.ToList())
                        {
                            if (item.name == target)
                            {   
                                CanDes = true;
                                Console.WriteLine($"{item.name}: {item.description}");
                            }
                        }
                    }
                    if (!CanDes)
                    {
                            Console.WriteLine("Can't find the item!");
                    }
                    continue;
                } else if(input == "my bag")
                {
                    if (game.gamer.Bag.Count > 0) {
                        Console.Write("Bag: ");
                        foreach (item item in game.gamer.Bag.ToList())
                        {
                            Console.Write(item.name + "  ");
                        }
                        Console.WriteLine();
                    } else
                    {
                        Console.WriteLine("Your bag is empty.");
                    }
                    continue;
                } else if (input.StartsWith("attack"))
                {
                    // regular expressions are great for parsing text. Most languages have them in the standard library.
                    // must add "using System.Text.RegularExpressions;" to imports in order to use
                    var regex = new Regex(@"attack ([\w\s]+) with ([\w\s]+)", RegexOptions.IgnoreCase);
                    var match = regex.Match(input);
                    if (match.Success)
                    {
                        string attackableName = match.Groups[1].Value.ToLower();
                        string weaponName = match.Groups[2].Value.ToLower();
                        // find matching weapon
                        IWeapon weapon = game.FindWeapon(weaponName);
                        // find matching enemy in room
                        IAttackable attackable = game.FindAttackable(attackableName);

                        if (weapon != null && attackable != null)
                        {
                            game.Attack(weapon, attackable);
                            if (attackableName == game.Troll.name)
                            {
                                game.Troll.currentRoom.enemyText = "Troll lies destroyed here.\n";
                                Console.WriteLine($"{attackableName} was struck with {weaponName}!");
                            } else
                            {
                                Console.WriteLine($"{attackableName} was destroyed by {weaponName}!");
                            }

                        }
                    }
                    continue;

                }

                switch (input)
                {
                    case N:
                        if (game._currentRoom == game._library)
                        {
                            bool pass = false;
                            foreach (item item in game.gamer.Bag.ToList())
                            {
                                if (item.name == "elven book")
                                {
                                    pass = true;
                                }
                            }
                            if (!pass)
                            {
                                Console.WriteLine("There seems has a path but you can't get in.");
                            } else
                            {
                                game.checkEnemy();
                                game._currentRoom = game._currentRoom.NorthRoom;
                                game.Troll.move();
                            }

                        } else 
                        if (game._currentRoom.NorthRoom == game._skeletonRoom)
                        {
                            bool Pass = false;
                            foreach (item item in game.gamer.Bag.ToList())
                            {
                                if (item.name == "skeleton holding")
                                {
                                    Pass = true;
                                    game.checkEnemy();
                                    game._currentRoom = game._currentRoom.NorthRoom;
                                    game.Troll.move();
                                }
                            }
                            if (!Pass)
                            {
                                Console.WriteLine("There are something provent you from the door.");
                            }
                        } else if(game._currentRoom.NorthRoom != null)
                        {
                            game.checkEnemy();
                            game._currentRoom = game._currentRoom.NorthRoom;
                            game.Troll.move();
                        } else
                        {
                            ErrorMessage();
                        }
                        break;
                    case S:
                        if (game._currentRoom.SouthRoom != null)
                        {
                            game.checkEnemy();
                            game._currentRoom = game._currentRoom.SouthRoom;
                            game.Troll.move();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    case W:
                        if (game._currentRoom.WestRoom != null)
                        {
                            game.checkEnemy();
                            game._currentRoom = game._currentRoom.WestRoom;
                            game.Troll.move();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    case E:
                        if (game._currentRoom.EastRoom != null)
                        {
                            game.checkEnemy();
                            game._currentRoom = game._currentRoom.EastRoom;
                            game.Troll.move();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    case U:
                        if (game._currentRoom.UpRoom != null)
                        {
                            game.checkEnemy();
                            game._currentRoom = game._currentRoom.UpRoom;
                            game.Troll.move();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    case D:
                        if (game._currentRoom.DownRoom != null)
                        {
                            game.checkEnemy();
                            game._currentRoom = game._currentRoom.DownRoom;
                            game.Troll.move();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                        break;
                    default:
                        ErrorMessage();
                        break;
                }

                if (game.gamer.IsDestroyed)
                {
                    Console.WriteLine("The Troll attacks and slays you!");
                    game.gamer.point = 0;
                    break;
                }

                if (!game.Troll.IsDestroyed)
                {
                    Console.WriteLine($"Troll is now in {game.Troll.currentRoom.name}!");
                }

                /*
                if (currentRoom == "entrance hall")
                {
                    if (input == N)
                    {
                        currentRoom = "living room";
                        Console.WriteLine(Living_Room);
                    }
                    else
                    {
                        Console.WriteLine(Error_Message);
                        Console.WriteLine(Entrance_Hall);
                    }
                }

                else if (currentRoom == "living room")
                {
                    if (input == N)
                    {
                        currentRoom = "fancy bedroom";
                        Console.WriteLine(Fancy_Bedroom);
                    }
                    else if (input == S)
                    {
                        currentRoom = "entrance hall";
                        Console.WriteLine(Entrance_Hall);
                    }
                    else if (input == E)
                    {
                        currentRoom = "kitchen";
                        Console.WriteLine(Kitchen);
                    }
                    else if (input == W)
                    {
                        currentRoom = "painting room";
                        Console.WriteLine(Paiting_Room);
                    }
                    else
                    {
                        Console.WriteLine(Error_Message);
                        Console.WriteLine(Living_Room);
                    }
                }

                else if (currentRoom == "kitchen")
                {
                    if (input == W)
                    {
                        currentRoom = "living room";
                        Console.WriteLine(Living_Room);
                    }
                    else
                    {
                        Console.WriteLine(Error_Message);
                        Console.WriteLine(Kitchen);
                    }
                }

                else if (currentRoom == "painting room")
                {
                    if (input == E)
                    {
                        currentRoom = "living room";
                        Console.WriteLine(Living_Room);
                    }
                    else
                    {
                        Console.WriteLine(Error_Message);
                        Console.WriteLine(Paiting_Room);
                    }
                }

                else if (currentRoom == "fancy bedroom")
                {
                    if (input == S)
                    {
                        currentRoom = "living room";
                        Console.WriteLine(Living_Room);
                    }
                    else
                    {
                        Console.WriteLine(Error_Message);
                        Console.WriteLine(Fancy_Bedroom);
                    }
                }
                */

            }
            Console.WriteLine($"You get {game.gamer.point} point!");

        }
    }
}
