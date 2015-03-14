using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class BehaviorEvent
    {
        public int SessionID { get; set; } //FK Session.ID
        public int InputID { get; set; } //FK Input.ID
        public string InputName { get; set; } //FK Input.Name
        public string InputType { get; set; } //FK Input.Type
        public int ObserverID { get; set; }
        public int Time { get; set; }
    }

    public class BehaviorEventsDbContext : DbContext
    {
        public DbSet<BehaviorEvent> BehaviorEvents { get; set; }
    }
}