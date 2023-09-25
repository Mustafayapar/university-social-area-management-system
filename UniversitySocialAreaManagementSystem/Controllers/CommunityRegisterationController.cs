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
    public class CommunityRegisterationController : Controller
    {
        CommunityRegisterationManager _communityRegisterationManager = new CommunityRegisterationManager(new EfCommunityRegisterationDal());
        CommunityManager communityManager = new CommunityManager(new EfCommunityDal());
        CommunityRegisterValidatior _registerValidatior = new CommunityRegisterValidatior();
        public ActionResult Index()
        {
            var value = _communityRegisterationManager.GetListBL();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddCommunityRegister()
        {
            List<SelectListItem> valueCommunity = (from item in communityManager.GetListBL()
                                          select new SelectListItem
                                          {
                                              Text = item.community_name,
                                              Value = item.community_id.ToString()
                                          }).ToList();

            ViewBag.vlc = valueCommunity;
            return View();
        }

        [HttpPost]
        public ActionResult AddCommunityRegister(CommunityRegisteration communityRegisteration)
        {
            ValidationResult result = _registerValidatior.Validate(communityRegisteration);
            communityRegisteration.status = true;
            if (result.IsValid)
            {
                _communityRegisterationManager.CommunityRegisterationAddBL(communityRegisteration);
                return RedirectToAction("Index");
            }
            else
            {
                List<SelectListItem> valueCommunity = (from item in communityManager.GetListBL()
                                                      select new SelectListItem
                                                      {
                                                          Text = item.community_name,
                                                          Value = item.community_id.ToString()
                                                      }).ToList();

                ViewBag.vlc = valueCommunity;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCommunityRegister(int id)
        {
            var value = _communityRegisterationManager.GetByIdBL(id);
            _communityRegisterationManager.CommunityRegisterationDeleteBL(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCommunityRegister(int id)
        {
            var value = _communityRegisterationManager.GetByIdBL(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult EditCommunityRegister(CommunityRegisteration communityRegisteration)
        {
            ValidationResult result = _registerValidatior.Validate(communityRegisteration);

            if (result.IsValid)
            {
                _communityRegisterationManager.CommunityRegisterationUpdateBL(communityRegisteration);
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