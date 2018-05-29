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
using WebApi.EmailOption;
using System.Data.SqlClient;

namespace WebApi.Controllers
{
    public class StudentController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Student
        public IQueryable<Student> GetStudents()
        {
            return db.Students;
        }

        //var dt = new DataTable();
        //dt.Load(EmailOption.PopDr4("spWebFillRpt", "FillCompanyByUser", _UserID, "", "", "", "01", ""));

        // GET: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(string id)
        {

            //var dt = new DataTable();
            //SqlDataReader dr = dt.Load(emOp.PopDr4("spWebFillRpt", "fillCo",id, "", "", "", "01", ""));
            //dr.DataBind();

            var dt = new DataTable();            
            dt.Load(EmailOption.EmailOption.PopDr4("spWebFillRpt", "fillCo",id, "", "", "", "01", ""));
            

            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {


            if (id != student.StudentID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Student
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {

            db.Students.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.StudentID }, student);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}