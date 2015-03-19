using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using BAT.Models;

namespace BAT.Repository
{
    public class Repository : IRepository
    {
        private BATDbContext _dbContext;

        public Repository()
        {
            _dbContext = new BATDbContext();
            _dbContext.CodeSets.Load();
            _dbContext.Inputs.Load();
            _dbContext.Sessions.Load();
            _dbContext.BehaviorEvents.Load();
            _dbContext.CodeSetPermissions.Load();
        }

        public void Clear()
        {
            var codeSets = this.AllCodeSets();
            var inputs = this.AllInputs();
            var sessions = this.AllSessions();
            var behaviorEvents = this.AllBehaviorEvents();
            var codeSetPermissions = this.AllCodeSetPermissions();
            _dbContext.CodeSets.RemoveRange(codeSets);
            _dbContext.Inputs.RemoveRange(inputs);
            _dbContext.Sessions.RemoveRange(sessions);
            _dbContext.BehaviorEvents.RemoveRange(behaviorEvents);
            _dbContext.CodeSetPermissions.RemoveRange(codeSetPermissions);
            _dbContext.SaveChanges();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public BATDbContext Context()
        {
            return _dbContext;
        }

        //Session: Create
        public void CreateSession(Session S) 
        {
            _dbContext.Sessions.Add(S);
            _dbContext.SaveChanges();
        }
        
        //Session: Read
        public List<Session> AllSessions()
        {
            var query = from Session in _dbContext.Sessions
                        select Session;
            return query.ToList<Session>();
        }


        public int GetSessionID(string sessionName)
        {
            var query = from Session in _dbContext.Sessions
                        where Session.SessionName == sessionName
                        select Session;
            return query.First<Session>().SessionID;
        }

        public Session ReadSession(int id)
        {
            var query = from Session in _dbContext.Sessions
                        where Session.SessionID == id
                        select Session;
            return query.First<Session>();
        }

        public List<Session> AllSessions(int UserID)
        {
            var query = from Session in _dbContext.Sessions
                        where Session.OwnerID == UserID
                        select Session;
            return query.ToList<Session>();
        }

        //Session: Update
        public void ModifySession(Session s, int sessionID, int codeSetID, int ownerID, string sessionName, string sessionDescription, Nullable<int> participantID)
        {
            s.SessionID = sessionID;
            s.CodeSetID = codeSetID;
            s.OwnerID = ownerID;
            s.SessionName = sessionName;
            s.ParticipantID = participantID;
        }

        //Session: Delete
        public void DeleteSessionByID(int id)
        {
            Session s = ReadSession(id);
            DeleteSession(s);
        }

        public void DeleteSession(Session s)
        {
            _dbContext.Sessions.Remove(s);
            _dbContext.SaveChanges();
        }

        //Participant: Create
        public void AddParticipant()
        {
            throw new NotImplementedException();
        }
        
        //Participant: Read
        public void CheckParticipant()
        {
            throw new NotImplementedException();
        }

        public void AllParticipants()
        {
            throw new NotImplementedException();
        }

        //Participant: Delete
        public void RemoveParticipant()
        {
            throw new NotImplementedException();
        }

        //Input: Create
        public void CreateInput()
        {
            throw new NotImplementedException();
        }

        //Input: Read
        public List<Input> AllInputs()
        {
            var query = from Input in _dbContext.Inputs
                        select Input;
            return query.ToList<Input>();
        }
        
        public void GetInputsByCodeSet()
        {
            throw new NotImplementedException();
        }

        public void GetInput()
        {
            throw new NotImplementedException();
        }

        //Input: Update
        public void UpdateInput()
        {
            throw new NotImplementedException();
        }

        //Input: Delete
        public void DeleteInput()
        {
            throw new NotImplementedException();
        }

        //BehaviorEvent: Create
        public void AddEvent()
        {
            throw new NotImplementedException();
        }

        //BehaviorEvent: Read
        public List<BehaviorEvent> AllBehaviorEvents()
        {
            var query = from BehaviorEvent in _dbContext.BehaviorEvents
                        select BehaviorEvent;
            return query.ToList<BehaviorEvent>();
        }
        
        public void GetEvent()
        {
            throw new NotImplementedException();
        }

        public void GetEventsByCodeSet()
        {
            throw new NotImplementedException();
        }

        public void GetEventsBySession()
        {
            throw new NotImplementedException();
        }
        
        //BehaviorEvent: Update
        
        public void UpdateEvent()
        {
            throw new NotImplementedException();
        }

        //BehaviorEvent: Delete
        public void DeleteEvent()
        {
            throw new NotImplementedException();
        }

        //CodeSetPermissions: Create
        public void GrantPermission()
        {
            throw new NotImplementedException();
        }

        //CodeSetPermissions: Read
        public List<CodeSetPermission> AllCodeSetPermissions()
        {
            var query = from CodeSetPermission in _dbContext.CodeSetPermissions
                        select CodeSetPermission;
            return query.ToList<CodeSetPermission>();
        }
        
        public void GetPermission()
        {
            throw new NotImplementedException();
        }

        public void GetUserPermissions()
        {
            throw new NotImplementedException();
        }

        //CodeSetPermissions: Delete
        public void RemovePermission()
        {
            throw new NotImplementedException();
        }

        //CodeSet: Create
        public void CreateCodeSet()
        {
            throw new NotImplementedException();
        }

        //CodeSet: Read
        public List<CodeSet> AllCodeSets()
        {
            var query = from CodeSet in _dbContext.CodeSets
                        select CodeSet;
            return query.ToList<CodeSet>();
        }
        
        public void GetCodeSet()
        {
            throw new NotImplementedException();
        }

        //CodeSet: Update
        public void UpdateCodeSet()
        {
            throw new NotImplementedException();
        }

        //CodeSet: Delete
        public void DeleteCodeSet()
        {
            throw new NotImplementedException();
        }

    }
}