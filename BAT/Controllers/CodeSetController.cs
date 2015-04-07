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
    public class CodeSetController : ApiController
    {
        private static BATRepository _db = new BATRepository();
        
        [HttpGet]
        [Route("api/codeset/{userID}")]
        public System.Web.Mvc.JsonResult GetCodeSets(string userID)
        {
            var codeSets = _db.GetCodeSetByUserID(userID);
            var json = new System.Web.Mvc.JsonResult();
            json.Data = new
            {
                codeSets
            };
            return json;
        }

        [HttpGet]
        [Route("api/codeset/id/{codeSetID}")]
        public System.Web.Mvc.JsonResult GetInputsSetByCodeSetID(int codeSetID)
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
        [Route("api/codeset/{userID}")]
        public HttpResponseMessage CodeSet(CodeSet CS)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _db.CreateCodeSet(CS);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
