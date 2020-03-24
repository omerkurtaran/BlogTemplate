using OmerKurtaran.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerKurtaran.WebUI.Controllers
{
    public class KategoriController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();
        // GET: Kategori
        public ActionResult Index(int id)
        {
            return View(id);
        }

        public ActionResult MakaleListele(int id)
        {
            var data = db.Makales.Where(x => x.KategoriID == id).ToList();
            return View("MakaleListeleWidget",data);
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

    }
}