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
            _dbContext.CodeSetPermissions.Load();
            _dbContext.Participants.Load();
            _dbContext.Sessions.Load();
            _dbContext.BehaviorEvents.Load();
            _dbContext.SessionPermissions.Load();
        }

        public void Clear()
        {
            var codeSets = this.AllCodeSets();
            var inputs = this.AllInputs();
            var sessions = this.AllSessions();
            var behaviorEvents = this.AllBehaviorEvents();
            var codeSetPermissions = this.AllCodeSetPermissions();
            var sessionPermissions = this.AllSessionPermissions();
            _dbContext.CodeSets.RemoveRange(codeSets);
            _dbContext.Inputs.RemoveRange(inputs);
            _dbContext.Sessions.RemoveRange(sessions);
            _dbContext.BehaviorEvents.RemoveRange(behaviorEvents);
            _dbContext.CodeSetPermissions.RemoveRange(codeSetPermissions);
            _dbContext.SaveChanges();
        }

        public List<SessionPermission> AllSessionPermissions()
        {
            var query = from SessionPermission in _dbContext.SessionPermissions
                        select SessionPermission;
            return query.ToList<SessionPermission>();
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
            //int participants = _dbContext.Participants.Count<Participant>();
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

        public List<Session> AllSessions(string UserID)
        {
            var query = from Session in _dbContext.Sessions
                        where Session.OwnerID == UserID
                        select Session;
            return query.ToList<Session>();
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

        //Participant: Create
        public void AddParticipant(string ownerID, string participantID, int sessionID)
        {
            Participant part = new Participant();
            part.OwnerID = ownerID;
            part.ParticipantID = participantID;
            part.SessionID = sessionID;
        }
        
        //Participant: Read
        public List<Participant> AllParticipants(int sessionID)
        {
            var query = from Participant in _dbContext.Participants
                        where Participant.SessionID == sessionID
                        select Participant;
            return query.ToList<Participant>();
        }

        //Participant: Delete
        public void RemoveParticipant(Participant P)
        {
            _dbContext.Participants.Remove(P);
        }

        //Input: Create
        public void CreateInput(string name, string inputType, string inputColor)
        {
            Input I = new Input();
            I.InputName = name;
            I.InputType = inputType;
            I.InputColor = inputColor;
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
        }

        //Input: Delete
        public void DeleteInput()
        {
            throw new NotImplementedException();
        }

        //BehaviorEvent: Create
        public void CreateBehaviorEvent(BehaviorEvent BE)
        {
            throw new NotImplementedException();
        }

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



        public void CreateSessionPermission(SessionPermission SP)
        {
            throw new NotImplementedException();
        }

        public void CreateParticipant(Participant P)
        {
            throw new NotImplementedException();
        }
    }
}