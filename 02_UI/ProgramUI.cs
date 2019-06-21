using _02_Claim_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_UI
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            SeedClaimQueue();
            ClaimMainMenu();
        }

        public void ClaimMainMenu()
        {
            bool continueToRunClaimMainMenu = true;
            while (continueToRunClaimMainMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item\n" + "1.See all claims \n" + "2. Take care of next claim \n" + "3.Enter a new claim \n" + "4. Stop doing this menu thing \n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllThoseClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        BeginNewClaim();
                        break;
                    case "4":
                        continueToRunClaimMainMenu = false;
                        break;
                    default:
                        Console.WriteLine("Thats not one of the options, dumbass. Try again.\n" + "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }          
            
        }

        private void SeeAllThoseClaims()
        {
            Queue<Claim> listOfAllThoseClaims = _claimRepo.ShowAllClaims();

            foreach (Claim claimInList in listOfAllThoseClaims)
            {
                Console.WriteLine($" ClaimID: {claimInList.ClaimID} \n ClaimType: {claimInList.ClaimType} \n Description: {claimInList.Description} \n Amount: {claimInList.ClaimAmount} \n Date of Incident:{claimInList.DateOfIncident} \n Date of Claim: {claimInList.DateOfClaim} \n Claim is Valid(T/F): {claimInList.IsValid}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public bool TakeCareOfNextClaim()
        {
            Claim nextClaim = _claimRepo.DealWithClaim();
            Console.WriteLine($" ClaimID: {nextClaim.ClaimID} \n ClaimType: {nextClaim.ClaimType} \n Description: {nextClaim.Description} \n Amount: {nextClaim.ClaimAmount} \n Date of Incident:{nextClaim.DateOfIncident} \n Date of Claim: {nextClaim.DateOfClaim} \n Claim is Valid(T/F): {nextClaim.IsValid}");
            Console.WriteLine("You want to deal with this now? y/n");
            string userInput = Console.ReadLine();
            if(userInput== "y")
            {
                _claimRepo.DequeueClaim();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return false;
            }        
                
        }

        private void BeginNewClaim()
        {
            Claim newClaim = new Claim();

            Console.WriteLine("Enter the Claim ID:");

            newClaim.ClaimID = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the claim type:");

            int typeNumber = int.Parse(Console.ReadLine());
            newClaim.ClaimType = (ClaimType)typeNumber;    

            Console.WriteLine("Enter a claim description(and make it snappy):");

            newClaim.Description = Console.ReadLine();

            Console.WriteLine("How much were the damages?");

            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("What was the date of the incident? (ex: mm,dd,yyyy)");

            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("What was the date of the claim? (ex: mm,dd,yyyy)");

            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Is the claim valid?");

            if ((newClaim.DateOfIncident - newClaim.DateOfClaim).Days >= 30)
            {
                Console.WriteLine("Nah");
            }
            else
            {
                Console.WriteLine("Yep");
            }
            _claimRepo.AddClaimToQueue(newClaim);
        }
        private void SeedClaimQueue()
        {
            Claim testClaim = new Claim(2, ClaimType.Car, "Damage to Windshield", 420.69m, new DateTime(2019,05,19), new DateTime(2019,06,18),true) ;
            Claim testClaimTwo = new Claim(2, ClaimType.Car, "Damage to Windshield",420.69m, new DateTime(2019,05,19), new DateTime(2019,06,18), true);

            _claimRepo.AddClaimToQueue(testClaim);
            _claimRepo.AddClaimToQueue(testClaimTwo);
        }       
    }
}
