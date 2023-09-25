using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers
{
    public class StudentCommunityController : Controller
    {
        // GET: StudentPanel
        CommunityManager _communityManager = new CommunityManager(new EfCommunityDal());
        CommunityValidatior _communityValidatior = new CommunityValidatior();
        Context con = new Context();

        public ActionResult Index()
        {
            var value = _communityManager.GetListBL();
            return View(value);

        }
        public ActionResult MyProfile()
        {
            return View();
        }
        public ActionResult MyOwnCommunity(string person)
        {

            person = (string)Session["student_number"];
            //ViewBag.d=person;
            var studentPresidentID = con.Students.Where(x => x.student_number == person).Select(y => y.community_president_id).FirstOrDefault();

            if (studentPresidentID != null)
            {
                int i = (int)studentPresidentID;
                var values = _communityManager.GetByIdBL(i);

                return View(values);
            }
            else
            {
                return RedirectToAction("Index");

            }
           


        }


    }
}