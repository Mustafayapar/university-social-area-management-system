using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    public class StudentCourseRegisterationController : Controller
    {
        // GET: CourseRegistertion
        CourseRegisterationManager _courseRegisterationManager = new CourseRegisterationManager(new EfCourseRegisterationDal());
        CourseManager _courseManager = new CourseManager(new EfCourseDal());
        CourseRegisterValidatior _registerValidatior = new CourseRegisterValidatior();
        Context con = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyRegisterCourse()
        {
            string person = (string)Session["student_number"];

            var studentID = (int)con.Students.Where(x => x.student_number == person).Select(y => y.studentid).FirstOrDefault();
            var values = _courseRegisterationManager.GetListIDBL(studentID);
            return View(values);
        }

        [HttpGet]
        public ActionResult RegisterCourse()
        {
            List<SelectListItem> value = (from item in _courseManager.GetList()
                                          select new SelectListItem
                                          {
                                              Text = item.course_name,
                                              Value = item.course_id.ToString()
                                          }).ToList();

            ViewBag.vlco = value;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCourse(CourseRegisteration courseRegisteration)
        {
            ValidationResult result = _registerValidatior.Validate(courseRegisteration);
            string person = (string)Session["student_number"];

            var studentID = (int)con.Students.Where(x => x.student_number == person).Select(y => y.studentid).FirstOrDefault();
            courseRegisteration.studentid = studentID;

            courseRegisteration.status = true;

            if (result.IsValid)
            {
                _courseRegisterationManager.CourseRegisterationAddBL(courseRegisteration);
                return RedirectToAction("MyRegisterCourse");
            }
            else
            {
                List<SelectListItem> value = (from item in _courseManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = item.course_name,
                                                  Value = item.course_id.ToString()
                                              }).ToList();

                ViewBag.vlco = value;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}