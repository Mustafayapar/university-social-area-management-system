using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    public class StudentCourseController : Controller
    {
        CourseManager _courseManager = new CourseManager(new EfCourseDal());
        CourseValidatior _courseValidatior = new CourseValidatior();
        // GET: Course
        public ActionResult Index()
        {
            var courseList = _courseManager.GetList();
            return View(courseList);
        }
        public ActionResult MyOwnCourse(string person)
        {
            Context con = new Context();
            person = (string)Session["student_number"];
            //ViewBag.d=person;
            var studentPresidentID = con.Students.Where(x => x.student_number == person).Select(y => y.president_id).FirstOrDefault();
           
            if (studentPresidentID != null)
            {
                int i = (int)studentPresidentID;
                var values = _courseManager.GetByIdBL(i);

                return View(values);
            }
            else
            {
                return RedirectToAction("Index");

            }




        }
        public ActionResult InboxMessage()
        {
            return View();
        }
    }

}