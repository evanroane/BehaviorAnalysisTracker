using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class BehaviorEvent
    {
        public int SessionID; //FK
        public int BehaviorEventID; //FK
        public int ObserverID;
        public int Time;
        public string BehaviorEventName; //FK
    }

    public class BehaviorEventsDbContext : DbContext
    {
        public DbSet<BehaviorEvent> BehaviorEvents { get; set; }
    }
}