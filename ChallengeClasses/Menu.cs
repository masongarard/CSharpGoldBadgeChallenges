using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class MenuItem
    {
        
        public string ItemName { get; set; }
        public string Description { get; set; }        
        public string ListOfIngredients { get; set; }
        public int MealNumber { get; set; }
        public decimal MealPrice { get; set; }

        public MenuItem() { }

        public MenuItem(string itemName, string description, string listOfIngredients, int mealNumber, decimal mealPrice)
        {
            ItemName = itemName;
            Description = description;
            ListOfIngredients = listOfIngredients;
            MealNumber = mealNumber;
            MealPrice = mealPrice;
        }

    }

}
