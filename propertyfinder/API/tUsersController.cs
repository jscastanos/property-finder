using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using propertyfinder.Controllers;
using propertyfinder.Models;

namespace propertyfinder.API
{

    [RoutePrefix("api/tusers")]
    public class tUsersController : ApiController
    {
        private readonly PropertyFinder db = new PropertyFinder();
        readonly ExtensionMethods em = new ExtensionMethods();

        public string genCode(int count)
        {
            var code = Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, count).ToUpper();
            return code;
        }




        // POST: api/tUsers
        [Route("createaccount")]
        public IHttpActionResult CreateAccount(tUser tUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            tUser.UserId = genCode(5);
            tUser.DateCreated = DateTime.Now;
            tUser.Status = 0;
            db.tUsers.Add(tUser);
            db.SaveChanges();
            HttpCookie userIdCookie = new HttpCookie("uid");
            userIdCookie.Value = tUser.UserId;
            HttpContext.Current.Response.Cookies.Add(userIdCookie);
            //HttpContext.Current.Response.Redirect("../Account/Login");

            return Ok(tUser.UserId);
        }



        // POST: api/tUsers/PostLogIn
        [Route("login")]
        public IHttpActionResult LogIn(tUser tUser)
        {
            var t = db.tUsers.Where(x => x.Username == tUser.Username && x.Password == tUser.Password).FirstOrDefault();

            if (t == null)
            {
                t = null;
                return Ok(t);
            }

     
            return Ok(t.Status);


        }



        // POST: api/tUsers/PostLogIn
        [Route("validateusername/{uname}")]
        public IHttpActionResult ValidateUsername(string uname)
        {
            var t = db.tUsers.Where(x => x.Username == uname).FirstOrDefault();

            if (t == null)
            {
                return Ok(0);
            }

            return Ok(1);


        }












        // GET: api/tUsers/getuseraccounts
        [Route("getuseraccounts")]
        public IHttpActionResult GetUserAccounts()
        {
            var s = db.tUsers.Where(a => a.AccountTypeId == 1 && a.Status == 0).Select(x => x.UserId);
            var b = db.tUsers.Where(a => a.AccountTypeId == 2 && a.Status == 0).Select(x => x.UserId);

            var obj = new object();
            var sellers = new object();
            var buyers = new object();

            if (s == null)
            {
                sellers = null;
            }
            else
            {
                sellers = db.tPersonInfoes.Where(x => s.Contains(x.UserId)).
                Select(y => new
                {

                    y.UserId,
                    y.PersonId,
                    y.ProfileImg,
                    y.Address,
                    fullname = y.Lastname + ", " + y.Firstname + " " + (y.Middlename != null ? y.Middlename.Substring(0, 1) + "." : "")
                }).ToList();
            }

            if (b == null)
            {
                buyers = null;
            }
            else
            {
                buyers = db.tPersonInfoes.Where(x => b.Contains(x.UserId)).
                Select(y => new
                {
                    y.UserId,
                    y.PersonId,
                    y.ProfileImg,
                    y.Address,
                    fullname = y.Lastname + ", " + y.Firstname + " " + (y.Middlename != null ? y.Middlename.Substring(0, 1) + "." : "")
                }).ToList();
            }



            obj = new
            {
                sellers,
                buyers

            };


            return Ok(obj);
        }


        // GET: api/tUsers/getuseraccounts
        [Route("GetUserVerifiedAccounts")]
        public IHttpActionResult GetUserVerifiedAccounts()
        {




            var sellers = db.vUserAcctStatus.Where(x => x.AccountTypeId == 1).
                  Select(y => new
                  {

                      y.UserId,
                      y.Address,
                      y.PersonId,
                      vfullname = y.Lastname + ", " + y.Firstname + " " + (y.Middlename != null ? y.Middlename.Substring(0, 1) + "." : ""),
                      y.ProfileImg,
                      y.Status
                  }).ToList();

            if (sellers == null)
            {
                sellers = null;
            }

            var buyers = db.vUserAcctStatus.Where(x => x.AccountTypeId == 2).
                  Select(y => new
                  {

                      y.UserId,
                      y.Address,
                      y.PersonId,
                      vfullname = y.Lastname + ", " + y.Firstname + " " + (y.Middlename != null ? y.Middlename.Substring(0, 1) + "." : ""),
                      y.ProfileImg,
                      y.Status
                  }).ToList();

            if (buyers == null)
            {
                buyers = null;
            }

            var obj = new
            {
                sellers,
                buyers
            };


            return Ok(obj);
        }



        // GET: api/tUsers/getuseraccounts
        [Route("ActivateDeactivateAccount/{type}/{UsersId}")]
        public IHttpActionResult ActivateDeactivateAccount(int type, string UsersId)
        {

            var user = db.tUsers.SingleOrDefault(x => x.UserId == UsersId);

            if (type == 0)
            {
                user.DateUpdated = DateTime.Now;
                user.Status = 2;
            }

            else if (type == 1)
            {
                user.DateUpdated = DateTime.Now;
                user.Status = 1;
            }

            db.SaveChanges();

            return Ok(user);
        }


















































        // GET: api/tUsers
        public IQueryable<tUser> GettUsers()
        {
            return db.tUsers;
        }

        // GET: api/tUsers/5
        [ResponseType(typeof(tUser))]
        public IHttpActionResult GettUser(int id)
        {
            tUser tUser = db.tUsers.Find(id);
            if (tUser == null)
            {
                return NotFound();
            }

            return Ok(tUser);
        }

        // PUT: api/tUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttUser(int id, tUser tUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tUser.recNo)
            {
                return BadRequest();
            }

            db.Entry(tUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/tUsers
        [ResponseType(typeof(tUser))]
        public IHttpActionResult PosttUser(tUser tUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tUsers.Add(tUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tUser.recNo }, tUser);
        }

        // DELETE: api/tUsers/5
        [ResponseType(typeof(tUser))]
        public IHttpActionResult DeletetUser(int id)
        {
            tUser tUser = db.tUsers.Find(id);
            if (tUser == null)
            {
                return NotFound();
            }

            db.tUsers.Remove(tUser);
            db.SaveChanges();

            return Ok(tUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tUserExists(int id)
        {
            return db.tUsers.Count(e => e.recNo == id) > 0;
        }
    }
}