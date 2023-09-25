using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers
{
    public class CourseRegisterationController : Controller
    {
        // GET: CourseRegisteration
        CourseRegisterationManager _courseRegisterationManager= new CourseRegisterationManager(new EfCourseRegisterationDal());
        CourseRegisterValidatior _validationRules = new CourseRegisterValidatior();

        CourseManager _courseManager = new CourseManager(new EfCourseDal());
        public ActionResult Index()
        {
            var registerValue = _courseRegisterationManager.GetListBL();
            return View(registerValue);
        }
        [HttpGet]
        public ActionResult AddCourseRegisteration()
        {
            List<SelectListItem> value = (from item in _courseManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = item.course_name,
                                                       Value = item.course_id.ToString()
                                                   }).ToList();

            ViewBag.vlc = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddCourseRegisteration(CourseRegisteration courseRegisteration)
        {

            ValidationResult result = _validationRules.Validate(courseRegisteration);
            courseRegisteration.status = true;
            if (result.IsValid)
            {
                List<SelectListItem> value = (from item in _courseManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = item.course_name,
                                                  Value = item.course_id.ToString()
                                              }).ToList();

                ViewBag.vlc = value;
                _courseRegisterationManager.CourseRegisterationAddBL(courseRegisteration);
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> value = (from item in _courseManager.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = item.course_name,
                                                  Value = item.course_id.ToString()
                                              }).ToList();

                ViewBag.vlc = value;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
        public ActionResult DeleteCourseRegisteration(int id)
        {
            var registerValue = _courseRegisterationManager.GetByIdBL(id);
            _courseRegisterationManager.CourseRegisterationDeleteBL(registerValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCourseRegisteration(int id)
        {
            var registerValue = _courseRegisterationManager.GetByIdBL(id);

            return View(registerValue);
        }
        [HttpPost]
        public ActionResult EditCourseRegisteration(CourseRegisteration courseRegisteration)
        {
            ValidationResult result = _validationRules.Validate(courseRegisteration);

            if (result.IsValid)
            {
                _courseRegisterationManager.CourseRegisterationUpdateBL(courseRegisteration);
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