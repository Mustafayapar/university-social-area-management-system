using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UniversitySocialAreaManagementSystem.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        ManagerManager _adminManager = new ManagerManager(new EfManagerDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Manager manager)
        {
            Context c = new Context();
            var managerinfo = c.Managers.FirstOrDefault(x => x.user_name == manager.user_name && x.password==manager.password );
            if (managerinfo != null)
            {
                FormsAuthentication.SetAuthCookie(managerinfo.user_name,false);
                Session["user_name"] = managerinfo.user_name;
                return RedirectToAction("Index","Student");
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Default");
        }
    }
}