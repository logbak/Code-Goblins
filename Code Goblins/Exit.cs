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

        public int SouthID { get; set; }

        public bool East { get; set; }

        public int EastID { get; set; }

        public bool West { get; set; }

        public int WestID { get; set; }

        public Exit(){}

        public Exit(int posX, int posY, bool north,int northID, bool south, int southID, bool east, int eastID, bool west,int westID)

        {

            PosX = posX;

            PosY = posY;

            North = north;

            NorthID = northID;

            South = south;

            SouthID = southID;

            East = east;

            EastID = eastID;

            West = west;

            WestID = westID;

        }


    }
}
