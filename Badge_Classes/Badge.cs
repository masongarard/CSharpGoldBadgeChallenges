using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Classes
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public Dictionary<int, bool> BadgesAndAccess { get; set; }

        
        public Badge() { }
        public Badge(int badgeID, Dictionary<int, bool> badgesAndAccess)
        {
            BadgeID = badgeID;
            BadgesAndAccess = badgesAndAccess;
        }
    }

    public class Door
    {
        public int DoorNumber { get; set; }
        public bool DoorAccess { get; set; }

        public Door() { }

        public Door(int doorNumber, bool doorAccess)
        {
            DoorNumber = doorNumber;
            DoorAccess = doorAccess;
        }
    }
}


