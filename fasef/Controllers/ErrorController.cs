using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UNBK_Client.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("General");
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult NotPermitted()
        {
            return View();
        }
    }
}