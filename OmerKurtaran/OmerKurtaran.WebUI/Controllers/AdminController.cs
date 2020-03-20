using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerKurtaran.WebUI.Controllers
{
    using Models;
    public class AdminController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YazarOnaylari()
        {
            var data = db.Kullanicis.Where(z => z.Yazar == true && z.Onaylandi == false).ToList();

            return View(data);
        }

        public ActionResult OnayVer(int id)
        {
            Kullanici kl = db.Kullanicis.FirstOrDefault(z=>z.KullaniciId == id);
            kl.Onaylandi = true;
            db.SaveChanges();

            return RedirectToAction("YazarOnaylari");

        }

    }
}