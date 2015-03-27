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
    public class SessionController : ApiController
    {
        private static BATRepository _db = new BATRepository();

        [HttpGet]
        [Route("api/session/{userID}")]
        public System.Web.Mvc.JsonResult GetSessions(string userID)
        {
            var sessions = _db.AllSessions(userID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                sessions
            };
            return json;
        }

        [HttpGet]
        [Route("api/codeset/id/{codeSetID}")]
        public System.Web.Mvc.JsonResult GetBehaviorEventsBySessionID(int ID)
        {
            var inputs = _db.GetInputsByCodeSetID(codeSetID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                inputs
            };
            return json;
        }


        [HttpPost]
        [Route("api/session/{userID}")]
        public HttpResponseMessage Session(string userID, [FromBody] Session S)
        {
            _db.CreateSession(S);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
