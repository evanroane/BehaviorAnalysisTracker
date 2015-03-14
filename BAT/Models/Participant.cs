using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class Participant
    {
        [Key, ForeignKey("Session")]
        public int SessionID { get; set; }

        public int UserID { get; set; }
    }
}