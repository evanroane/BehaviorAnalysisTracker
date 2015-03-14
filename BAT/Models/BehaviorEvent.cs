using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class BehaviorEvent
    {
        public int SessionID; //FK Session.ID
        public int InputID; //FK Input.ID
        public string InputName; //FK Input.Name
        public string InputType; //FK Input.Type
        public int ObserverID;
        public int Time;
    }

    public class BehaviorEventsDbContext : DbContext
    {
        public DbSet<BehaviorEvent> BehaviorEvents { get; set; }
    }
}