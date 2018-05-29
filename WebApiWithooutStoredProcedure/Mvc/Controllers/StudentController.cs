using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<mvcStudentModel> stdlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Student").Result;
            stdlist = response.Content.ReadAsAsync<IEnumerable<mvcStudentModel>>().Result;
            return View(stdlist);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            {
                return View(new mvcStudentModel());
            }
           else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Student/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcStudentModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcStudentModel std)
        {
            if (std.StudentID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Student", std).Result;
                TempData["SuccessMessage"] = "Save Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Student/"+std.StudentID, std).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Student/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}