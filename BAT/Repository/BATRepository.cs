using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using BAT.Models;

namespace BAT.Repository
{
    public class BATRepository : IBATRepository
    {
        private BATDbContext _dbContext;

        public BATRepository()
        {
            _dbContext = new BATDbContext();
            _dbContext.CodeSets.Load();
            _dbContext.Inputs.Load();
            _dbContext.CodeSetPermissions.Load();
            _dbContext.Sessions.Load();
            _dbContext.BehaviorEvents.Load();
            _dbContext.SessionPermissions.Load();
        }

        public void Clear()
        {
            var codeSets = this.AllCodeSets();
            var inputs = this.AllInputs();
            var behaviorEvents = this.AllBehaviorEvents();
            var codeSetPermissions = this.GetAllPermissions();
            var sessionPermissions = this.AllSessionPermissions();
            _dbContext.CodeSets.RemoveRange(codeSets);
            _dbContext.Inputs.RemoveRange(inputs);
            _dbContext.BehaviorEvents.RemoveRange(behaviorEvents);
            _dbContext.CodeSetPermissions.RemoveRange(codeSetPermissions);
            _dbContext.SaveChanges();
        }

        public BATDbContext Context()
        {
            return _dbContext;
        }

        public int GetCountCodeSets()
        {
            return _dbContext.CodeSets.Count<CodeSet>();
            //int inputs = _dbContext.Inputs.Count<Input>();
            //int codeSetPermissions = _dbContext.CodeSetPermissions.Count<CodeSetPermission>();
            //int sessions = _dbContext.Sessions.Count<Session>();
            //int behaviorEvents = _dbContext.BehaviorEvents.Count<BehaviorEvent>();
            //int sessionPermission = _dbContext.SessionPermissions.Count<SessionPermission>();
        }

        //Session: Create
        public void CreateSession(Session S) 
        {
            _dbContext.Sessions.Add(S);
            _dbContext.SaveChanges();
        }
        
        //Session: Read
        public List<Session> AllSessions(string userID)
        {
            var query = from Session in _dbContext.Sessions
                        where Session.OwnerID == userID
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

        //Session: Update
        public void ModifySessionName(Session s, string sessionName)
        {
            s.SessionName = sessionName;
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

        //Input: Create
        public void CreateInput(Input I)
        {
            _dbContext.Inputs.Add(I);
            _dbContext.SaveChanges();
        }

        //Input: Read
        public List<Input> AllInputs()
        {
            var query = from Input in _dbContext.Inputs
                        select Input;
            return query.ToList<Input>();
        }
        
        public List<Input> GetInputsByCodeSetID(int id)
        {
            var query = from Input in _dbContext.Inputs
                        where Input.CodeSetID == id
                        select Input;
            return query.ToList<Input>();
        }

        //Input: Update
        public void UpdateInput(Input I, string name, string inputType, string inputColor)
        {
            I.InputName = name;
            I.InputType = inputType;
            I.InputColor = inputColor;
            _dbContext.SaveChanges();
        }

        //Input: Delete
        public void DeleteInput(Input I)
        {
            _dbContext.Inputs.Remove(I);
            _dbContext.SaveChanges();
        }

        //BehaviorEvent: Create
        public void CreateBehaviorEvent(BehaviorEvent BE)
        {
            _dbContext.BehaviorEvents.Add(BE);
            _dbContext.SaveChanges();
        }

        //BehaviorEvent: Read
        public List<BehaviorEvent> AllBehaviorEvents()
        {
            var query = from BehaviorEvent in _dbContext.BehaviorEvents
                        select BehaviorEvent;
            return query.ToList<BehaviorEvent>();
        }

        public List<BehaviorEvent> GetEventsBySessionID(int id)
        {
            var query = from BehaviorEvent in _dbContext.BehaviorEvents
                        where BehaviorEvent.SessionID == id
                        select BehaviorEvent;
            return query.ToList<BehaviorEvent>();
        }
        
        //BehaviorEvent: Update
        
        public void UpdateEventInput(BehaviorEvent BE, int inputID)
        {
            BE.InputID = inputID;
            _dbContext.SaveChanges();
        }

        public void UpdateEventSeconds(BehaviorEvent BE, int seconds)
        {
            BE.Seconds = seconds;
            _dbContext.SaveChanges();
        }


        //BehaviorEvent: Delete
        public void DeleteEvent(BehaviorEvent BE)
        {
            _dbContext.BehaviorEvents.Remove(BE);
            _dbContext.SaveChanges();
        }

        //CodeSetPermissions: Create
        public void GrantPermission(string ownerID, string participantID, int codeSetID)
        {
            CodeSetPermission CSP = new CodeSetPermission();
            CSP.OwnerID = ownerID;
            CSP.ParticipantID = participantID;
            CSP.CodeSetID = codeSetID;
        }

        //CodeSetPermissions: Read
        public List<CodeSetPermission> GetAllPermissions()
        {
            var query = from CodeSetPermission in _dbContext.CodeSetPermissions
                        select CodeSetPermission;
            return query.ToList<CodeSetPermission>();
        }

        public List<CodeSetPermission> GetParticipatingCodeSets(string userID)
        {
            var query = from CodeSetPermission in _dbContext.CodeSetPermissions
                        where CodeSetPermission.ParticipantID == userID
                        select CodeSetPermission;
            return query.ToList<CodeSetPermission>();
        }
        
        //CodeSetPermissions: Delete
        public void RemoveCodeSetPermission(CodeSetPermission CSP)
        {
            _dbContext.CodeSetPermissions.Remove(CSP);
            _dbContext.SaveChanges();
        }

        //CodeSet: Create
        public void CreateCodeSet(CodeSet C)
        {
            _dbContext.CodeSets.Add(C);
            _dbContext.SaveChanges();
        }

        //CodeSet: Read
        public List<CodeSet> AllCodeSets()
        {
            var query = from CodeSet in _dbContext.CodeSets
                        select CodeSet;
            return query.ToList<CodeSet>();
        }
        
        public CodeSet GetCodeSetByID(int id)
        {
            var query = from CodeSet in _dbContext.CodeSets
                        where CodeSet.CodeSetID == id
                        select CodeSet;
            return query.First<CodeSet>();
        }

        public CodeSet GetCodeSetByName(string name)
        {
            var query = from CodeSet in _dbContext.CodeSets
                        where CodeSet.CodeSetName == name
                        select CodeSet;
            return query.First<CodeSet>();
        }

        public List<CodeSet> GetCodeSetByUserID(string UserID)
        {
            var query = from CodeSet in _dbContext.CodeSets
                        where CodeSet.CodeSetOwner == UserID
                        select CodeSet;
            return query.ToList<CodeSet>();
        }

        //CodeSet: Update
        public void UpdateCodeSet(int id, CodeSet CS)
        {
            var oldVersion = from CodeSet in _dbContext.CodeSets
                        where CodeSet.CodeSetID == id
                        select CodeSet;
            CodeSet toBeEdited = (CodeSet)oldVersion;
            toBeEdited.CodeSetName = CS.CodeSetName;
            toBeEdited.CodeSetDescription = CS.CodeSetDescription;
            _dbContext.SaveChanges();
        }

        //CodeSet: Delete
        public void DeleteCodeSet(CodeSet CS)
        {
            _dbContext.CodeSets.Remove(CS);
            _dbContext.SaveChanges();
        }

        //SessionPermission: Create
        public void CreateSessionPermission(SessionPermission SP)
        {
            throw new NotImplementedException();
        }

        //SessionPermission: Read
        public List<SessionPermission> GetSessionPermissionByUserID(string userID)
        {
            var query = from SessionPermission in _dbContext.SessionPermissions
                        where SessionPermission.ParticipantID == userID
                        select SessionPermission;
            return query.ToList<SessionPermission>();
        }

        public List<SessionPermission> AllSessionPermissions()
        {
            var query = from SessionPermission in _dbContext.SessionPermissions
                        select SessionPermission;
            return query.ToList<SessionPermission>();
        }

        //Session Permission: Delete
        public void DeleteSessionPermission(SessionPermission SP)
        {
            _dbContext.SessionPermissions.Remove(SP);
            _dbContext.SaveChanges();
        }

        public void DeleteSessionPermissionByID(int id)
        {
            var query = from SessionPermission in _dbContext.SessionPermissions
                        where SessionPermission.PermissionID == id
                        select SessionPermission;
            SessionPermission selected = query.First<SessionPermission>();
            DeleteSessionPermission(selected);
        }


    }
}