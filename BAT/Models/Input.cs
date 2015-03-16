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
        //an Input row must be associated with a CodeSetID
        [Required]
        public int CodeSetID { get; set; }

        [ForeignKey("CodeSetID")]
        public virtual CodeSet CodeSet { get; set; }

        [Required]
        public int InputID { get; set; }

        [Required]
        public string InputName { get; set; }

        [Required]
        public string InputType { get; set; } //Event or Duration

        [Required]
        public string InputColor { get; set; }
    }
}