using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    // Used for any non-wall object inside a room the player can't pass through
    // i.e. NPCs(non-player-characters), funiture, interior walls etc.

    public class Block
    {
        public int BlockID { get; set; }
        public char Icon { get; set; }
        public string Description { get; set; }
        public bool IsTrigger { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Block(){}

        public Block(int blockID, char icon, string description, bool isTrigger, int posX, int posY)
        {
            BlockID = blockID;
            Icon = icon;
            Description = description;
            IsTrigger = isTrigger;
            PosX = posX;
            PosY = posY;
        }
    }
}
