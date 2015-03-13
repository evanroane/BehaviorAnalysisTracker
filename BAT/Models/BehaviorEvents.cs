using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAT.Models
{
    public class BehaviorEvents
    {
        public int SessionID; //FK
        public int BehaviorEventID; //FK
        public int ObserverID;
        public int Time;
        public string BehaviorEventName; //FK
    }
}