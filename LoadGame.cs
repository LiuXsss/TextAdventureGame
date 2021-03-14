using System;
using System.Collections.Generic;
using System.Text;

namespace A3_TextAdventure
{

    class LoadGame: Game
    {
        private static LoadGame instance;
        private LoadGame()
        {

        }

        public static LoadGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoadGame();
                }
                return instance;
            }
        }


        //public static  Game saveGame = new Game();

        public void Save(Game currentGame)
        {
            //saveGame = currentGame;
            this._outside = currentGame._outside;
            this._entranceHall = currentGame._entranceHall;
            this._livingRoom = currentGame._livingRoom;
            this.gamer = currentGame.gamer;
            this._currentRoom = currentGame._currentRoom;
            /*            foreach(Room room in currentGame.RoomList)
                        {
                            foreach(Room room_save in saveGame.RoomList)
                            {
                                if(room.name == room_save.name)
                                {

                                }
                            }
                        }*/
        }

        public void Load(Game currentGame)
        {
            //currentGame = saveGame;
            currentGame._outside = this._outside;
            currentGame._entranceHall = this._entranceHall;
            currentGame._livingRoom = this._livingRoom;
            currentGame.gamer = this.gamer;
            currentGame._currentRoom = this._currentRoom;
        }

    }
}
