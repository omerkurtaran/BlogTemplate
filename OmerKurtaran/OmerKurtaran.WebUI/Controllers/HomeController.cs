using OmerKurtaran.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerKurtaran.WebUI.Controllers
{
    public class HomeController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MakaleListele()
        {//makalelistelewidget view ini shared klasörü içine bastığmız için return view kısmında controller vermeye gerek kalmadı
            var data = db.Makales.ToList();
            return View("MakaleListeleWidget",data);
        }

        public PartialViewResult KategoriWidget()
        {
            return PartialView(db.Kategoris.ToList());
        }

        public PartialViewResult PopulerMakalelerWidget()
        {
            var model = db.Makales.OrderByDescending(z => z.EklenmeTarihi).Take(3).ToList();
            return PartialView(model);
        }
            

    }
}