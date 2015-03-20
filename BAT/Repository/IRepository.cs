using System.Collections.Generic;
using BAT.Models;
using System;

namespace BAT.Repository
{
    public interface IRepository
    {
        int GetCountCodeSets();
        
        //Session: Create
        void CreateSession(Session S);
        //Session: Read
        int GetSessionID(string sessionName);
        Session ReadSession(int id);
        List<Session> AllSessions(string UserID);
        //Session: Update
        void ModifySessionName(Session s, string sessionName);
        //Session: Delete
        void DeleteSessionByID(int id);
        void DeleteSession(Session s);


        //Participant: Create
        void AddParticipant(string ownerID, string participantID, int sessionID);
        //Participant: Read
        List<Participant> AllParticipants(int sessionID);
        //Participant: Delete
        void RemoveParticipant(Participant P);

        //Input: Create
        void CreateInput(string name, string inputType, string inputColor);
        //Input: Read
        List<Input> GetInputsByCodeSetID(int id);
        //Input: Update
        void UpdateInput(Input I, string name, string inputType, string inputColor);
        //Input: Delete
        void DeleteInput(Input I);

        //BehaviorEvent: Create
        void CreateBehaviorEvent(int sessionID, string observerID, int seconds);
        //BehaviorEvent: Read
        void GetEvent();
        void GetEventsByCodeSet();
        void GetEventsBySession();
        //BehaviorEvent: Update
        void UpdateEvent();
        //BehaviorEvent: Delete
        void DeleteEvent(BehaviorEvent BE);

        //CodeSetPermissions: Create
        void GrantPermission();
        //CodeSetPermissions: Read
        void GetPermission();
        void GetUserPermissions();
        //CodeSetPermissions: Delete
        void RemoveCodeSetPermission(CodeSetPermission CSP);

        //CodeSet: Create
        void CreateCodeSet(CodeSet CS);
        //CodeSet: Read
        CodeSet GetCodeSetByID(int id);
        CodeSet GetCodeSetByName(string name);
        //CodeSet: Update
        void UpdateCodeSet();
        //CodeSet: Delete
        void DeleteCodeSet(CodeSet CS);

        //SessionPermissions: Read
        List<SessionPermission> AllSessionPermissions();
    }
}
