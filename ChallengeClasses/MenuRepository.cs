using Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeClasses
{
    public class MenuRepository
    {
        private List<MenuItem> _listOfItems = new List<MenuItem>();

        public void AddItemToMenu(MenuItem newDish)
        {
            _listOfItems.Add(newDish);
        }
        public bool RemoveItemFromMenu(MenuItem oldDish)
        {
            int menuCount = _listOfItems.Count;
            _listOfItems.Remove(oldDish);
            if (menuCount> _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<MenuItem> SeeTheMenu()
        {
            return _listOfItems;
        }
        public MenuItem GetDishByItemName(string menuItem)
        {
            foreach (MenuItem dish in _listOfItems)
            {
                if (dish.ItemName.ToLower() == menuItem.ToLower())
                {
                    return dish;
                }
            }
            return null;
        }
    }
}
