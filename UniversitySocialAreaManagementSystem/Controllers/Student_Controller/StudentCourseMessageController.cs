using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    public class StudentCourseMessageController : Controller
    {
        Context con = new Context();
        CourseMessageManager _courseMessageManager = new CourseMessageManager(new EfCourseMessageDal());
        // GET: StudentCourseMessage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InBox()
        {
            string person = (string)Session["student_number"];
            //ViewBag.d=person;
            var studentPresidentID = (int)con.Students.Where(x => x.student_number == person).Select(y => y.studentid).FirstOrDefault();
            var kursBaskanID = (from cr in con.CourseRegisterations
                                join c in con.Courses on cr.course_id equals c.course_id
                                where cr.studentid == studentPresidentID // Burada ogrenciID, aradığınız öğrencinin ID'si olmalı
                                select c.president_id).FirstOrDefault();

            var values = _courseMessageManager.GetListInBox(kursBaskanID);

            return View(values);


        }
        public ActionResult GetMessageID(int id)
        {
            var value = _courseMessageManager.GetById(id);
            return View(value);
        }
        public PartialViewResult MessageList()
        {
            return PartialView();
        }
    }
}