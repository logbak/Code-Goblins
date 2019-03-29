using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class MapRepository
    {

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
                else if (room.WallList.Exists(b => b.PosY == i))
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
                // fix me!
                else if (room.WallList.Exists(w => w.PosX >= i && w.WidthX <=i && w.PosY == currentY))
                {
                    block[i] = room.WallList.Find(w => w.PosX == i && w.PosY == currentY).Icon.ToString();
                    continue;
                }
                block[i] = " ";
            }
            string blockfull = String.Join("", block);
            return blockfull;
        }

    }
}
