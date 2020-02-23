using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using propertyfinder.Controllers;
using propertyfinder.Models;

namespace propertyfinder.API
{
    public class RegistrationController : ApiController
    {
        private readonly PropertyFinder db = new PropertyFinder();
        private readonly ExtensionMethods em = new ExtensionMethods();

        // GET: api/Registration
        public IQueryable<tPersonInfo> GettPersonInfoes()
        {
            return db.tPersonInfoes;
        }

        // GET: api/Registration/5
        [ResponseType(typeof(tPersonInfo))]
        public IHttpActionResult GettPersonInfo(int id)
        {
            tPersonInfo tPersonInfo = db.tPersonInfoes.Find(id);
            if (tPersonInfo == null)
            {
                return NotFound();
            }

            return Ok(tPersonInfo);
        }

        // PUT: api/Registration/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttPersonInfo(int id, tPersonInfo tPersonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tPersonInfo.recNo)
            {
                return BadRequest();
            }

            db.Entry(tPersonInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tPersonInfoExists(id))
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



        //Register class
        public class Person {
            public string frontImage { get; set; }
            public string backImage { get; set; }
            public string Firstname { get; set; }
            public string Middlename { get; set; }
            public string Lastname { get; set; }
            public DateTime Birthdate { get; set; }
            public String Address { get; set; }
            public string ContactNo { get; set; }
            public string prodDescription1 { get; set; }
            public string prodDescription2 { get; set; }
            public string userId { get; set; }
        }

        // POST: api/Registration
        //[ResponseType(typeof(tPersonInfo))]
        [HttpPost]
        public IHttpActionResult PosttPersonInfo(Person p)
        {
            tUserValidationId tuv = new tUserValidationId();
            byte[] frontimageBytes = p.frontImage != null ? Convert.FromBase64String(p.frontImage) : null;
            byte[] backimageBytes = p.backImage != null ? Convert.FromBase64String(p.backImage) : null;
            tPersonInfo tp = new tPersonInfo();

            string user = HttpContext.Current.Request.Cookies["uid"].Value;
            
            //personId generate once
            string personId = em.generateCode(4);
            tp.PersonId = personId;
            tp.Firstname = p.Firstname;
            tp.Middlename = p.Middlename;
            tp.Lastname = p.Lastname;
            tp.Birthdate = p.Birthdate;
            tp.ContactNo = p.ContactNo;
            tp.DateCreated = DateTime.Now;
            tp.Status = 0;
            tp.UserId = user;
           
            for (var i = 0; i < 2; i++)
            {
                string validationId = em.generateCode(4);

                if (i == 0)
                {
                    tuv.Image = frontimageBytes;
                    tuv.ImageDescription = p.prodDescription1;
                }
                else
                {
                    tuv.Image = backimageBytes;
                    tuv.ImageDescription = p.prodDescription2;
                }
                tuv.PersonId = personId;
                tuv.ValidationId = validationId;
                tuv.DateCreated = DateTime.Now;
                tuv.Status = i;
                //temporary should be session
                tuv.CreatedBy = "asdasda";
                db.tUserValidationIds.Add(tuv);
                db.SaveChanges();
            }
            db.tPersonInfoes.Add(tp);
            db.SaveChanges();

            return Ok(user);
        }

        // DELETE: api/Registration/5
        [ResponseType(typeof(tPersonInfo))]
        public IHttpActionResult DeletetPersonInfo(int id)
        {
            tPersonInfo tPersonInfo = db.tPersonInfoes.Find(id);
            if (tPersonInfo == null)
            {
                return NotFound();
            }

            db.tPersonInfoes.Remove(tPersonInfo);
            db.SaveChanges();

            return Ok(tPersonInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tPersonInfoExists(int id)
        {
            return db.tPersonInfoes.Count(e => e.recNo == id) > 0;
        }
    }
}