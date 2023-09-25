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
    public class EventRegisterationController : Controller
    {
        // GET: EventRegisteration
        EventRegisterationManager _eventRegisterationManager = new EventRegisterationManager(new EfEventRegisterationDal());
        EventRegisterValidatior _eventRegisterationValidatior = new EventRegisterValidatior();

        public ActionResult Index()
        {
            var eventRegisterationValues= _eventRegisterationManager.GetList();
            return View(eventRegisterationValues);
        }

        [HttpGet] 
        public ActionResult AddEventRegisteration()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddEventRegisteration(EventRegisteration eventRegisteration) 
        {
            ValidationResult result =_eventRegisterationValidatior.Validate(eventRegisteration);

            if (result.IsValid) 
            {   

                _eventRegisterationManager.EventRegisterationAddBL(eventRegisteration);
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

        public ActionResult DeleteEventRegisteration(int id)
        {
            var eventRegisteration = _eventRegisterationManager.GetByIdBL(id);
            _eventRegisterationManager.EventRegisterationDeleteBL(eventRegisteration);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEventRegisteration(int id)
        {
            var eventRegisterationValue = _eventRegisterationManager.GetByIdBL(id);

            return View(eventRegisterationValue);
        }

        [HttpPost]
        public ActionResult EditEventRegisteration(EventRegisteration eventRegisteration)
        {
            ValidationResult result = _eventRegisterationValidatior.Validate(eventRegisteration);

            if (result.IsValid)
            {
                _eventRegisterationManager.EventRegisterationUpdateBL(eventRegisteration);
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