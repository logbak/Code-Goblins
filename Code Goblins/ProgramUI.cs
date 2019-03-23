using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class ProgramUI
    {
        MapRepository mapRepo = new MapRepository();
        PlayerRepository playerRepo = new PlayerRepository();

        public void Run()
        {
            Console.WriteLine("Controls:\n" + "Use W A S D for movement. Press V to look around.\n" + "Press any key to continue.");
            Console.ReadKey();

            Room room = new Room();
            room = mapRepo.GetRoomByID(99);
            // x1, y1 is the upper left corner of the room
            room.PosX = 1;
            room.PosY = 1;
            mapRepo.PrintCurrentRoom(room);
            Console.WriteLine(room.RoomName);
            bool running = true;
            while (running)
            {
                // basic map printing loop
                room = playerRepo.PlayerControl(room);
                Console.Clear();
                mapRepo.PrintCurrentRoom(room);
                Console.WriteLine(room.RoomName);
            }
            Console.ReadKey();
        }
    }
}
