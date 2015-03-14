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
        [Key, ForeignKey("CodeSet")]
        public int CodeSetID { get; set; }

        public virtual Participant Participant { get; set; }
        public int OwnerID { get; set; } //Connect to user ID?
        
        public int SessionID { get; set; }
        public string SessionName { get; set; }
        public string SessionDescription { get; set; }
    }
}