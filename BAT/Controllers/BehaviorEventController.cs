using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAT.Models;
using BAT.Repository;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace BAT.Controllers
{
    public class BehaviorEventController : ApiController
    {
        private static BATRepository _db = new BATRepository();

        [HttpGet]
        [Route("api/behaviorevent/{sessionID}")]
        public System.Web.Mvc.JsonResult GetBehaviorEvent(int sessionID)
        {
            var behaviorEvents = _db.GetEventsBySessionID(sessionID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                behaviorEvents
            };
            return json;
        }
        
        [HttpPost]
        [Route("api/behaviorevent/{userID}")]
        public List<BehaviorEvent> PostBehaviorEvents(JObject inputSet)
        {
            List<BehaviorEvent> convertedEvents = new List<BehaviorEvent>();
            dynamic req = inputSet;
            foreach (dynamic input in (JArray)req.inputs)
            {
                convertedEvents.Add(input);
            }
            foreach (BehaviorEvent BE in convertedEvents)
            {
                _db.CreateBehaviorEvent(BE);
            }
            return convertedEvents;
        }

    }
}
