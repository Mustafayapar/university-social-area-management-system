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
    public class CommunityMessageController : Controller
    {

        CommunityMessageManager _communityMessageManager = new CommunityMessageManager(new EfCommunityMessageDal());
        CommunityMessageValidatior _messageValidatior = new CommunityMessageValidatior();
        EventManager _eventManager = new EventManager(new EfEventDal());   
        public ActionResult Index()
        {
            var value = _communityMessageManager.GetListBL();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCommunityMessage()
        {
            List<SelectListItem> value = (from item in _eventManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = item.event_name,
                                                       Value = item.eid.ToString()
                                                   }).ToList();

            ViewBag.vle = value;
            return View();
        }

        [HttpPost]
        public ActionResult AddCommunityMessage(CommunityMessage communityMessage)
        {
            ValidationResult result = _messageValidatior.Validate(communityMessage);

            if (result.IsValid)
            {
                communityMessage.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _communityMessageManager.CommunityMessageAddBL(communityMessage);
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

        public ActionResult DeleteCommunityMessage(int id)
        {
            var value = _communityMessageManager.GetByIdBL(id);
            _communityMessageManager.CommunityMessageDeleteBL(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCommunityMessage(int id)
        {
            var value = _communityMessageManager.GetByIdBL(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditCommunityMessage(CommunityMessage communityMessage)
        {
            ValidationResult result = _messageValidatior.Validate(communityMessage);

            if (result.IsValid)
            {
                communityMessage.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _communityMessageManager.CommunityMessageUpdateBL(communityMessage);
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