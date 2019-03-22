using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class PlayerRepository
    {
        public PlayerRepository()
        {

        }
        
        //public Room PlayerControl(Room room)
        //{
        //    string inputKey = Console.ReadKey().ToString().ToLower();
        //    switch (inputKey)
        //    {
        //        case "w":
        //            if (room.PosY < room.SizeY)
        //            {
        //                room.PosY++;
        //                return room;
        //            }
        //            else if (CheckExits(room, "north"))
        //            {

        //            }
                    
        //            Console.WriteLine("You cannot go north here.");
        //            return room;
        //        case "s":
        //            if (room.PosY <= room.SizeY && room.PosY != 1)
        //            {
        //                room.PosY--;
        //                return room;
        //            }
        //            else if (CheckExits(room, "south"))
        //            {

        //            }

        //            Console.WriteLine("You cannot go south here.");
        //            return room;
        //        case "a":
        //            if (room.PosX <= room.SizeX && room.PosX != 1)
        //            {
        //                room.PosX--;
        //                return room;
        //            }
        //            else if (CheckExits(room, "west"))
        //            {

        //            }

        //            Console.WriteLine("You cannot go west here.");
        //            return room;
        //        case "d":
        //            if (room.PosX < room.SizeX)
        //            {
        //                room.PosX++;
        //                return room;
        //            }
        //            else if (CheckExits(room, "east"))
        //            {

        //            }

        //            Console.WriteLine("You cannot go east here.");
        //            return room;
        //    }
        //    return room;
        //}

        //public bool CheckExits(Room room, string direction)
        //{
        //    foreach (Exit exit in room.ExitList)
        //    {
        //        if (room.PosX == exit.PosX && room.PosY == exit.PosY)
        //        {

        //        }
        //    }
        //}

        public void PrintCurrentRoom(Room room)
        {
            string[] topWall = new string[(room.SizeX + 3)];
            for (int i = 0; i <= (room.SizeX + 2); i++)
            {
                topWall[i] = "\u2584";
            }
            string topWallFull = String.Join("", topWall);
            Console.WriteLine($"{topWallFull}");

            string[] sideWalls = new string[(room.SizeX + 2)];
            string[] player = new string[(room.SizeX + 2)];
            sideWalls[0] = "\u2588";
            sideWalls[(room.SizeX +1)] = "\u2588";
            player[0] = "\u2588";
            player[(room.SizeX + 1)] = "\u2588";
            player[(room.PosX + 1)] = "X";
            string sideWallsFull = String.Join(" ", sideWalls);
            for (int i = 0; i <= room.SizeY; i++)
            {
                Console.WriteLine(sideWallsFull);
            }

            string[] bottomWall = new string[(room.SizeX + 3)];
            for (int i = 0; i <= (room.SizeX + 2); i++)
            {
                bottomWall[i] = "\u2580";
            }
            string bottomWallFull = String.Join("", bottomWall);
            Console.WriteLine($"{bottomWallFull}");
        }

    }
}
