using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UNBK_Client.Common
{
    public class ControllerBase : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var routeData = filterContext.HttpContext.Request.RequestContext.RouteData;

            string controller = routeData.Values["controller"].ToString();
            string area = routeData.DataTokens.ContainsKey("area") ? routeData.DataTokens["area"].ToString() + "/" : "";
            string action = routeData.Values["action"].ToString();
            string pageName = area + controller + "/" + action;

            // Check Session
            ControlAuth.CheckSession(pageName, filterContext);

            // Check User Privilege
            ControlAuth.CheckControl(area, controller, action, filterContext);
        }
    }
}