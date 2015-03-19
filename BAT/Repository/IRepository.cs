using System.Collections.Generic;
using BAT.Models;
using System;

namespace BAT.Repository
{
    public interface IRepository
    {
        int GetCount();
        
        //Session: Create
        void CreateSession(Session S);
        //Session: Read
        int GetSessionID(string sessionName);
        Session ReadSession(int id);
        List<Session> AllSessions(int UserID);
        //Session: Update
        void ModifySession(Session s, int sessionID, int codeSetID, int ownerID, string sessionName, string sessionDescription,  Nullable<int> participantID);
        //Session: Delete
        void DeleteSessionByID(int id);
        void DeleteSession(Session s);


        //Participant: Create
        void AddParticipant();
        //Participant: Read
        void CheckParticipant();
        void AllParticipants();
        //Participant: Delete
        void RemoveParticipant();

        //Input: Create
        void CreateInput();
        //Input: Read
        void GetInputsByCodeSet();
        void GetInput();
        //Input: Update
        void UpdateInput();
        //Input: Delete
        void DeleteInput();

        //BehaviorEvent: Create
        void AddEvent();
        //BehaviorEvent: Read
        void GetEvent();
        void GetEventsByCodeSet();
        void GetEventsBySession();
        //BehaviorEvent: Update
        void UpdateEvent();
        //BehaviorEvent: Delete
        void DeleteEvent();

        //CodeSetPermissions: Create
        void GrantPermission();
        //CodeSetPermissions: Read
        void GetPermission();
        void GetUserPermissions();
        //CodeSetPermissions: Delete
        void RemovePermission();

        //CodeSet: Create
        void CreateCodeSet();
        //CodeSet: Read
        void GetCodeSet();
        //CodeSet: Update
        void UpdateCodeSet();
        //CodeSet: Delete
        void DeleteCodeSet();
    }
}
