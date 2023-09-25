using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    [AllowAnonymous]
    public class StudentLoginController : Controller
    {
        // GET: StudentLogin
        StudentLoginManager _studentLoginManager = new StudentLoginManager(new EfStudentDal());
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Student student)
        {
           // Context c = new Context();
            //var studentinfo = c.Students.FirstOrDefault(x => x.student_number == student.student_number && x.password == student.password);
            var studentinfo = _studentLoginManager.GetStudent(student.student_number,student.password);
            if (studentinfo != null)
            {
                FormsAuthentication.SetAuthCookie(studentinfo.student_number, false);
                Session["student_number"] = studentinfo.student_number;
                return RedirectToAction("Index", "StudentCommunity");
            }
            else
            {

                return RedirectToAction("Login");
            }
             
         //   return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }

}