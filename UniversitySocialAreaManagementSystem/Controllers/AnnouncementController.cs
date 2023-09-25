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
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        AnnouncementValidatior _announcementValidatior = new AnnouncementValidatior();
        public ActionResult Index()
        {
            var value = _announcementManager.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAnnouncement(Announcement announcement)
        {
            ValidationResult result = _announcementValidatior.Validate(announcement);
            if (result.IsValid)
            {
                announcement.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _announcementManager.AnnouncementAddBL(announcement);
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


        public ActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementManager.GetByIdBL(id);
            _announcementManager.AnnouncementDeleteBL(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAnnouncement(int id)
        {
            var value = _announcementManager.GetByIdBL(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditAnnouncement(Announcement announcement)
        {
            ValidationResult result = _announcementValidatior.Validate(announcement);

            if (result.IsValid)
            {
                announcement.date = DateTime.Parse(DateTime.Now.ToShortDateString());
                _announcementManager.AnnouncementUpdateBL(announcement);
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