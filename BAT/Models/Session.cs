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
        public Session(int codeSetID, string ownerID, string sessionName, string sessionDescription) 
        {
            this.CodeSetID = codeSetID;
            this.OwnerID = ownerID;
            this.SessionName = sessionName;
            this.SessionDescription = sessionDescription;
        }

        public Session() { }
        
        //other models may use SessionID
        public int SessionID { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        
        //a session must have one CodeSetID
        [Required]
        public int CodeSetID { get; set; }

        [ForeignKey("CodeSetID")]
        public virtual CodeSet CodeSet { get; set; }

        [Required]
        public string OwnerID { get; set; }
        
        [Required]
        public string SessionName { get; set; }
        
        [Required]
        public string SessionDescription { get; set; }
    }
}