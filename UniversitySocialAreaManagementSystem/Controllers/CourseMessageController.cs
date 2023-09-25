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
    public class CourseMessageController : Controller
    {
        // GET: CourseMessage
        CourseMessageManager _messageManager = new CourseMessageManager(new EfCourseMessageDal());
        CourseMessageValidatior _messageValidatior = new CourseMessageValidatior();
        public ActionResult Index()
        {
            var courseValue = _messageManager.GetList();
            return View(courseValue);
        }
        public ActionResult GetMessageID(int id)
        {
            var value = _messageManager.GetById(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCourseMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCourseMessage(CourseMessage courseMessage)
        {
            ValidationResult result = _messageValidatior.Validate(courseMessage);
            if (result.IsValid)
            {
                courseMessage.date= DateTime.Parse( DateTime.Now.ToShortDateString());
                _messageManager.CourseMessageAddBL(courseMessage);
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


        public ActionResult DeleteCourseMessage(int id)
        {
            var messageValue = _messageManager.GetById(id);
            _messageManager.CourseMessageDeleteBL(messageValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCourseMessage(int id)
        {
            var messageValue = _messageManager.GetById(id);

            return View(messageValue);
        }
        [HttpPost]
        public ActionResult EditCourseMessage(CourseMessage courseMessage)
        {
            ValidationResult result = _messageValidatior.Validate(courseMessage);

            if (result.IsValid)
            {
                _messageManager.CourseMessageUpdateBL(courseMessage);
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
        public PartialViewResult MessageList()
        {
            return PartialView();
        }
    }
}