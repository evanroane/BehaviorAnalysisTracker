using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAT;
using BAT.Models;

namespace BAT.Repository
{
    public class Repository : IRepository
    {
        public int GetCount()
        {
            throw new NotImplementedException();
        }

        //Session: Create
        public void CreateSession(Session S) 
        {
            throw new NotImplementedException();
        }
        //Session: Read
        public void GetSessionID(Session S)
        {
            throw new NotImplementedException();
        }

        public void ReadSession(int id)
        {
            throw new NotImplementedException();
        }

        public void AllSessions()
        {
            throw new NotImplementedException();
        }

        //Session: Update
        public void ModifySession()
        {
            throw new NotImplementedException();
        }

        //Session: Delete
        public void DeleteSession(int id)
        {
            throw new NotImplementedException();
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