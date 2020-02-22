using System;
using System.Collections.Generic;
using Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItem()
        {
            CafeMenu item = new CafeMenu();
            MenuRepository repoDirectory = new MenuRepository();

            bool addResult = repoDirectory.AddNewItem(item);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenuItems()
        {
            CafeMenu content = new CafeMenu();
            MenuRepository repo = new MenuRepository();

            repo.AddNewItem(content);
            List<CafeMenu> contents = repo.ViewMenu();

            bool directoryHadContent = contents.Contains(content);

            Assert.IsTrue(directoryHadContent);
        }
        private MenuRepository _repo;
        private CafeMenu _content;
        [TestInitialize]
        public void AddItemForTest()
        {
            List<string> ingred = new List<string> { "Green", "Red", "Yellow" };
            _repo = new MenuRepository();
            _content = new CafeMenu("Apple", 5, "Green", ingred, 3 );
            _repo.AddNewItem(_content);
        }

        [TestMethod]
        public void GetByName()
        {
                CafeMenu searchResult = _repo.GetByMealName("Apple");
                Assert.AreEqual(_content, searchResult);
        }
    }
}
