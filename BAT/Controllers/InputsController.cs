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
    public class InputsController : ApiController
    {
        private static BATRepository _db = new BATRepository();

        [HttpGet]
        [Route("api/inputs/{codeSetID}")]
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
