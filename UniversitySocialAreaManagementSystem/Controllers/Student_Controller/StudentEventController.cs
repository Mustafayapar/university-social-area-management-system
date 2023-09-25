using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    public class StudentEventController : Controller
    {
        // GET: Event
        Context con = new Context();
        EventManager _eventManager = new EventManager(new EfEventDal());
        EventRegisterationManager _eventRegisterationManager = new EventRegisterationManager(new EfEventRegisterationDal());
        public ActionResult Index()
        {
            var eventValue = _eventManager.GetList();
            return View(eventValue);
        }
        public ActionResult MyRegisterEvent()
        {
            string person = (string)Session["student_number"];

            var studentID = (int)con.Students.Where(x => x.student_number == person).Select(y => y.studentid).FirstOrDefault();
            var values = _eventRegisterationManager.GetListByID(studentID);
            return View(values);
        }
    }
}