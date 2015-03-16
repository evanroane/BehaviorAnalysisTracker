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
        //Each BehaviorEvent is associated with one SessionID
        [Required]
        public int SessionID { get; set; }

        [ForeignKey("SessionID")]
        public virtual Session Session { get; set; }

        //Each BehaviorEvent has one InputID
        [Required]
        public int InputID { get; set; }

        [ForeignKey("InputID")]
        public virtual Input Input { get; set; }

        [Required]
        public int ObserverID { get; set; }

        [Required]
        public int Time { get; set; }
    }
}