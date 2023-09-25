using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers.Student_Controller
{
    public class StudentAnnouncementController : Controller
    {
        AnnouncementManager _announcementManager= new AnnouncementManager(new EfAnnouncementDal());
        // GET: Announcement
        public ActionResult Index(int p=1)
        {

            var value = _announcementManager.GetList().ToPagedList(p,2);
            return View(value);
        }
    }
}