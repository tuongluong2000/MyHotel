using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAdmin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var emp = Session["Employee"] as Employee;
            if (emp == null)
                filterContext.Result = new RedirectResult("/Auth/Login");
            else
            {
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                string actionName = filterContext.ActionDescriptor.ActionName;
                List<string> actionView = new List<string>() {
                    "Index",
                    "Create"
                };

                if(actionView.Contains(actionName))
                {
                    if (String.IsNullOrEmpty(emp.Roles) || !emp.Roles.Contains(controllerName))
                    {
                        filterContext.Result = new RedirectResult("/Auth/Unauthorized");
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}