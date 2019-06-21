using Badge_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_UI
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepository = new BadgeRepository();
        private List<Badge> _badges = new List<Badge>();
        public void Run()
        {
            SeedMainMenu();           
            BadgeMainMenu();
        }

        public void BadgeMainMenu()
        {
            bool continueToRunBadgeMainMenu = true;
            while (continueToRunBadgeMainMenu)
            {
                Console.Clear();
                Console.WriteLine("Hello, Security Admin, what would you like to do?\n" + "1.Add a badge \n" + "2. Edit a badge \n" + "3.See all badges \n" + "4. gtfo \n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        UpdateBadgeAccess();
                        break;
                    case "3":
                        SeeAllBadges();
                        break;
                    case "4":
                        continueToRunBadgeMainMenu = false;
                        break;
                    default:
                        Console.WriteLine("Thats not one of the options, dumbass. Try again.\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }

        }

        private void AddNewBadge()
        {
            Badge newBadge = new Badge();

            Console.WriteLine("Enter the Badge ID:");

            newBadge.BadgeID = int.Parse(Console.ReadLine());         

            newBadge.BadgesAndAccess= new Dictionary<int, bool>();
            _badges.Add(newBadge);
        }
        public void UpdateBadgeAccess()
        {
            Console.WriteLine("What is the badge number to update?");

            int removedID = int.Parse(Console.ReadLine());

            Badge badgeForAccessInfo = _badgeRepository.GetBadgeByBadgeID(removedID);

          
            if (badgeForAccessInfo == null)
            {
                Console.WriteLine("That one doesnt exist, try again.");
                Console.ReadKey();
            }
            else
            {
                


                foreach (KeyValuePair<int, bool> keyValuePairsInDict in badgeForAccessInfo.BadgesAndAccess)
                {
                    Console.WriteLine($"{keyValuePairsInDict.Key}, {keyValuePairsInDict.Value}");
                }
                
                Console.WriteLine("Which door are you updating?");
                
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        
                        Door doorOneToBeChanged = _badgeRepository.GetDoorByDoorNumber(userInput, removedID ); 
                        Console.WriteLine("Locked or Unlocked");
                        string userSecondaryInput = Console.ReadLine();
                        if (userSecondaryInput == "Locked")
                        {
                            doorOneToBeChanged.DoorAccess = false; // 
                        }
                        else
                        {
                            doorOneToBeChanged.DoorAccess = true;
                        }
                        break;
                    case 2:
                        Door doorTwoToBeChanged = _badgeRepository.GetDoorByDoorNumber(userInput, removedID);
                        Console.WriteLine("Locked or Unlocked");
                        string userTertiaryInput = Console.ReadLine();
                        if (userTertiaryInput == "Locked")
                        {
                            doorTwoToBeChanged.DoorAccess = false;
                        }
                        else
                        {
                            doorTwoToBeChanged.DoorAccess = true;
                        }
                        break;


                }

            }


        }
        private void SeeAllBadges()
        {
            foreach (Badge badgeToBeFound in _badges)
            {
                Console.WriteLine($"{badgeToBeFound.BadgeID}");
            }

            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        private void SeedMainMenu()
        {
           
            Badge masterBadge = new Badge(12, new Dictionary<int, bool>());
            Badge masterBadgeTwo = new Badge(13, new Dictionary<int, bool>());


            
            _badgeRepository.AddNewBadge(masterBadge);
            _badgeRepository.AddNewBadge(masterBadgeTwo);
        }

    }
}

