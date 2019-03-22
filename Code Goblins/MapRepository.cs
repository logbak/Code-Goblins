using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class MapRepository
    {
        Dictionary<int, Room> roomDict;

        public MapRepository()
        {
            roomDict = new Dictionary<int, Room>();
            HallOne();
        }

        public Room GetRoomByID(int id)
        {
            Room room = new Room();
            roomDict.TryGetValue(id, out room);
            return room;
        }
      
     public void PrintCurrentRoom(Room room)
        {
            string[] topWall = new string[(room.SizeX + 2)];
            for (int i = 0; i <= (room.SizeX + 1); i++)
            {
                topWall[i] = "\u2584";
            }
            string topWallFull = String.Join("", topWall);
            Console.WriteLine($"{topWallFull}");

            string[] sideWalls = new string[(room.SizeX + 2)];
            sideWalls[0] = "\u2588";
            for (int i = 1; i <= (room.SizeX + 1); i++)
            {
                sideWalls[i] = " ";
            }
            sideWalls[(room.SizeX + 1)] = "\u2588";
            string sideWallsFull = String.Join("", sideWalls);

            string[] player = new string[(room.SizeX + 2)];
            player[0] = "\u2588";
            player[room.PosX] = "X";
            for (int i = 1; i <= (room.SizeX + 1); i++)
            {
                if (i != room.PosX)
                {
                    player[i] = " ";
                }
            }
            player[(room.SizeX + 1)] = "\u2588";
            string playerfull = String.Join("", player);

            for (int i = 0; i <= (room.SizeY - 1); i++)
            {
                if (i == (room.PosY -1))
                {
                    Console.WriteLine(playerfull);
                }
                else
                {
                    Console.WriteLine(sideWallsFull);
                }
            }

            string[] bottomWall = new string[(room.SizeX + 2)];
            for (int i = 0; i <= (room.SizeX + 1); i++)
            {
                bottomWall[i] = "\u2580";
            }
            string bottomWallFull = String.Join("", bottomWall);
            Console.WriteLine($"{bottomWallFull}");
}
        public void ExitGame()
        {
            Exit cornerExit = new Exit(3, 1, true, 2, false, 0, true, 0, false, 0);
            List<Exit> exits = new List<Exit>();
            exits.Add(cornerExit);
            Room hallOne = new Room(0, exits, "Entrance Hallway", "Your are leaving Gobo50.", 1, 1);
        }

        public void HallOne()
        {
            Exit exitGame = new Exit(1, 1, false, 0, true, 0, false, 0, false, 0);
            Exit cornerExit = new Exit(3, 1, true, 2, false, 0, true, 0, false, 0);
            List<Exit> exits = new List<Exit>();
            exits.Add(exitGame);
            exits.Add(cornerExit);
            Room hallOne = new Room(1, exits, "Entrance Hallway", "Your are in the entrace to Gobo50.", 8, 2);
            roomDict.Add(hallOne.RoomID, hallOne);
        }


        public void HallTwo()
        {
            Exit cornerExit = new Exit(1, 1, false, 0, true, 1, false, 0, false, 0);
            List<Exit> exits = new List<Exit>();
            exits.Add(cornerExit);
            Room hallOne = new Room(2, exits, "Entrance Hallway", "Your are in the entrace to Gobo50.", 3, 1);
            roomDict.Add(hallOne.RoomID, hallOne);
        }

    }
}
