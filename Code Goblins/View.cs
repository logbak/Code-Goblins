using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Goblins
{
    public class View
    {
        public string CurrentRoomDescription { get; set; }
        public List<string> BlockDescriptionList { get; set; }

        public View(){}

        public View(string roomDesc, List<string> blockList)
        {
            CurrentRoomDescription = roomDesc;
            BlockDescriptionList = blockList;
        }
    }
}
