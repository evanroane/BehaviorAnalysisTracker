using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAT.Models;
using BAT.Repository;
using Microsoft.AspNet.Identity;

namespace BAT.Controllers
{
    public class BehaviorEventController : ApiController
    {
        private static BATRepository _db = new BATRepository();

        [HttpGet]
        [Route("api/behaviorevent/{sessionID}")]
        public System.Web.Mvc.JsonResult GetSessions(int sessionID)
        {
            var behaviorEvents = _db.GetEventsBySessionID(sessionID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                behaviorEvents
            };
            return json;
        }
    }
}
