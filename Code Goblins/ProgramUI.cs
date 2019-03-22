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
            Room room = new Room();
            room = mapRepo.GetRoomByID(1);
            room.PosX = 1;
            room.PosY = 1;
            mapRepo.PrintCurrentRoom(room);
            bool running = true;
            while (running)
            {
                room = playerRepo.PlayerControl(room);
                Console.Clear();
                mapRepo.PrintCurrentRoom(room);
                Console.WriteLine(room.RoomName);
            }
            Console.ReadKey();
        }
    }
}
