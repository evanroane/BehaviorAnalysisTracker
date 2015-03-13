using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class Session
    {
        public int SessionID;
        public string Name;
        public string Description;
        public int CodeSetID; //FK
        public int OwnerID; //FK
    }

    public class SessionsDbContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
    }
}