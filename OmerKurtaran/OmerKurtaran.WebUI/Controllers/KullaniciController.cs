using OmerKurtaran.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OmerKurtaran.WebUI.Controllers
{
    public class KullaniciController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();
        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Kullanici kullanici)
        {
            string ka = ValidateUser(kullanici.KullaniciAdi, kullanici.Parola);
            if (!string.IsNullOrEmpty(ka))
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, kullanici.KullaniciAdi,
                    DateTime.Now, DateTime.Now.AddMinutes(15), true, ka, FormsAuthentication.FormsCookiePath);

                HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);


                if (ticket.IsPersistent)
                {
                    ck.Expires = ticket.Expiration;
                }
                Response.Cookies.Add(ck);

                FormsAuthentication.RedirectFromLoginPage(kullanici.KullaniciAdi, true);

            }
            //ındex home a al
            return RedirectToAction("Index","Home");

        }

        string ValidateUser(string ka, string pwd)
        {
            Kullanici kl = db.Kullanicis.FirstOrDefault(z => z.KullaniciAdi == ka && z.Parola == pwd);

            if (kl != null)
            {
                return kl.KullaniciAdi;
            }
            else
            {
                return "";
            }

        }
        //redirecturl ile kullanıcının çıkış yaparken bulunduğu sayfanın url ni almak için yaptım
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        public ActionResult UyeOL()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOL(Kullanici kl)
        {
            kl.Yazar = false;
            kl.Onaylandi = true;
            kl.Aktif = true;
            db.Kullanicis.Add(kl);
            db.SaveChanges();
            return RedirectToAction("GirisYap");
        }



    }
}