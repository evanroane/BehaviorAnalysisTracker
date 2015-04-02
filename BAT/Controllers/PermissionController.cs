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
        [Route("api/permission/codeset/{codeSetID}")]
        public System.Web.Mvc.JsonResult GetInputs(int codeSetID)
        {
            var codeSetPermissions = _db.GetParticipatingCodeSets(string userID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                codeSetPermissions
            };
            return json;
        }

        [HttpGet]
        [Route("api/input/{codeSetID}")]
        public System.Web.Mvc.JsonResult GetInputs(int codeSetID)
        {
            var inputs = _db.GetInputsByCodeSetID(codeSetID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                inputs
            };
            return json;
        }

    }
}
