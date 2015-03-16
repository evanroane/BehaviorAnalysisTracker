using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class CodeSetPermission
    {
        [Required]
        public int OwnerID {get; set;}

        [Required]
        public int CodeSetID {get; set;}

        [Required]
        public int ParticipantID { get; set; }
    }
}