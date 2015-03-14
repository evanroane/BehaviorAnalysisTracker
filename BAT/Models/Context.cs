using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class BATDbContext : DbContext
    {
        public DbSet<BehaviorEvent> BehaviorEvents { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<CodeSet> CodeSets { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<CodeSetPermission> CodeSetPermissions { get; set; }
    }
}