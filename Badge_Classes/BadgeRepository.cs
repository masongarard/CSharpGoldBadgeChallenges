using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Classes
{
    public class BadgeRepository
    {
        
        private Dictionary<int, Dictionary<int, bool>> _badgeDictionary = new Dictionary<int, Dictionary<int, bool>>();

            

        internal void SeedListOfBadges()
        {
            
            Badge masterBadge = new Badge(12, new Dictionary<int, bool>());
            Badge masterBadgeTwo = new Badge(13, new Dictionary<int, bool>());

            
            AddNewBadge(masterBadge);
            AddNewBadge(masterBadgeTwo);
        }
        
        public void AddNewBadge(Badge newBadge)
        {
            _badgeDictionary.Add(newBadge.BadgeID, newBadge.BadgesAndAccess); 
        }

        
        public void AddNewDoorWithAccess(Door newDoor, int badgeID)
        {
            
            Dictionary<int, bool> doorAccessPair = _badgeDictionary[badgeID];
            doorAccessPair.Add(newDoor.DoorNumber, newDoor.DoorAccess);
        }

       
        public void AccessUpdate(Door updatedDoor, int badgeID)
        {
            Dictionary<int, bool> doorAccessPairToUpdate = _badgeDictionary[badgeID];
            doorAccessPairToUpdate[updatedDoor.DoorNumber] = updatedDoor.DoorAccess;


            

        }

        
        public Badge GetBadgeByBadgeID(int badgeID)
        {
           
            foreach (KeyValuePair<int, Dictionary<int, bool>> badge in _badgeDictionary)
            {
                if (badge.Key == badgeID)
                {
                    Badge foundBadge = new Badge(badge.Key, badge.Value); 
                    return foundBadge;
                }
            }
            return null;
        }
        
        public Door GetDoorByDoorNumber(int doorNumber, int badgeNumber)
        {
            
            foreach (var badgeAccess in _badgeDictionary)
            {
                if (badgeAccess.Key == badgeNumber)
                {
                    foreach (var door in badgeAccess.Value)
                    {
                        if (door.Key == doorNumber)
                            return new Door(door.Key, door.Value); 
                    }
                }
            }
            
            return null;
        }

        
        public Dictionary<int, Dictionary<int, bool>> SeeAllBadges()
        {
            return _badgeDictionary;
        }
    }

}