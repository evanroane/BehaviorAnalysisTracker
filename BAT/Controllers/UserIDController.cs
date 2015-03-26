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
    public class UserIDController : ApiController
    {
        [Route("api/userid")]
        public string GetUserID()
        {
            string userId = User.Identity.GetUserId();
            return userId;
        }

    }
}
