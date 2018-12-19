using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UNBK_Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalFilters.Filters.Add(new UNBK_Client.Common.ControllerBase());
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                Response.Redirect("~/Error/NotFound", true);

                //var rd = new RouteData();
                //rd.DataTokens["area"] = "AreaName"; // In case controller is in another area
                //rd.Values["controller"] = "Errors";
                //rd.Values["action"] = "NotFound";

                //IController c = new HomeController();
                //c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
            }
        }

        public void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            ex = ex.GetBaseException();

            //error log
            string id = "#" + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("HHmmss");
            Error_Log(ex, id);

            //display error to user
            Context.Items["ID"] = id;
            //Server.Transfer("~/ErrorPage.aspx", true);
        }

        void Error_Log(Exception ex, string id)
        {
            string errorTime = DateTime.Now.ToString("yyyyMMdd");
            string errorDir = Server.MapPath("~/ErrorLog/");
            string errorFileName = "\\ErrorLog.txt";

            string message = id + " \r\nError at: " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss") +
                "\r\nError in: " + Request.Url.ToString() +
                "\r\nError Message: " + ex.Message.ToString() +
                "\r\nStack Trace: \r\n" + ex.StackTrace.ToString();

            if (!System.IO.Directory.Exists(errorDir))
                System.IO.Directory.CreateDirectory(errorDir);

            FileStream fs = new FileStream(errorDir + errorFileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.WriteLine(message + "\r\n");

            m_streamWriter.Flush();
            m_streamWriter.Close();
        }
    }
}
