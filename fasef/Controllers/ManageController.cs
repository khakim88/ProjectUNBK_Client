using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using UNBK_Client.Common;
using UNBK_Client.Models;

namespace UNBK_Client.Controllers
{
    
    public class ManageController : Controller
    {
    
        unbk_clientEntities db = new unbk_clientEntities();

        
        public ActionResult Reg_key_post(string key)
        {
            reg_info tblreg = new reg_info();
            tblreg.key_code = key;
            tblreg.tanggal = DateTime.Now;
            db.reg_info.Add(tblreg);
            db.SaveChanges();


            return RedirectToAction("Success_Reg");
        }


        public ActionResult Success_Reg()
        {

            var key = db.reg_info.OrderByDescending(o => o.tanggal).Select(s => s.key_code).FirstOrDefault();

            string decrypted = Crypto.Decrypt(key);

            var list = decrypted.Split('#');
            if (list.Count() > 0)
            {
                ViewBag.nama = list[1];
                ViewBag.siswa = list[2];
            }
            else
            {
                ViewBag.Error = "Maaf Key yang anda masukkan tidak terdaftar";
            }

            return View("success_reg");
        }


        public ActionResult Key()
        {

            return View("key");
        }
        public ActionResult CreateJadwal()
        {

            return View("CreateJadwal");
        }


        public ActionResult Login()
        {
            return
                RedirectToAction("Login");
        }
    }
}