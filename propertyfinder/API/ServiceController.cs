using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using propertyfinder.Models;
using propertyfinder.Controllers;

namespace propertyfinder.API
{
    public class ServiceController : ApiController
    {
        // GET: api/Service
        private readonly PropertyFinder db = new PropertyFinder();
        ExtensionMethods em = new ExtensionMethods();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Service/5
        public string Get(int id)
        {
            return "value";
        }
        [ActionName("Property")]
        public IHttpActionResult GetPropertyType()
        {
            List<tPropertyType> proType = db.tPropertyTypes.ToList();
            return Ok(proType);
        }

        // POST: api/Service
        public class ServiceSub
        {
            public string serviceName { get; set; }
            public string serviceProType { get; set; }
            public string serviceAddress { get; set; }
            public float longitude { get; set; }
            public float latitude { get; set; }
        }
        [ActionName("saveService")]
        public void PostService(ServiceSub sub)
        {
            if(ModelState.IsValid)
            {
                tServiceEntity tserv = new tServiceEntity();
                tserv.ServiceEntityId = em.generateCode(5);
                tserv.ServiceEntityName = sub.serviceName;
                tserv.ServiceEntityAddress = sub.serviceAddress;
                tserv.PropertyTypeId = sub.serviceProType;
                tserv.Longitude = sub.longitude;
                tserv.Latitude = sub.latitude;
                tserv.Status = 0;

                db.tServiceEntities.Add(tserv);
                db.SaveChanges();
            }

        }
        [ActionName("services")]
        public IHttpActionResult GetServices()
        {
            List<tServiceEntity> tserList = db.tServiceEntities.ToList();

            return Ok(tserList);
        }

        [ActionName("addProperty")]
        public IHttpActionResult PostNewProperty(string desc, string id)
        {
            if(desc != null)
            {
                tPropertyType tprop = new tPropertyType();
                tprop.Description = desc;
                tprop.PropertyTypeId = em.generateCode(4);
                tprop.CreatedBy = id;
                tprop.Status = "0";
                tprop.DateCreated = DateTime.Now;
                db.tPropertyTypes.Add(tprop);
                db.SaveChanges();
                return Ok(HttpStatusCode.OK);
            }
            return Ok(HttpStatusCode.NoContent);
        }
        [ActionName("getPropertyUpdate")]
        public IHttpActionResult GetPropertyUp(string id)
        {
            var prop = db.tPropertyTypes.SingleOrDefault(p => p.PropertyTypeId == id);

            return Ok(prop);
        }

        public class propertyData
        {
            public string PropertyTypeId { get; set; }
            public string Description { get; set; }
            public string userId { get; set; }
        }

        [ActionName("savePropertyUpdate")]
        public IHttpActionResult PutPropertyUp(propertyData pd)
        {
            var prop = db.tPropertyTypes.SingleOrDefault(p => p.PropertyTypeId == pd.PropertyTypeId);
            prop.Description = pd.Description;
            prop.UpdatedBy = pd.userId;
            prop.DatedUpdated = DateTime.Now;
            db.SaveChanges();
            return Ok(HttpStatusCode.OK);
        }
        [ActionName("remove")]
        public IHttpActionResult DeleteProp(string id)
        {
            if(id != null)
            {
                var prop = db.tPropertyTypes.SingleOrDefault(x => x.PropertyTypeId == id);
                db.tPropertyTypes.Remove(prop);
                db.SaveChanges();
                return Ok(HttpStatusCode.OK);
            }
            return Ok(HttpStatusCode.NoContent);
        }

        // PUT: api/Service/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Service/5
        public void Delete(int id)
        {
        }
    }
}
