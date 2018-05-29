using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class setupCompanyAsController : ApiController
    {
        private CRUDDBEntities db = new CRUDDBEntities();

        // GET: api/setupCompanyAs
        public IQueryable<setupCompanyA> GetsetupCompanyAs()
        {
            return db.setupCompanyAs;
            //return db.spWebFillRpt("fillCo","","","","","","","");
        }

        // GET: api/setupCompanyAs/5
        [ResponseType(typeof(setupCompanyA))]
        public IHttpActionResult GetsetupCompanyA(string id)
        {
            setupCompanyA setupCompanyA = db.setupCompanyAs.Find(id);
            if (setupCompanyA == null)
            {
                return NotFound();
            }

            return Ok(setupCompanyA);


        }

        // PUT: api/setupCompanyAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsetupCompanyA(string id, setupCompanyA setupCompanyA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != setupCompanyA.uCompanyID)
            {
                return BadRequest();
            }

            db.Entry(setupCompanyA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!setupCompanyAExists(id))
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

        // POST: api/setupCompanyAs
        [ResponseType(typeof(setupCompanyA))]
        public IHttpActionResult PostsetupCompanyA(setupCompanyA setupCompanyA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.setupCompanyAs.Add(setupCompanyA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (setupCompanyAExists(setupCompanyA.uCompanyID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = setupCompanyA.uCompanyID }, setupCompanyA);
        }

        // DELETE: api/setupCompanyAs/5
        [ResponseType(typeof(setupCompanyA))]
        public IHttpActionResult DeletesetupCompanyA(string id)
        {
            setupCompanyA setupCompanyA = db.setupCompanyAs.Find(id);
            if (setupCompanyA == null)
            {
                return NotFound();
            }

            db.setupCompanyAs.Remove(setupCompanyA);
            db.SaveChanges();

            return Ok(setupCompanyA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool setupCompanyAExists(string id)
        {
            return db.setupCompanyAs.Count(e => e.uCompanyID == id) > 0;
        }
    }
}