using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CodeSetID { get; set; } //FK CodeSet.ID
        public int OwnerID { get; set; }
    }

    public class SessionsDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
    }
}