using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAT;
using BAT.Repository;
using BAT.Models;

namespace BATTests
{
    [TestClass]
    public class TestRepository
    {
        private static BATRepository repo;

        //DataForTests
        static string firstUserId = "2ec05fb5-f4b7-4a27-89f8-c994312416ad";
        static string secondUserId = "b731d8a7-d9c0-487e-8744-cc89c9e8c323";
        static CodeSet CS = new CodeSet("FCT", "Functional Communication Training", firstUserId);
        static Input I = new Input(CS.CodeSetID, "aggression", "event", "btn-warning");
        static CodeSetPermission CSP = new CodeSetPermission(firstUserId, secondUserId, CS.CodeSetID);
        static Session S = new Session(CS.CodeSetID, firstUserId, "Bellevue Middle", "one on one");
        static BehaviorEvent BE = new BehaviorEvent(firstUserId, S.SessionID, I.InputID, 5);
        static SessionPermission SP = new SessionPermission(firstUserId, secondUserId, S.SessionID);
        static Participant P = new Participant(S.SessionID, firstUserId, secondUserId);

        [ClassInitialize]
        public static void SetUp(TestContext _context)
        {
            repo = new BATRepository();
            repo.Clear();
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            repo.Clear();
        }

        /* TEST METHODS: */

        [TestMethod]
        public void TestCreateCodeSet()
        {
            repo.CreateCodeSet(CS);
            Assert.AreEqual(1, repo.GetCountCodeSets());
            repo.Clear();
        }

        [TestMethod]
        public void TestGetSessionID()
        {
            repo.CreateSession(S);
            Assert.AreEqual<int>(6, repo.GetSessionID("Bellevue Middle"));
            repo.Clear();
        }

        [TestMethod]
        public void TestReadSession()
        {
            repo.CreateSession(S);
            repo.ReadSession(S.SessionID);
            Assert.AreEqual("Bellevue Middle", S.SessionName);
            repo.Clear();
        }

        [TestMethod]
        public void TestModifySession()
        {
            repo.CreateSession(S);
            repo.ModifySessionName(S, "Middle");
            Assert.AreEqual("Middle", S.SessionName);
        }

    }
}
