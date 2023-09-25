using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    public class StudentCommunityMessageController : Controller
    {
        CommunityMessageManager _communityMessageManager = new CommunityMessageManager(new EfCommunityMessageDal());
        Context con = new Context();

        // GET: StudentCommunityMessage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InBox()
        {
            string person = (string)Session["student_number"];
            //ViewBag.d=person;
            var studentID = (int)con.Students.Where(x => x.student_number == person).Select(y => y.studentid).FirstOrDefault();
           
            var toplulukBaskanID = (from cr in con.CommunityRegisterations
                                    join c in con.Communities on cr.community_id equals c.community_id
                                    where cr.studentid == studentID // Burada ogrenciID, aradığınız öğrencinin ID'si olmalı
                                    select c.community_president_id).FirstOrDefault();

            var values = _communityMessageManager.GetListInBox(toplulukBaskanID);

            return View(values);


        }
        public ActionResult GetMessageID(int id)
        {
            var value = _communityMessageManager.GetByIdBL(id);
            return View(value);
        }
        public PartialViewResult MessageList()
        {
            return PartialView();
        }
    }

}