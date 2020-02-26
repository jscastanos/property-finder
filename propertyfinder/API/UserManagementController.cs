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
    public class UserManagementController : ApiController
    {
        // GET: api/UserManagement
        private readonly PropertyFinder db = new PropertyFinder();
        [ActionName("Users")]
        public IHttpActionResult Get()
        {
            var userList = (from a in db.tUsers
                            join b in db.tPersonInfoes on a.UserId equals b.UserId
                            select new
                            {
                                a.UserId,
                                a.AccountTypeId,
                                a.Status,
                                fullName = b.Firstname + " " + b.Middlename + " " + b.Lastname,
                                b.Address,
                                b.Birthdate,
                                b.ContactNo,
                            });
            return Ok(userList);
        }

        // GET: api/UserManagement/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserManagement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserManagement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserManagement/5
        public void Delete(int id)
        {
        }
    }
}
