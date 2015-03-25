using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class BehaviorEvent
    {
        public BehaviorEvent(string observerID, int sessionID, int inputID, int seconds)
        {
            this.ObserverID = observerID;
            this.SessionID = sessionID;
            this.InputID = inputID;
            this.Seconds = seconds;
        }
        
        public BehaviorEvent() { }

        [Required]
        public int SessionID { get; set; }

        [Required]
        public int InputID { get; set; }

        [ForeignKey("InputID")]
        public virtual Input Input { get; set; }

        [Required]
        public string ObserverID { get; set; }

        [Required]
        public int Seconds { get; set; }

        [Key]
        [Required]
        public int BehaviorEventID { get; set; }
    }
}