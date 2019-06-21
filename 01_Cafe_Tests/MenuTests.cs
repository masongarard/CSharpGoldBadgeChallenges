using System;
using ChallengeClasses;
using Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuTests
    {
        private MenuRepository _menuRepo;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepository();
            _menuItem = new MenuItem("PBNJK", "PBNJ, but theres a knife in it", "Peanut Butter, Strawberry Jelly, Bread, 1(one) Kitchen Knife", 1, 4.20m);

        }

        [TestMethod]
        public void AddItemToMenuTest()
        {
            _menuRepo.AddItemToMenu(_menuItem);
            int expectedMenuCount = 1;
            int actualMenuCount = _menuRepo.SeeTheMenu().Count;
            Assert.AreEqual(expectedMenuCount, actualMenuCount);
        }

        [TestMethod]
        public void RemoveItemFromMenuTest()
        {
            _menuRepo.AddItemToMenu(_menuItem);

            bool wasItRemoved = _menuRepo.RemoveItemFromMenu(_menuItem);

            Assert.IsTrue(wasItRemoved);
        }

        [TestMethod]
        public void GetDishByItemName()
        {
            _menuRepo.AddItemToMenu(_menuItem);

            MenuItem expectedDish = _menuRepo.GetDishByItemName("PBNJK");

            Assert.AreEqual(expectedDish, _menuItem);
        }
    }
}
