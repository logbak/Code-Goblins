﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class Room
    {
        public int RoomID { get; set; }
        public List<Exit> ExitList { get; set; }
        public List<Block> BlockList { get; set; }
        public List<WallBlock> WallList { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Room(){}

        public Room(int roomID, List<Exit> exitList, List<Block> blockList, List<WallBlock> wallList, string roomName, string description, int sizeX, int sizeY)
        {
            RoomID = roomID;
            ExitList = exitList;
            BlockList = blockList;
            WallList = wallList;
            RoomName = roomName;
            Description = description;
            SizeX = sizeX;
            SizeY = sizeY;
        }

    }
}
