using System;
using System.Collections.Generic;
using BadgeAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AddClaim()
        {
            BadgeProp claim = new BadgeProp();
            BadgeRepo repoDirectory = new BadgeRepo();

            bool addResult = repoDirectory.AddNewBadge(claim);

            Assert.IsTrue(addResult);
        }

        private BadgeRepo _repo;
        private BadgeProp _content;

        [TestInitialize]
        public void AddItemForTest()
        {
            List<string> doorAccess = new List<string> { "A55", "A12", "B33" };
            _repo = new BadgeRepo();
            _content = new BadgeProp(152342, doorAccess);
            _repo.AddNewBadge(_content);
        }

        [TestMethod]
        public void GetByName()
        {
            List<string> doorAccess = new List<string> { "A55", "A12", "B33" };
            List<string> searchResult = _repo.GetAccessListByID(152342);
            Assert.AreEqual(doorAccess.Count,searchResult.Count);
        }
    }
}
