using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class Session
    {
        //other models may use SessionID
        public int SessionID { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        
        //a session must have one CodeSetID
        [Required]
        public int CodeSetID { get; set; }

        [ForeignKey("CodeSetID")]
        public virtual CodeSet CodeSet { get; set; }

        //a session may have one or more ParticipantID
        public Nullable<int> ParticipantID { get; set; }

        [ForeignKey("ParticipantID")]
        public virtual Participant Participant { get; set; }

        [Required]
        public int OwnerID { get; set; }
        
        [Required]
        public string SessionName { get; set; }
        
        [Required]
        public string SessionDescription { get; set; }
    }
}