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
        RoomRepository roomRepo = new RoomRepository();
        PlayerRepository playerRepo = new PlayerRepository();

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(@"
               ██████╗ ██████╗ ██████╗ ███████╗              
              ██╔════╝██╔═══██╗██╔══██╗██╔════╝              
              ██║     ██║   ██║██║  ██║█████╗                
              ██║     ██║   ██║██║  ██║██╔══╝                
              ╚██████╗╚██████╔╝██████╔╝███████╗              
               ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝              
                                                             
       ██████╗  ██████╗ ██████╗ ██╗     ██╗███╗   ██╗███████╗
      ██╔════╝ ██╔═══██╗██╔══██╗██║     ██║████╗  ██║██╔════╝
      ██║  ███╗██║   ██║██████╔╝██║     ██║██╔██╗ ██║███████╗
      ██║   ██║██║   ██║██╔══██╗██║     ██║██║╚██╗██║╚════██║
      ╚██████╔╝╚██████╔╝██████╔╝███████╗██║██║ ╚████║███████║
       ╚═════╝  ╚═════╝ ╚═════╝ ╚══════╝╚═╝╚═╝  ╚═══╝╚══════╝");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Demo Version. Logo generated using: http://patorjk.com/software/taag/ \n" + "Press any key to start.");
            Console.ReadKey();
            Console.Clear();
            Console.ResetColor();
            Room room = new Room();
            room = roomRepo.GetRoomByID(99);
            // x1, y1 is the upper left corner of the room
            room.PosX = 1;
            room.PosY = 1;
            Console.WriteLine("Controls:\n" + "Use W A S D for movement. Press V to look around.\n");
            Console.WriteLine(room.RoomName);
            mapRepo.PrintCurrentRoom(room);
            bool running = true;
            while (running)
            {
                // basic map printing loop
                room = playerRepo.PlayerControl(room);
                Console.Clear();
                Console.WriteLine("Controls:\n" + "Use W A S D for movement. Press V to look around.\n");
                Console.WriteLine(room.RoomName);
                mapRepo.PrintCurrentRoom(room);
                
            }
            Console.ReadKey();
        }
    }
}
