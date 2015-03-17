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
        public CodeSet(string codeSetName, string codeSetDescription)
        {
            this.CodeSetName = codeSetName;
            this.CodeSetDescription = codeSetDescription;
        }
        
        public CodeSet() { }
        //Many other tables may access CodeSetId
        [Key]
        [Required]
        public int CodeSetID { get; set; }

        //Many other tables may access CodeSetId
        public ICollection<CodeSet> CodeSets { get; set; }

        [Required]
        public string CodeSetName { get; set; }

        [Required]
        public string CodeSetDescription { get; set; }
    }
}