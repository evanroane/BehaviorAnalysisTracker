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
            this.CodeSet = codeSetID;
            this.OwnerID = ownerID;
            this.SessionName = sessionName;
            this.SessionDescription = sessionDescription;
        }

        public Session() { }
        
        [Key]
        [Required]
        public int SessionID { get; set; }
        
        //a session must have one CodeSetID
        [Required]
        public int CodeSet { get; set; }

        [Required]
        public string OwnerID { get; set; }
        
        [Required]
        public string SessionName { get; set; }
        
        [Required]
        public string SessionDescription { get; set; }
    }
}