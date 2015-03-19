using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class SessionPermission
    {
        public SessionPermission(string ownerId, string participantID, int sessionID)
        {
            this.OwnerID = ownerId;
            this.ParticipantID = participantID;
            this.SessionID = sessionID;
        }
        
        public SessionPermission() { }

        [Required]
        public string OwnerID {get; set;}

        [Required]
        public int SessionID {get; set;}

        [Required]
        public string ParticipantID { get; set; }
    }
}