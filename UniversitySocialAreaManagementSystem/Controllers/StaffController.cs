using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversitySocialAreaManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        StaffManager _staffManager = new StaffManager(new EfStaffDal());
        StaffValidatior validationRules = new StaffValidatior();
        public ActionResult Index()
        {
            return View(_staffManager.GetListBL());
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff staff)
        {

            ValidationResult result = validationRules.Validate(staff);

            if (result.IsValid)
            {
                _staffManager.StaffAddBL(staff);
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
      
        public ActionResult DeleteStaff(int id)
        {
            var staffValue = _staffManager.GetByIdBl(id);
            _staffManager.StaffDeleteBL(staffValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditStaff(int id)
        {
            var staffValue = _staffManager.GetByIdBl(id);
            return View(staffValue);
        }
        [HttpPost]
        public ActionResult EditStaff(Staff staff)
        {
            ValidationResult result = validationRules.Validate(staff);
            
            if (result.IsValid)
            {
                _staffManager.StaffUpdateBL(staff);
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