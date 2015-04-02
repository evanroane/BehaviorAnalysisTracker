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
    public class InputsController : ApiController
    {
        private static BATRepository _db = new BATRepository();

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
        
        [HttpPost]
        [Route("api/input/{userID}")]
        public List<Input> PostInputs(JObject inputSet)
        {
            List<Input> convertedEvents = new List<Input>();
            dynamic req = inputSet;
            foreach (dynamic input in (JArray)req.inputs)
            {
                convertedEvents.Add(input);
            }
            foreach (Input I in convertedEvents)
            {
                _db.CreateInput(I);
            }
            return convertedEvents;
        }
    }
}
