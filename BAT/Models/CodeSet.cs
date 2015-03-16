using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAT.Models
{
    public class CodeSet
    {
        //Many other tables may access CodeSetId
        [Required]
        public int CodeSetID { get; set; }

        [ForeignKey("CodeSetID")]
        public virtual CodeSet CodeSet { get; set; }

        [Required]
        public string CodeSetName { get; set; }

        [Required]
        public string CodeSetDescription { get; set; }
    }
}