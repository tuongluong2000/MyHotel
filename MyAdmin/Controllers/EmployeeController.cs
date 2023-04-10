using Model.Entities;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAdmin.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id = 0)
        {
            using (var db = new MyDBContext())
            {
                Employee employee;
                if (id > 0)
                {
                    employee = db.Employees.FirstOrDefault(x => x.ID == id);
                }
                else
                {
                    employee = new Employee();
                }
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    // Mode Update
                    if (employee.ID > 0)
                    {
                        var employeeInDB = db.Employees.FirstOrDefault(x => x.ID == employee.ID);
                        employeeInDB.Email = employee.Email;
                        employeeInDB.Password = employee.Password;
                        employeeInDB.FullName = employee.FullName;
                        employeeInDB.Roles = employee.Roles;
                    }
                    // Mode Insert
                    else
                    {
                        db.Employees.Add(employee);
                    }

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    res.Data = db.Employees.ToList();
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var res = new ServiceResponse();

            try
            {
                using (var db = new MyDBContext())
                {
                    var employee = db.Employees.FirstOrDefault(x => x.ID == id);

                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    res.Data = 1;
                }
            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}