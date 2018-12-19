using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UNBK_Client.Common
{
    public class ControlAuth
    {
        static string[] exceptions =
            {
                "Exam/Login"
                ,"Exam/Index"
                ,"Exam/Logout"
                ,"Error/Index"
                ,"Error/NotFound"
                ,"Error/NotPermitted"
            };

        public static void CheckControl(string areaName, string controllerName, string actionName, ActionExecutingContext filterContext)
        {
            string pageName = areaName != "" ? areaName + controllerName + "/" + actionName : controllerName + "/" + actionName;

            if (!exceptions.Contains(pageName))
            {
                //var controls = getUsedForm(areaName, controllerName);

                //var control = controls != null ? getAllowedControl(controls, actionName) : null;

                //if (control == null || control.Count() < 1)
                //{
                //    filterContext.HttpContext.Response.Redirect("~/Home/NotPermitted", true);
                //}
            }
        }

        public static void CheckSession(string pageName, ActionExecutingContext filterContext)
        {
            if (!exceptions.Contains(pageName) || pageName == "Home/Index")
            {
                HttpSessionStateBase session = filterContext.HttpContext.Session;
                var user = session["Nis"];

                if (((user == null) && (!session.IsNewSession)) || (session.IsNewSession))
                {
                    //send them off to the login page
                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("~/Exam/Logout");

                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
            }
        }
    }
}