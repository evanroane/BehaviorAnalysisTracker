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

        [Key, ForeignKey("Session")]
        public int SessionID { get; set; }

        [Key, ForeignKey("Input")]
        public int InputID { get; set; }
       
        public int ObserverID { get; set; }
        public int Time { get; set; }
    }
}