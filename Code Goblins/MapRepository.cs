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
            Room hallOne = new Room(1, exits, "Entrance Hallway", "Your are in the entrace to Gobo50.", 3, 1);
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
