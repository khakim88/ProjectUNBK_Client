using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UNBK_Client.Common;
  

namespace UNBK_Client.Controllers
{
    public class ExamController : Controller
    {
        //private unbkEntities db = new unbkEntities();
        private unbk_clientEntities db = new unbk_clientEntities();

        
        public ActionResult Index()

        {
            var reginfo = db.reg_info.ToList();
            if (reginfo.Count > 0)
            {
                return View("Login");
            }
            else
            {
                return RedirectToAction("Key","Manage");                 
            }
        }


        
        
        public ActionResult Login()
        {
            return RedirectToAction("index");
        }


        public void ClearSession()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
        }

        public void Create_Session(user sysuser)
        {
            Session["Nis"] = sysuser.username;
            Session["Fullname"] = sysuser.fullname;
        }


        [HttpPost, ActionName("Login")]
        public ActionResult LoginPost(string nis, string password)
        {
            if (ModelState.IsValid)
            {
                user sysuser = db.users
                    .Where(w => w.username == nis)
                    .FirstOrDefault();

                if(sysuser != null)
                {
                    if(Helpers.MD5Hash(password) == sysuser.password)
                    {
                        Create_Session(sysuser);
                        //return RedirectToAction("Start", "Exam");
                        return RedirectToAction("Token", "Exam");
                    }
                    else
                    {
                        ViewBag.Error = "Kata Sandi yang Anda masukkan salah";
                    }
                }
                else
                {
                    ViewBag.Error = "Nomor Induk Siswa tidak terdaftar";
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            ClearSession();

            return RedirectToAction("Index", "Exam");
        }
        

        public ActionResult Start()
        {

            return View("Exam");
        }

        public ActionResult Token()
        {
            var iduser = Session["Nis"].ToString();
            siswa sysuser = db.siswas.Where(w => w.nik==iduser).FirstOrDefault();

            return View("token");
        }

        public ActionResult TokenPost(jadwal jdwl)
        {
            jadwal jadwal = db.jadwals.Where(w => w.token == jdwl.token).FirstOrDefault();
            if (jadwal != null)
            {

            }
            return View("token");
        }



    }
}