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
    public class CommunityController : Controller
    {
        CommunityManager _communityManager = new CommunityManager(new EfCommunityDal());
        CommunityValidatior _communityValidatior = new CommunityValidatior();

        public ActionResult Index()
        { 
            var value = _communityManager.GetListBL();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCommunity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCommunity(Community community)
        {
            ValidationResult result = _communityValidatior.Validate(community);

            if (result.IsValid)
            {
                _communityManager.CommunityAddBL(community);
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

        public ActionResult DeleteCommunity(int id)
        {
            var value = _communityManager.GetByIdBL(id);
            _communityManager.CommunityDeleteBL(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCommunity(int id)
        {
            var value = _communityManager.GetByIdBL(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditCommunity(Community community)
        {
            ValidationResult result = _communityValidatior.Validate(community);

            if (result.IsValid)
            {
                _communityManager.CommunityUpdateBL(community);
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