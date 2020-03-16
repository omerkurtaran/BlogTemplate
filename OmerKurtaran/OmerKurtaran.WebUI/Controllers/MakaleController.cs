using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerKurtaran.WebUI.Controllers
{
    using Models;
    public class MakaleController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();
        // GET: Makale
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detay(int id)
        {
            var data = db.Makales.FirstOrDefault(z => z.MakaleId == id);
            return View(data);
        }

    }
}