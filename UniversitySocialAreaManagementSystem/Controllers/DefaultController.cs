using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        CommunityManager _communityManager = new CommunityManager(new EfCommunityDal());
        CourseManager _courseManager = new CourseManager(new EfCourseDal());
        EventManager _eventManager = new EventManager(new EfEventDal());
        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Communities()
        {
            var communityList = _communityManager.GetListBL();
            return View(communityList);
        }
        public ActionResult Events()
        {
            var eventList = _eventManager.GetList();
            return View(eventList);
            
        }
        public ActionResult Courses()
        {
            var courseList = _courseManager.GetList();
            return View(courseList);
            
        }
        public ActionResult Announcement()
        {
            var announList = _announcementManager.GetList();
            return View(announList);

        }
    }
}