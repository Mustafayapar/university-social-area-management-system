using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class ManagerController : Controller
    {
        // GET: Manager
       // Context _context;
        ManagerManager _managerManager = new ManagerManager(new EfManagerDal());
        ManagerValidatior _managerValidatior = new ManagerValidatior();

       
        public ActionResult Index()
        {
            return View(_managerManager.GetList());
        }


        [HttpGet]
        public ActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddManager(Manager manager)
        {
            ValidationResult result = _managerValidatior.Validate(manager);

            if (result.IsValid)
            {
                _managerManager.ManagerAddBL(manager);
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

        public ActionResult DeleteManager(int id)
        {
            var managerValue = _managerManager.GetById(id);
            _managerManager.ManagerDeleteBL(managerValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditManager(int id)
        {
            var managerValue = _managerManager.GetById(id);
            return View(managerValue);
        }

        [HttpPost]
        public ActionResult EditManager(Manager manager)
        {
            ValidationResult result = _managerValidatior.Validate(manager);
            if (result.IsValid)
            {
                _managerManager.ManagerUpdateBL(manager);
                return RedirectToAction("Index");   
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();
        }
       
    }
}