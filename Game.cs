using System;
using System.Collections.Generic;
using System.Text;

namespace A3_TextAdventure
{
    public class Game
    {
/*        public static Game saveGame = new Game();

        public void Save(Game currentGame)
        {
            saveGame._outside = currentGame._outside;
            saveGame._entranceHall = currentGame._entranceHall;
            saveGame._livingRoom = currentGame._livingRoom;
            saveGame.gamer = currentGame.gamer;
            saveGame._currentRoom = currentGame._currentRoom;
        }

        public void Load(Game currentGame)
        {
            currentGame._outside = saveGame._outside;
            currentGame._entranceHall = saveGame._entranceHall;
            currentGame._livingRoom = saveGame._livingRoom;
            currentGame.gamer = saveGame.gamer;
            currentGame._currentRoom = saveGame._currentRoom;
        }

        public List<Room> RoomList = new List<Room>();*/

        public Room _currentRoom;

        public string begain = "Weeks ago, you received a mysterious letter claiming that your late grandfather (who you don't know anything about) left you his house and land in the mountains. Having no property yourself, this is a substantial inheritance. After a few days of hiking into the countryside, you come upon the house, opulent and imperial, standing proudly against the hills leading into the mountain behind it.";

        public Room _outside = new Room()
        {
            name = "outside",
            Description = "You decide to take what you've already found and leave. Something about this place unnerves you, and you never return.", 
            items = new List<item>(), 
            EndRoom = true 
        };

        public Room _entranceHall = new Room()
        {
            name = "Entrance Hall",
            Description = "You are in the entrance hall. There is a door leading further into the house to the north, and an exit to the south.",
            items = new List<item>(),
        };

        public Room _livingRoom = new Room()
        {
            name = "Living Room",
            Description = "You are in the living room. There are doors to the north, south, east, and west. There is a staircase going down. There is a trophy case here, and a large oriental rug in the center of the room. Above the trophy case hangs an elvish sword of great antiquity.",
            items = new List<item>()
            {
                 new canAttackedItem { name = "trophy case", description = "A trophy case containing a massive golden cup", value = 150 },
                 new weapon { name = "elven sword", description = "A leaf-bladed longsword, elven crafted.", value = 150},
                 new item { name = "fancy rug", description = "A large, oriental-style rug with exceptional craftsmanship.", value = 100 },

            },
            

        };
        public Room _kitchen = new Room()
        {
            name = "Kitchen",
            Description = "You are in the kitchen. A table seems to have been used recently for the preparation of food. A passage leads to the west. Sitting on the kitchen table is a brown sack smelling of peppers, and a glass of water.",
            items = new List<item>()
            {
                new item { name = "sack of peppers", description = "A brown sack containing spicy green peppers.", value = 1 },
                new item { name = "glass of water", description = "A refreshing glass of cold water.", value = 1 },
    
        }
        };
        public Room _paintingRoom = new Room()
        {
            name = "Painting Room",
            Description = "You are in the painting room. There is a Harpsichord. A painting depicts a skeleton holding open a gateway to an underground passage. A male elf is entering the passage. A female elf is holding a strange orb. A human man stands to the side observing.",
            items = new List<item>()
            {
                new canAttackedItem { name = "harpsichord", description = "An incredibly heavy harpsichord.", value = 300},
                new item { name = "oil painting", description = "The painting depicts a skeleton holding open a gateway to an underground passage. A male elf is entering the passage. A female elf is holding a strange orb. A human man stands to the side observing.", value = 150 },
                new weapon { name = "skeleton holding", description = "There are some unknow feeling when you stare at the skeleton.", value = 13 },
            }
        };
        public Room _fancyBedroom = new Room()
        {
            name = "Fancy Bedroom",
            Description = "You are in the fancy bedroom. There is a four-poster bed with red sheets. There is a closed chest at the foot of the bed. There are a set of boots with climbing spikes next to the chest.",
            items = new List<item>()
            {
                new item { name = "boots", description = "Tough boots with spikes for climbing.", value = 10 },
                new canAttackedItem { name = "sheets", description = "Fancy silk sheets", value = 50},
                new item { name = "gold", description = "Shiny gold coins.", value = 100 },

            }
        };
        public Room _cellar = new Room()
        {
            name = "Cellar",
            Description = "You are in a tidy cellar. There are barrels of wine here. A door leads to the north, and a staircase goes up.",
            items = new List<item>()
            {
                new item { name = "wine", description = "A bottle of fine wine.", value = 50 },
            }
        };
        public Room _library = new Room()
        {
            name = "Library",
            Description = "You are in a large library. There are many books about anatomy, history, and alchemy. Some of the books are written in Elven. There is a door to the south.",
            items = new List<item>()
            {
                new item { name = "necklace", description = "A ruby necklace.", value = 125 },
                new weapon { name = "elven book", description = "A tome written in the indecipherable elven dialect.", value = 100},

            }           
        };
        public Room _laboratory = new Room()
        {
            name = "Laboratory",
            Description = "You find yourself in a strange laboratory. A lamp with a red filter lights the room. There is a secret passage to the south. There is a door with a skull to the north.",
            items = new List<item>()
            {
                 new canAttackedItem { name = "orb", description = "The Orb of Yendor, an ancient artifact that has been missing for many years.", value = 500},
                 new canAttackedItem { name = "flask", description = "A flask encrusted with gems.", value = 200 },
                 new item { name = "lamp", description = "A lamp with a ruby-tinted filter.", value = 30 },

            }
        };
        public Room _skeletonRoom = new Room()
        {
            name = "Skeleton Room",
            Description = "The strange door opens into darkness. You peer in, and a pair of skeletal hands reach out and drags you in! The last thing you see is a strange underground passage before the last of the light disappears.\n THE END.",
            items = new List<item>(),
            EndRoom = true,
        };
        /*
                private item _trophy = new item()
                {
                    name = "Trophy",
                };
                private item _sword = new item()
                {
                    name = "Sword",
                };
                private item _rug = new item()
                {
                    name = "Rug",
                };
                private item _peppers = new item()
                {
                    name = "Sack of peppers",
                };
                private item _glass_of_water = new item()
                {
                    name = "glass of water",
                };
                private item _harpsichord = new item()
                {
                    name = "Harpsichord",
                };
                private item _painting = new item()
                {
                    name = "Painting",
                };
                private item _boots = new item()
                {
                    name = "Boots",
                };
                private item _sheets = new item()
                {
                    name = "Sheets",
                };
                private item _gold = new item()
                {
                    name = "Gold",
                };
                private item _wine = new item()
                {
                    name = "Wine",
                };
                private item _necklace = new item()
                {
                    name = "Necklace",
                };
                private item _elven_Book = new item()
                {
                    name = "Elven Book",
                };
                private item _orb = new item()
                {
                    name = "Orb",
                };
                private item _flask = new item()
                {
                    name = "Flask",
                };
                private item _lamp = new item()
                {
                    name = "Lamp",
                };
        */

        public player gamer = new player()
        {
            health = 100,
            gold = 500,
            point = 0,
            Bag = new List<item>(),
        };

        public enemy Troll = new enemy()
        {
            name = "troll",
        };

        public void Attack(IWeapon weapon, IAttackable canAttack)
        {
            // when attack anything that can be attack, those should be destroyed and drop gold
            canAttack.IsDestroyed = true;
            this._currentRoom.items.Add(new item { name = "gold", description = "Shiny gold coins.", value = 100 });

        }

        public void checkEnemy()
        {
            // chack if the enemy in the same room with player
            if (this._currentRoom == this.Troll.currentRoom && !this.Troll.IsDestroyed)
            {
                this.gamer.IsDestroyed = true;
            }
        }


        public IWeapon FindWeapon(string name)
        {
            // case-insensitive search for a weapon with matching name using a "delegate"
            // the "item => item.Name.ToLower() == name.ToLower()" is the delegate. You can
            // also manually loop through the inventory to do the same thing using a foreach,
            // but the "delegate" shortens that up. We'll go over delegates more later.
            item foundItem = this.gamer.Bag.Find(item => item.name.ToLower() == name.ToLower());
            IWeapon weapon = foundItem as IWeapon; //this cast returns null if foundItem isn't an IWeapon
            if (weapon == null)
            {
                Console.WriteLine($"Couldn't find a weapon named {name}");
            }
            return weapon;
        }

        // helper method for the above InputLoop attack code
        public IAttackable FindAttackable(string name)
        {
            enemy enemy = null;
            // case insensitive search for an enemy with this name
            if(this._currentRoom == Troll.currentRoom && name == Troll.name)
            {
                enemy = Troll;
            }
            // case insensitive search for an "attackable" item with this name
            // cast to IAttackable (or null, if it doesn't match that interface)
            IAttackable attackableItem = this._currentRoom.items.Find(item => item.name.ToLower() == name.ToLower()) as IAttackable;

            // if we can't find an enemy or attackable item, print an error
            if (enemy == null && attackableItem == null)
            {
                Console.WriteLine($"Couldn't find an attackable named {name}");
            }

            // the following "??" is called a "null coalesce" operator.
            // If the left side is null, it will return the right side. Otherwise it returns the left side.
            // (if both are null, returns null)
            return enemy ?? attackableItem;
        }


        public Game()
        {
            // Initialize room relationship
            _currentRoom = _entranceHall;

            _entranceHall.SouthRoom = _outside;
            _entranceHall.NorthRoom = _livingRoom;

            _livingRoom.SouthRoom = _entranceHall;
            _livingRoom.EastRoom = _kitchen;
            _livingRoom.WestRoom = _paintingRoom;
            _livingRoom.NorthRoom = _fancyBedroom;
            _livingRoom.DownRoom = _cellar;

            _kitchen.WestRoom = _livingRoom;

            _paintingRoom.EastRoom = _livingRoom;

            _fancyBedroom.SouthRoom = _livingRoom;

            _cellar.UpRoom = _livingRoom;
            _cellar.NorthRoom = _library;

            _library.SouthRoom = _cellar;
            _library.NorthRoom = _laboratory;

            _laboratory.SouthRoom = _library;
            _laboratory.NorthRoom = _skeletonRoom;

            _skeletonRoom.SouthRoom = _laboratory;

            //Add to RoomList
/*            RoomList.Add(_outside);
            RoomList.Add(_entranceHall);
            RoomList.Add(_livingRoom);
            RoomList.Add(_paintingRoom);
            RoomList.Add(_fancyBedroom);
            RoomList.Add(_cellar);
            RoomList.Add(_library);
            RoomList.Add(_laboratory);
            RoomList.Add(_skeletonRoom);*/

            //Initialize currentRoom
            Troll.currentRoom = _laboratory;

          /*  _livingRoom.items.Add(_trophy);
            _livingRoom.items.Add(_sword);
            _livingRoom.items.Add(_rug);
            _kitchen.items.Add(_peppers);
            _kitchen.items.Add(_glass_of_water);
            _paintingRoom.items.Add(_harpsichord);
            _paintingRoom.items.Add(_painting);
            _fancyBedroom.items.Add(_boots);
            _fancyBedroom.items.Add(_sheets);
            _fancyBedroom.items.Add(_gold);
            _cellar.items.Add(_wine);
            _library.items.Add(_necklace);
            _library.items.Add(_elven_Book);
            _laboratory.items.Add(_orb);
            _laboratory.items.Add(_flask);
            _laboratory.items.Add(_lamp);
*/
        }
    }
}
