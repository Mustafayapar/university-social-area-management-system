using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
{ /// <summary>
/// Geçersiz bir controller bu kullanılmayacaktır.
/// </summary>
    public class UserController : Controller
    {
        // GET: User
        Context _context;
        UserManager _userManager = new UserManager(new EfUserDal());
        UserValidatior validationRules = new UserValidatior();

        public UserController()
        {
            _context = new Context();

        }
        public ActionResult Index()
        {
            return View(_context.Users.ToList());
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {

            ValidationResult result = validationRules.Validate(user);

            if (result.IsValid)
            {
                _userManager.UserAddBL(user);
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
        public ActionResult Delete(int id)
        {
            var userValue = _userManager.GetByIdBL(id);
            _userManager.UserDeleteBL(userValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var userValue = _userManager.GetByIdBL(id);

            return View(userValue);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            ValidationResult result = validationRules.Validate(user);

            if (result.IsValid)
            {
                _userManager.UserUpdateBL(user);
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