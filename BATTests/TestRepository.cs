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
        //public CodeSet(string codeSetName, string codeSetDescription)
        //public BehaviorEvent(int sessionID, int inputID, int observerID)
        public void DataForTests()
        {
            string firstUserId = "2ec05fb5-f4b7-4a27-89f8-c994312416ad";
            string secondUserId = "b731d8a7-d9c0-487e-8744-cc89c9e8c323";
            CodeSet CS = new CodeSet("FCT", "Functional Communication Training", firstUserId);
            Input I = new Input(CS.CodeSetID, "aggression", "event", "btn-warning");
            CodeSetPermission CSP = new CodeSetPermission(firstUserId, secondUserId, CS.CodeSetID);
            //SessionPermission
            Session S = new Session(CS.CodeSetID, firstUserId, "Bellevue Middle", "one on one");
            BehaviorEvent BH = new BehaviorEvent(firstUserId, S.SessionID, I.InputID);

            Participant P = new Participant(S.SessionID, firstUserId, secondUserId);
           
            repo.CreateSession(S);

        }

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
            repo.CreateSession(S);
            repo.Clear();
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
