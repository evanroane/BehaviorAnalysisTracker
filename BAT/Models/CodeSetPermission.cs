using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class CodeSetPermission
    {
        public int OwnerID {get; set;}
        public int CodeSetID {get; set;}
        public int ParticipantID { get; set; }
    }
}