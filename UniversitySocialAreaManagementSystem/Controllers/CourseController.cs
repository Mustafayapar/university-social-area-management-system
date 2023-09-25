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
    public class CourseController : Controller
    {
        // GET: Course
        CourseManager _courseManager = new CourseManager(new EfCourseDal());
        CourseValidatior _courseValidatior = new CourseValidatior();
        public ActionResult Index()
        {
            var courseValue = _courseManager.GetList();
            return View(courseValue);
        }
        [HttpGet]
        public ActionResult AddCourse() 
        {
               return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course course) 
        {
            ValidationResult result = _courseValidatior.Validate(course);
            if (result.IsValid) 
            {
                _courseManager.CourseAddBL(course);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }


        public ActionResult DeleteCourse(int id)
        {
            var courseValue = _courseManager.GetByIdBL(id);
            _courseManager.CourseDeleteBL(courseValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var courseValue = _courseManager.GetByIdBL(id);

            return View(courseValue);
        }
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            ValidationResult result = _courseValidatior.Validate(course);

            if (result.IsValid)
            {
                _courseManager.CourseUpdateBL(course);
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