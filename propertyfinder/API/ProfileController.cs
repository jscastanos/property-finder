using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using propertyfinder.Controllers;
using propertyfinder.Models;

namespace propertyfinder.API
{
    [SessionTimeout]
    public class ProfileController : ApiController
    {
        // GET: api/Profile
        private readonly PropertyFinder db = new PropertyFinder();
        public IHttpActionResult Get(string uid)
        {
            var personInfo = db.tPersonInfoes.SingleOrDefault(x => x.UserId == uid);
            var user = db.tUsers.SingleOrDefault(u => u.UserId == uid);
            var frontImage = db.tUserValidationIds.Where(p => p.PersonId == personInfo.PersonId).ToArray()[0];
            var backImage = db.tUserValidationIds.Where(p => p.PersonId == personInfo.PersonId).ToArray()[1];
            return Ok(new { personInfo = personInfo, user = user });
        }

        // GET: api/Profile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Profile
        public void Post(string user)
        {
            if(user != null)
            {
                var verify = db.tUsers.SingleOrDefault(v => v.UserId == user);
                verify.Status = 1;
                db.SaveChanges();
            }
        }

        // PUT: api/Profile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Profile/5
        public void Delete(int id)
        {
        }
    }
}
