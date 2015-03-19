using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAT;
using BAT.Repository;
using BAT.Models;

namespace BATTests
{
    [TestClass]
    public class TestRepository
    {
        private static Repository repo;

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new Repository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            repo.Clear();
        }


        [TestMethod]
        public void TestCreateSession()
        {
            
        }

        [TestMethod]
        public void TestGetSessionID()
        {

        }

        [TestMethod]
        public void TestReadSession()
        {

        }

        [TestMethod]
        public void TestAllSessions()
        {

        }

        [TestMethod]
        public void TestModifySession()
        {
            
        }

        [TestMethod]
        public void TestDeleteSessionByID()
        {

        }

        [TestMethod]
        public void TestDeleteSession()
        {

        }


    }
}
