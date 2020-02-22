using System;
using System.Collections.Generic;
using Komodo_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetClaimList()
        {
            ClaimProp content = new ClaimProp();
            ClaimRepo repo = new ClaimRepo();

            repo.AddClaim(content);
            List<ClaimProp> contents = repo.ViewClaim();

            bool directoryHadContent = contents.Contains(content);

            Assert.IsTrue(directoryHadContent);
        }

        [TestMethod]
        public void AddClaim()
        {
            ClaimProp claim = new ClaimProp();
            ClaimRepo repoDirectory = new ClaimRepo();

            bool addResult = repoDirectory.AddClaimToDirectory(claim);

            Assert.IsTrue(addResult);
        }

        private ClaimRepo _repo;
        private ClaimProp _content;
        [TestInitialize]
        public void AddItemForTest()
        {
            List<string> ingred = new List<string> { "Green", "Red", "Yellow" };
            _repo = new ClaimRepo();
            _content = new ClaimProp(12342,ClaimType.Car, "Missing Steering Wheel", "$400", Convert.ToDateTime("5/12/19"), Convert.ToDateTime("5/22/19"));
            _repo.AddClaimToDirectory(_content);
        }

        [TestMethod]
        public void GetByName()
        {
            ClaimProp searchResult = _repo.GetClaimById(12342);
            Assert.AreEqual(_content, searchResult);
        }
    }
}
