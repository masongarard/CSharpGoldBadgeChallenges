using ChallengeClasses;
using Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_UI
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedMenu();
            MenuMenu();
        }

        public void MenuMenu()
        {
            bool continueToRunMenuMenu = true;
            while (continueToRunMenuMenu)
            {
                Console.Clear();
                Console.WriteLine("Press the number of the thing you want to do.\n" + "1.See the Menu \n" + "2. Add a new dish \n" + "3.Get rid of a dish \n" + "4. Close the menu and leave me alone with my thoughts. \n" );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeTheFullMenu();
                        break;
                    case "2":
                        AddNewDishToMenu();
                        break;
                    case "3":
                        RemoveOldDishFromMenu();
                        break;
                    case "4":
                        continueToRunMenuMenu=false;
                        break;
                    default:
                        Console.WriteLine("One of the options that you can actually select, if you please. Thanks.\n" +"Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddNewDishToMenu()
        {
            MenuItem newDish = new MenuItem();

            Console.WriteLine("What's this dish called?");

            newDish.ItemName = Console.ReadLine();

            Console.WriteLine("Could you give it a descrption please?");

            newDish.Description = Console.ReadLine();

            Console.WriteLine("What are the ingredients?\n" + "ex: potatoes, salt, frying oil, a knife");

            newDish.ListOfIngredients = Console.ReadLine();

            Console.WriteLine("What number dish is this?\n" + "ex: 5, 6, 12");

            newDish.MealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("How much is this thing you've made?");

            newDish.MealPrice = decimal.Parse(Console.ReadLine());
        }

        private void SeeTheFullMenu()
        {
            List<MenuItem> listOfMenuItems = _menuRepo.SeeTheMenu();

            foreach (MenuItem menuItem in listOfMenuItems)
            {
                Console.WriteLine($" {menuItem.ItemName} {menuItem.Description}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        private void SeedMenu()
        {
            MenuItem pBNJK = new MenuItem("PBNJK", "PBNJ, but theres a knife in it", "Peanut Butter, Strawberry Jelly, Bread, 1(one) Kitchen Knife", 1, 4.20m);
            MenuItem frenchFries = new MenuItem("French Fries", "Its french fries. Theres not much else to it...", "Potatoes, Salt, Frying Oil, 1(one) Kitchen Knife", 2, 6.90m);

            _menuRepo.AddItemToMenu(pBNJK);
            _menuRepo.AddItemToMenu(frenchFries);
        }

        private void RemoveOldDishFromMenu()
        {
            Console.WriteLine("Which dish is out?");

            string oldDish = Console.ReadLine();
          
            MenuItem menuItem = _menuRepo.GetDishByItemName(oldDish);
            
            if (menuItem == null)
            {
                Console.WriteLine("We dont make that here, dumbass. Try again.");
            }
            _menuRepo.RemoveItemFromMenu(menuItem);
        }
    }
}
