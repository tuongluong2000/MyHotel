using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAdmin.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    var emp = db.Employees.FirstOrDefault(x => x.Email == email && x.Password == password);
                    if(emp == null)
                    {
                        res.IsSuccess = false;
                    }
                    else
                    {
                        Session.Add("Employee", emp);
                        res.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Add("Employee", null);
            return RedirectToAction("Login");
        }

        public ActionResult Unauthorized()
        {
            return View();
        }
    }
}