using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BadgeProp
    {
        public BadgeProp() { }

        public BadgeProp(int badgeNumber, List<string> doorLiist)
        {
            BadgeNumber = badgeNumber;
            DoorList = doorLiist;
        }
        public int BadgeNumber { get; set; }

        public List<string> DoorList { get; set; }
    }
}
