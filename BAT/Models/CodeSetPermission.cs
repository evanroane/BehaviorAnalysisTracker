using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class CodeSetPermission
    {
        public CodeSetPermission(int ownerId, int participantID, int codeSetID)
        {
            this.OwnerID = ownerId;
            this.ParticipantID = participantID;
            this.CodeSetID = codeSetID;
        }
        
        public CodeSetPermission() { }

        [Required]
        public int OwnerID {get; set;}

        [Required]
        public int CodeSetID {get; set;}

        [Required]
        public int ParticipantID { get; set; }
    }
}