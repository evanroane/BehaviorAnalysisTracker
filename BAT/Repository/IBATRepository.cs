using System.Collections.Generic;
using BAT.Models;
using System;

namespace BAT.Repository
{
    public interface IBATRepository
    {
        int GetCountCodeSets();
        
        //Session: Create
        void CreateSession(Session S);
        //Session: Read
        int GetSessionID(string sessionName);
        Session ReadSession(int id);
        List<Session> AllSessions(string userID);
        //Session: Update
        void ModifySessionName(Session s, string sessionName);
        //Session: Delete
        void DeleteSessionByID(int id);
        void DeleteSession(Session s);

        //Input: Create
        void CreateInput(string name, string inputType, string inputColor);
        //Input: Read
        List<Input> GetInputsByCodeSetID(int id);
        //Input: Update
        void UpdateInput(Input I, string name, string inputType, string inputColor);
        //Input: Delete
        void DeleteInput(Input I);

        //BehaviorEvent: Create
        void CreateBehaviorEvent(BehaviorEvent BE);
        //BehaviorEvent: Read
        List<BehaviorEvent> GetEventsBySessionID(int id);
        //BehaviorEvent: Update
        void UpdateEventInput(BehaviorEvent BE, int inputID);
        void UpdateEventSeconds(BehaviorEvent BE, int seconds);
        //BehaviorEvent: Delete
        void DeleteEvent(BehaviorEvent BE);

        //CodeSetPermissions: Create
        void GrantPermission(string ownerID, string participantID, int codeSetID);
        //CodeSetPermissions: Read
        List<CodeSetPermission> GetAllPermissions();
        List<CodeSetPermission> GetUserPermissions(string userID);
        //CodeSetPermissions: Delete
        void RemoveCodeSetPermission(CodeSetPermission CSP);

        //CodeSet: Create
        void CreateCodeSet(CodeSet CS);
        //CodeSet: Read
        CodeSet GetCodeSetByID(int id);
        CodeSet GetCodeSetByName(string name);
        //CodeSet: Update
        void UpdateCodeSetName(CodeSet CS, string newName);

        //CodeSet: Delete
        void UpdateCodeSetDescription(CodeSet CS, string newDescription);

        //SessionPermissions: Create
        void CreateSessionPermission(SessionPermission SP);

        //SessionPermissions: Read
        List<SessionPermission> GetSessionPermissionByUserID(string userID);
        List<SessionPermission> AllSessionPermissions();

        //SessionPermissions: Delete
        void DeleteSessionPermission(SessionPermission SP);
        void DeleteSessionPermissionByID(int id);

    }
}
