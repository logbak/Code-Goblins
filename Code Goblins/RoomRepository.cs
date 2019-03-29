using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class RoomRepository
    {
        Dictionary<int, Room> roomDict;

        public RoomRepository()
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
            List<WallBlock> wallBlocks = new List<WallBlock>();
            // block initilization (block id, icon you want to appear on the map, description, bool to check if block triggers an event, position X, position Y)
            // description should fit into the sentence "To your {direction} is {description}."
            Block block1 = new Block(100, 'g', "a code goblin", true, 6, 2);
            Block block2 = new Block(101, 'J', "a javascript wizard", true, 8, 2);
            Block block3 = new Block(102, 'G', "a gladiator developer", true, 8, 3);
            //Block wall1 = new Block(110, '\u2588', "", false, 7, 4);
            //Block wall2 = new Block(110, '\u2588', "", false, 8, 4);
            //Block wall3 = new Block(110, '\u2588', "", false, 9, 4);
            //Block wall4 = new Block(110, '\u2588', "", false, 10, 4);
            //Block wall5 = new Block(110, '\u2588', "", false, 11, 4);
            //Block wall6 = new Block(110, '\u2588', "", false, 12, 4);
            WallBlock wallBlock1 = new WallBlock(WallType.Side, false, 7, 4, 12, 1);
            blocks.Add(block1);
            blocks.Add(block2);
            blocks.Add(block3);
            //blocks.Add(wall1);
            //blocks.Add(wall2);
            //blocks.Add(wall3);
            //blocks.Add(wall4);
            //blocks.Add(wall5);
            //blocks.Add(wall6);
            wallBlocks.Add(wallBlock1);

            // room initilization: (room ID, exitlist, blocklist, room name that displays while in room, description when player hits v, room size X, room size Y)
            Room demoRoom = new Room(99, exits, blocks, wallBlocks, "Demo Room", "You are in the demo. Whoa.", 12, 6);

            // adding room to dictionary so it can be called by id
            roomDict.Add(demoRoom.RoomID, demoRoom);
        }

        //marked for removal, will likely handle game exiting in a different way
        //public void ExitGame()
        //{
        //    Exit cornerExit = new Exit(3, 1, true, false, false, false, 99, 12, 1);
        //    List<Exit> exits = new List<Exit>();
        //    exits.Add(cornerExit);
        //    List<Block> blocks = new List<Block>();
        //    Room hallOne = new Room(0, exits, blocks, "Entrance Hallway", "Your are leaving Gobo50.", 1, 1);
        //}

        public void HallOne()
        {
            Exit exitGame = new Exit(1, 2, false, true, false, false, 99, 12, 1);
            Exit cornerExit = new Exit(8, 1, true, false, false, false, 99, 11, 1);
            List<Exit> exits = new List<Exit>();
            exits.Add(exitGame);
            exits.Add(cornerExit);
            List<Block> blocks = new List<Block>();
            List<WallBlock> wallBlocks = new List<WallBlock>();
            Room hallOne = new Room(1, exits, blocks, wallBlocks, "Entrance Hallway", "Your are in the entrace to Gobo50.", 8, 2);
            roomDict.Add(hallOne.RoomID, hallOne);
        }

        //public void HallTwo()
        //{
        //    Exit cornerExit = new Exit(1, 8, true, false, false, false, 99, 12, 1);
        //    List<Exit> exits = new List<Exit>();
        //    exits.Add(cornerExit);
        //    List<Block> blocks = new List<Block>();
        //    Room hallOne = new Room(2, exits, blocks, "Hallway", "It's a hallway.", 2, 8);
        //    roomDict.Add(hallOne.RoomID, hallOne);
        //}
    }
}
