using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class Exit
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool North { get; set; }
        public int NorthID { get; set; }
        public bool South { get; set; }
        public bool East { get; set; }
        public bool West { get; set; }

        public Exit(){}

        public Exit(int posX, int posY, bool north, bool south, bool east, bool west)
        {
            PosX = posX;
            PosY = posY;
            North = north;
            South = south;
            East = east;
            West = west;
        }
    }
}
