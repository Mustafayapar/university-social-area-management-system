using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        // GET: Admin

        StudentManager _studentManager= new StudentManager(new EfStudentDal());
        StudentValidatior studentValidatior = new StudentValidatior();
       DepartmentManager _departmentManager = new DepartmentManager(new EfDepartmentDal());

        
        //[Authorize(Roles ="b")]
        //[Authorize]
        public ActionResult Index()
        {
            var values=_studentManager.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            List<SelectListItem> valueD = (from item in _departmentManager.GetListBL()
                                                   select new SelectListItem
                                                   {
                                                       Text = item.name,
                                                       Value = item.d_id.ToString()
                                                   }).ToList();

            ViewBag.vld = valueD;

            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            ValidationResult result = studentValidatior.Validate(student);
            student.status = true;
            if (result.IsValid)
            {
                _studentManager.StudentAddBL(student);
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> valueD = (from item in _departmentManager.GetListBL()
                                               select new SelectListItem
                                               {
                                                   Text = item.name,
                                                   Value = item.d_id.ToString()
                                               }).ToList();

                ViewBag.vld = valueD;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }

        public ActionResult DeleteStudent(int id)
        {
            var studentvalue = _studentManager.GetById(id);
            studentvalue.status = false;
            _studentManager.StudentDeleteBL(studentvalue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            List<SelectListItem> value = (from item in _departmentManager.GetListBL()
                                                   select new SelectListItem
                                                   {
                                                       Text = item.name,
                                                       Value = item.d_id.ToString()
                                                   }).ToList();

            ViewBag.vlc = value;
            var studentvalue = _studentManager.GetById(id);
            
            return View(studentvalue);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            ValidationResult result = studentValidatior.Validate(student);

            if (result.IsValid)
            {
                _studentManager.StudentUpdateBL(student);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
 
        }

    }
}