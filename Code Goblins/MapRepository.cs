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
            DemoRoom();
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
            string topWall = PrintTopWalls(room);
            Console.WriteLine($"{topWall}");

            string sideWalls = PrintSideWalls(room);

            string player = PrintPlayerPosition(room);

            Dictionary<int, string> blockLayers = PrintBlockPositions(room);

            for (int i = 1; i <= room.SizeY; i++)
            {
                if (i == room.PosY)
                {
                    Console.WriteLine(player);
                }
                else if (room.ExitList.Exists(b => b.PosY == i))
                {
                    blockLayers.TryGetValue(i, out string currentLayer);
                    Console.WriteLine(currentLayer);
                }
                else if (room.BlockList.Exists(b => b.PosY == i))
                {
                    blockLayers.TryGetValue(i, out string currentLayer);
                    Console.WriteLine(currentLayer);
                }
                else
                {
                    Console.WriteLine(sideWalls);
                }
            }

            string bottomWall = PrintBottomWalls(room);
            Console.WriteLine($"{bottomWall}");
        }

        public string PrintTopWalls(Room room)
        {
            string[] topWall = new string[(room.SizeX + 2)];
            for (int i = 0; i <= (room.SizeX + 1); i++)
            {
                if (room.ExitList.Exists(e => e.PosX == i && e.PosY == 1 && e.North == true))
                {
                    topWall[i] = "\u2550";
                    continue;
                }
                topWall[i] = "\u2584";
            }
            string topWallFull = String.Join("", topWall);
            return topWallFull;
        }

        public string PrintBottomWalls(Room room)
        {
            string[] bottomWall = new string[(room.SizeX + 2)];
            for (int i = 0; i <= (room.SizeX + 1); i++)
            {
                if (room.ExitList.Exists(e => e.PosX == i && e.PosY == room.SizeY && e.South == true))
                {
                    bottomWall[i] = "\u2550";
                    continue;
                }
                bottomWall[i] = "\u2580";
            }
            string bottomWallFull = String.Join("", bottomWall);
            return bottomWallFull;
        }

        public string PrintSideWalls(Room room)
        {
            string[] sideWalls = new string[(room.SizeX + 2)];
            sideWalls[0] = "\u2588";
            for (int i = 1; i <= (room.SizeX + 1); i++)
            {
                sideWalls[i] = " ";
            }
            sideWalls[(room.SizeX + 1)] = "\u2588";
            string sideWallsFull = String.Join("", sideWalls);
            return sideWallsFull;
        }

        //public string PrintSideExits(Room room, string roomSideWall, int currentY)
        //{
        //    char[] sideWalls = roomSideWall.ToCharArray();;
        //    sideWalls[0] = '\u2588';
        //    sideWalls[(room.SizeX + 1)] = '\u2588';
        //    for (int i = 0; i <= (room.SizeX + 1); i++)
        //    {
        //        if (room.ExitList.Exists(e => e.PosY == currentY && e.West == true && i == 0))
        //        {
        //            sideWalls[0] = '\u2551';
        //            continue;
        //        }
        //        else if (room.ExitList.Exists(e => e.PosY == currentY && e.East == true && i == (room.SizeX + 1)))
        //        {
        //            sideWalls[(room.SizeX + 1)] = '\u2551';
        //            continue;
        //        }
        //        else if (i != 0 || i != (room.SizeX + 1))
        //        {
        //            sideWalls[i] = ' ';
        //        }
        //    }
        //    string sideWallsFull = String.Join("", sideWalls);
        //    return sideWallsFull;
        //}

        public string PrintPlayerPosition(Room room)
        {
            string[] player = new string[(room.SizeX + 2)];
            if (room.ExitList.Exists(e => e.PosY == room.PosY && e.PosX == 1 && e.West == true))
            {
                player[0] = "\u2551";
            }
            else
            {
                player[0] = "\u2588";
            }
            player[room.PosX] = "X";
            for (int i = 1; i <= (room.SizeX + 1); i++)
            {
                if (room.BlockList.Exists(b => b.PosX == i && b.PosY == room.PosY))
                {
                    player[i] = room.BlockList.Find(b => b.PosX == i && b.PosY == room.PosY).Icon.ToString();
                    continue;
                }
                else if (i == room.PosX)
                {
                    continue;
                }
                player[i] = " ";
            }
            if (room.ExitList.Exists(e => e.PosY == room.PosY && e.PosX == room.SizeX && e.East == true))
            {
                player[(room.SizeX + 1)] = "\u2551";
            }
            else
            {
                player[(room.SizeX + 1)] = "\u2588";
            }
            string playerfull = String.Join("", player);
            return playerfull;
        }

        public Dictionary<int, string> PrintBlockPositions(Room room)
        {
            Dictionary<int, string> blockLayer = new Dictionary<int, string>();
            string currentBlockLayer = "";
            foreach (Exit exit in room.ExitList)
            {
                if (blockLayer.Keys.Contains(exit.PosY))
                {
                    continue;
                }
                currentBlockLayer = PrintSingleBlockRow(room, exit.PosY);
                blockLayer.Add(exit.PosY, currentBlockLayer);
            }
            foreach (Block block in room.BlockList)
            {
                if (blockLayer.Keys.Contains(block.PosY))
                {
                    continue;
                }
                currentBlockLayer = PrintSingleBlockRow(room, block.PosY);
                blockLayer.Add(block.PosY, currentBlockLayer);
            }
            return blockLayer;
        }

        public string PrintSingleBlockRow(Room room, int currentY)
        {
            string[] block = new string[(room.SizeX + 2)];
            if (room.ExitList.Exists(e => e.PosY == currentY && e.PosX == 1 && e.West == true))
            {
                block[0] = "\u2551";
            }
            else
            {
                block[0] = "\u2588";
            }
            if (room.ExitList.Exists(e => e.PosY == currentY && e.PosX == room.SizeX && e.East == true))
            {
                block[(room.SizeX + 1)] = "\u2551";
            }
            else
            {
                block[(room.SizeX + 1)] = "\u2588";
            }
            for (int i = 1; i <= room.SizeX; i++)
            {
                if (room.BlockList.Exists(b => b.PosX == i && b.PosY == currentY))
                {
                    block[i] = room.BlockList.Find(b => b.PosX == i && b.PosY == currentY).Icon.ToString();
                    continue;
                }
                block[i] = " ";
            }
            string blockfull = String.Join("", block);
            return blockfull;
        }

        public void DemoRoom()
        {
            // create a list of exits to hold each exit
            List<Exit> exits = new List<Exit>();
            // exit initilization:  (position X, position Y, 4 bools set direction of exit from position, sets room id to move to, new room position X, new room position Y)
            // note each exit represents a single exit door, only set one direction to true
            Exit demoExit = new Exit(11, 1, true, false, false, false, 1, 1, 2);
            Exit demoExitOne = new Exit(12, 1, false, false, true, false, 1, 1, 2);
            Exit demoExitTwo = new Exit(1, 4, false, false, false, true, 1, 1, 2);
            // each exit must be added to the exit list individually
            exits.Add(demoExit);
            exits.Add(demoExitOne);
            exits.Add(demoExitTwo);

            // adding blocks is the same as exits but with it's own list
            List<Block> blocks = new List<Block>();
            // block initilization (block id, icon you want to appear on the map, description, bool to check if block triggers an event, position X, position Y)
            // description should fit into the sentence "To your {direction} is {description}."
            Block block1 = new Block(100, 'g', "a code goblin", true, 6, 2);
            Block block2 = new Block(101, 'J', "a javascript wizard", true, 8, 2);
            Block block3 = new Block(102, 'G', "a gladiator developer", true, 8, 3);
            Block wall1 = new Block(110, '\u2588', "", false, 7, 4);
            Block wall2 = new Block(110, '\u2588', "", false, 8, 4);
            Block wall3 = new Block(110, '\u2588', "", false, 9, 4);
            Block wall4 = new Block(110, '\u2588', "", false, 10, 4);
            Block wall5 = new Block(110, '\u2588', "", false, 11, 4);
            Block wall6 = new Block(110, '\u2588', "", false, 12, 4);
            blocks.Add(block1);
            blocks.Add(block2);
            blocks.Add(block3);
            blocks.Add(wall1);
            blocks.Add(wall2);
            blocks.Add(wall3);
            blocks.Add(wall4);
            blocks.Add(wall5);
            blocks.Add(wall6);

            // room initilization: (room ID, exitlist, blocklist, room name that displays while in room, description when player hits v, room size X, room size Y)
            Room demoRoom = new Room(99, exits, blocks, "Demo Room", "You are in the demo. Whoa.", 12, 6);
            
            // adding room to dictionary so it can be called by id
            roomDict.Add(demoRoom.RoomID, demoRoom);
        }

        public void ExitGame()
        {
            Exit cornerExit = new Exit(3, 1, true, false, false, false, 99, 12, 1);
            List<Exit> exits = new List<Exit>();
            exits.Add(cornerExit);
            List<Block> blocks = new List<Block>();
            Room hallOne = new Room(0, exits, blocks, "Entrance Hallway", "Your are leaving Gobo50.", 1, 1);
        }

        public void HallOne()
        {
            Exit exitGame = new Exit(1, 2, false, true, false, false, 99, 12, 1);
            Exit cornerExit = new Exit(8, 1, true, false, false, false, 99, 11, 1);
            List<Exit> exits = new List<Exit>();
            exits.Add(exitGame);
            exits.Add(cornerExit);
            List<Block> blocks = new List<Block>();
            Room hallOne = new Room(1, exits, blocks, "Entrance Hallway", "Your are in the entrace to Gobo50.", 8, 2);
            roomDict.Add(hallOne.RoomID, hallOne);
        }

        public void HallTwo()
        {
            Exit cornerExit = new Exit(1, 8, true, false, false, false, 99, 12, 1);
            List<Exit> exits = new List<Exit>();
            exits.Add(cornerExit);
            List<Block> blocks = new List<Block>();
            Room hallOne = new Room(2, exits, blocks, "Hallway", "It's a hallway.", 2, 8);
            roomDict.Add(hallOne.RoomID, hallOne);
        }

    }
}
