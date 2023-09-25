using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    public class StudentCommunityRegisterationController : Controller
    {
        // GET: CommunityRegisteration
        CommunityRegisterationManager _communityRegisterationManager = new CommunityRegisterationManager(new EfCommunityRegisterationDal());
        CommunityManager _communityManager = new CommunityManager(new EfCommunityDal());
        CommunityRegisterValidatior _registerValidatior = new CommunityRegisterValidatior();
        Context con = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyRegisterCommunity()
        {

            string person = (string)Session["student_number"];

            var studentID = (int)con.Students.Where(x => x.student_number == person).Select(y => y.studentid).FirstOrDefault();
            var values = _communityRegisterationManager.GetListIdBL(studentID);
            return View(values);
        }

        [HttpGet]
        public ActionResult RegisterCommunity()
        {
            List<SelectListItem> value = (from item in _communityManager.GetListBL()
                                                   select new SelectListItem
                                                   {
                                                       Text = item.community_name,
                                                       Value = item.community_id.ToString()
                                                   }).ToList();

            ViewBag.vlc = value;
            return View();
        }
        [HttpPost]
         public ActionResult RegisterCommunity(CommunityRegisteration communityRegisteration)
        {
            ValidationResult result = _registerValidatior.Validate(communityRegisteration);

            string person = (string)Session["student_number"];

            var studentID = (int)con.Students.Where(x => x.student_number == person).Select(y => y.studentid).FirstOrDefault();
            communityRegisteration.studentid = studentID;
            communityRegisteration.status = true;
            
            if (result.IsValid)
            {
                _communityRegisterationManager.CommunityRegisterationAddBL(communityRegisteration);
                return RedirectToAction("MyRegisterCommunity");
            }
            else
            {
                List<SelectListItem> value = (from item in _communityManager.GetListBL()
                                              select new SelectListItem
                                              {
                                                  Text = item.community_name,
                                                  Value = item.community_id.ToString()
                                              }).ToList();
                
                ViewBag.vlc = value;
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}