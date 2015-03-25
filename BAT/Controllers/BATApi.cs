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
    public class BATApi : ApiController
    {
        private static BATRepository _db = new BATRepository();
        
        // GET: /api/codeset 
        [Route("api/codeset")]
        public IEnumerable<CodeSet> Get() 
        { 
            string userId = User.Identity.GetUserId(); 
            if (userId != null) 
            {
                return _db.GetCodeSetByUserID(userId); 
            }
            return _db.AllCodeSets();
        } 

    
    }
}
