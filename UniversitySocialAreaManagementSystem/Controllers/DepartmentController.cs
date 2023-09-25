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
    public class DepartmentController : Controller
    {
        // GET: Department
        DepartmentManager _departmentManager = new DepartmentManager(new EfDepartmentDal());
        DepartmentValidatior validationRules = new DepartmentValidatior();
        public ActionResult Index()
        {
            var departmentValue= _departmentManager.GetListBL();
            return View(departmentValue);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            
            ValidationResult result = validationRules.Validate(department);
            department.status = true;
            if (result.IsValid)
            {
                _departmentManager.AddDepartmentBL(department);
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
        public ActionResult DeleteDeparment(int id)
        {
            var departmentValue = _departmentManager.GetByIdBL(id);
            _departmentManager.DeleteDepartmentBL(departmentValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditDepartment(int id)
        {
            var departmentValue = _departmentManager.GetByIdBL(id);

            return View(departmentValue);
        }
        [HttpPost]
        public ActionResult EditDepartment(Department department)
        {
            ValidationResult result = validationRules.Validate(department);

            if (result.IsValid)
            {
                _departmentManager.UpdateDepartmentBL(department);
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