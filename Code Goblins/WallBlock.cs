using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    // this was used to test an idea for seperate wall blocks larger than 1x1 but is currently not being used

    public enum WallType { Top, Bottom, Side, Door, SideDoor}

    public class WallBlock
    {
        public WallType TypeOfWall { get; set; }
        public char Icon { get; set; }
        public bool IsTrigger { get; set; }
        public int OriginX { get; set; }
        public int OriginY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public WallBlock(){}

        public WallBlock(WallType typeOfWall, bool isTrigger, int originX, int originY, int endX, int endY)
        {
            TypeOfWall = typeOfWall;
            IsTrigger = isTrigger;
            OriginX = originX;
            OriginY = originY;
            EndX = endX;
            EndY = endY;
            switch (typeOfWall)
            {
                case WallType.Top:
                    Icon = '\u2584';
                    break;
                case WallType.Side:
                    Icon = '\u2588';
                    break;
                case WallType.Bottom:
                    Icon = '\u2580';
                    break;
                case WallType.Door:
                    Icon = '\u2550';
                    break;
                case WallType.SideDoor:
                    Icon = '\u2551';
                    break;
            }
        }
    }
}
