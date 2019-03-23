using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class PlayerRepository
    {
        MapRepository mapRepo = new MapRepository();

        public PlayerRepository(){}
        
        public View ViewOfRoom(Room room)
        {
            List<string> blockList = new List<string>();
            string direction = "";
            foreach(Block block in room.BlockList)
            {
                blockList.Add($"To your {direction} is {block.Description}.");
            }
            View currentView = new View(room.Description, blockList);
            return currentView;
        }

        public Room PlayerControl(Room room)
        {
            
            var inputKey = Console.ReadKey();
            switch (inputKey.Key)
            {
                case ConsoleKey.W:
                    if (room.PosY <= room.SizeY && room.PosY != 1)
                    {
                        if (CheckForBlocks(room, "north"))
                        {
                            return room;
                        }
                        room.PosY--;
                        return room;
                    }
                    else if (CheckExits(room, "north") != null)
                    {
                        Exit currentExit = CheckExits(room, "north");
                        Room newRoom = mapRepo.GetRoomByID(currentExit.GoToID);
                        newRoom.PosX = currentExit.NewPosX;
                        newRoom.PosY = currentExit.NewPosY;
                        return newRoom;
                    }
                    return room;

                case ConsoleKey.S:
                    if (room.PosY < room.SizeY)
                    {
                        if (CheckForBlocks(room, "south"))
                        {
                            return room;
                        }
                        room.PosY++;
                        return room;
                    }
                    else if (CheckExits(room, "south") != null)
                    {
                        Exit currentExit = CheckExits(room, "south");
                        Room newRoom = mapRepo.GetRoomByID(currentExit.GoToID);
                        newRoom.PosX = currentExit.NewPosX;
                        newRoom.PosY = currentExit.NewPosY;
                        return newRoom;
                    }
                    return room;

                case ConsoleKey.A:
                    if (room.PosX <= room.SizeX && room.PosX != 1)
                    {
                        if (CheckForBlocks(room, "west"))
                        {
                            return room;
                        }
                        room.PosX--;
                        return room;
                    }
                    else if (CheckExits(room, "west") != null)
                    {
                        Exit currentExit = CheckExits(room, "west");
                        Room newRoom = mapRepo.GetRoomByID(currentExit.GoToID);
                        newRoom.PosX = currentExit.NewPosX;
                        newRoom.PosY = currentExit.NewPosY;
                        return newRoom;
                    }
                    return room;

                case ConsoleKey.D:
                    if (room.PosX < room.SizeX)
                    {
                        if (CheckForBlocks(room, "east"))
                        {
                            return room;
                        }
                        room.PosX++;
                        return room;
                    }
                    else if (CheckExits(room, "east") != null)
                    {
                        Exit currentExit = CheckExits(room, "east");
                        Room newRoom = mapRepo.GetRoomByID(currentExit.GoToID);
                        newRoom.PosX = currentExit.NewPosX;
                        newRoom.PosY = currentExit.NewPosY;
                        return newRoom;
                    }
                    return room;
                case ConsoleKey.V:
                    Console.Clear();
                    mapRepo.PrintCurrentRoom(room);
                    View view = ViewOfRoom(room);
                    Console.WriteLine(view.CurrentRoomDescription);
                    foreach(string blockView in view.BlockDescriptionList)
                    {
                        Console.WriteLine(blockView);
                    }
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    return room;
            }
            return room;
        }

        public Exit CheckExits(Room room, string direction)
        {
            foreach (Exit exit in room.ExitList)
            {
                if (room.PosX == exit.PosX && room.PosY == exit.PosY)
                {
                    switch (direction)
                    {
                        case "north":
                            if (exit.North == true)
                            {
                                return exit;
                            }
                            break;

                        case "south":
                            if (exit.South == true)
                            {
                                return exit;
                            }
                            break;

                        case "east":
                            if (exit.East == true)
                            {
                                return exit;
                            }
                            break;
                        case "west":
                            if (exit.West == true)
                            {
                                return exit;
                            }
                            break;
                    }
                }
            }
            return null;
        }

        public bool CheckForBlocks(Room room, string direction)
        {
            switch (direction)
            {
                case "north":
                    foreach(Block blocks in room.BlockList)
                    {
                        if (room.PosX == blocks.PosX && (room.PosY - 1) == blocks.PosY)
                        {
                            return true;
                        }
                    }
                    return false;
                case "south":
                    foreach (Block blocks in room.BlockList)
                    {
                        if (room.PosX == blocks.PosX && (room.PosY + 1) == blocks.PosY)
                        {
                            return true;
                        }
                    }
                    return false;
                case "east":
                    foreach (Block blocks in room.BlockList)
                    {
                        if ((room.PosX + 1) == blocks.PosX && room.PosY == blocks.PosY)
                        {
                            return true;
                        }
                    }
                    return false;
                case "west":
                    foreach (Block blocks in room.BlockList)
                    {
                        if ((room.PosX - 1) == blocks.PosX && room.PosY == blocks.PosY)
                        {
                            return true;
                        }
                    }
                    return false;
            }
            return false;
        }
    }
}
