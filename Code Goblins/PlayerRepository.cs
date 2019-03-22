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

    }
}
