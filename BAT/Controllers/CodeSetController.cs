using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAT.Models;
using BAT.Repository;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace BAT.Controllers
{
    [Authorize]
    public class CodeSetController : ApiController
    {
        private static BATRepository _db = new BATRepository();

        [HttpGet]
        [Route("api/codeset/{userID}")]
        public JArray GetCodeSets(string userID)
        {
            List<CodeSet> codeSets = _db.GetCodeSetByUserID(userID);
            string jsonString = JsonConvert.SerializeObject(codeSets, new StringEnumConverter());
            JArray json = JArray.Parse(jsonString);
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
        [Route("api/codeset/post")]
        public HttpResponseMessage Post([FromBody] string json)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            CodeSet codeSet = JsonConvert.DeserializeObject<CodeSet>(json);
            _db.CreateCodeSet(codeSet);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("api/codeset/{id}/put")]
        public HttpResponseMessage UpdateCodeSet([FromBody] string json)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            CodeSet codeSet = JsonConvert.DeserializeObject<CodeSet>(json);
            _db.CreateCodeSet(codeSet);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
