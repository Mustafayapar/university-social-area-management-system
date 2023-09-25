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
    public class EventController : Controller
    {
        // GET: Event
        EventManager _eventManager = new EventManager(new EfEventDal());
        EventValidatior _eventValidatior = new EventValidatior();   
        public ActionResult Index()
        {   
            var eventValue =_eventManager.GetList();
            return View(eventValue);
        }

        [HttpGet]
        public ActionResult AddEvent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEvent(Events objEvent)
        {
            
            ValidationResult result = _eventValidatior.Validate(objEvent);

            if (result.IsValid)
            {
                objEvent.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _eventManager.EventAddBL(objEvent);
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
        public ActionResult DeleteEvent(int id)
        {
            var eventValue = _eventManager.GetById(id);
            _eventManager.EventDeleteBL(eventValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEvent(int id)
        {
            var eventValue = _eventManager.GetById(id);

            return View(eventValue);
        }

        [HttpPost]
        public ActionResult EditEvent(Events objEvent )
        {
            ValidationResult result = _eventValidatior.Validate(objEvent);

            if (result.IsValid)
            {
                objEvent.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _eventManager.EventUpdateBL(objEvent);
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