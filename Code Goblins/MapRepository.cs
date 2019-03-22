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

        public void HallOne()
        {
            Exit exitGame = new Exit(1, 1, false, true, false, false);
            Exit cornerExit = new Exit(3, 1, true, false, true, false);
            List<Exit> exits = new List<Exit>();
            exits.Add(exitGame);
            exits.Add(cornerExit);
            Room hallOne = new Room(1, exits, "Entrance Hallway", "Your are in the entrace to Gobo50.", 3, 1);
            roomDict.Add(hallOne.RoomID, hallOne);
        }

    }
}
