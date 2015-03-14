using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class Input
    {
        [Key, ForeignKey("CodeSet")]
        public int CodeSetID { get; set; }
        
        public int InputID { get; set; }
        public string InputName { get; set; }
        public string InputType { get; set; }
        public string InputColor { get; set; }
    }
}