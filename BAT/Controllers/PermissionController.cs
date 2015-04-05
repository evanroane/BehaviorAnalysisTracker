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
    public class PermissionController : ApiController
    {
        private static BATRepository _db = new BATRepository();

        [HttpGet]
        [Route("api/permission/codeset/{userID}")]
        public System.Web.Mvc.JsonResult GetCodeSetsSharedWithUser(string userID)
        {
            var sharedCodeSets = _db.GetParticipatingCodeSets(userID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                sharedCodeSets
            };
            return json;
        }

        [HttpGet]
        [Route("api/permission/session/{userID}")]
        public System.Web.Mvc.JsonResult GetSessionsSharedWithUser(string userID)
        {
            var sharedSessions = _db.GetSessionPermissionByUserID(userID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                sharedSessions
            };
            return json;
        }


    }
}
