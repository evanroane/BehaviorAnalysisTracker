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
        public Input(int codeSetID, string inputName, string inputType, string inputColor)
        {
            this.CodeSetID = codeSetID;
            this.InputName = inputName;
            this.InputType = inputType;
            this.InputColor = inputColor;
        }

        public Input() { }

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