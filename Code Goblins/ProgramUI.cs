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
            playerRepo.PrintCurrentRoom(room);
            Console.ReadKey();
        }
    }
}
