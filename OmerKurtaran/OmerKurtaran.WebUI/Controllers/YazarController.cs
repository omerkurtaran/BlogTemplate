using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerKurtaran.WebUI.Controllers
{
    using Models;
    public class YazarController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();

        // GET: Yazar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult YazarOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarOl(Kullanici kl)
        {
            kl.Yazar = true;
            kl.Onaylandi = false;
            kl.Aktif = true;
            db.Kullanicis.Add(kl);
            db.SaveChanges();

            Rol yazar = db.Rols.FirstOrDefault(x=>x.RolAdi == "Yazar");

            //Kullanici kr = new Kullanici();
            //kr.Rol = yazar.RolId;
            //kr.KullaniciId = kl.KullaniciId;

            return View();
        }

    }
}