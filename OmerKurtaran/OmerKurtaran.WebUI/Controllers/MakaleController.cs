using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerKurtaran.WebUI.Controllers
{
    using Models;
    [Authorize] //aşağıdaki her işlem için izin gerekli demektir
    public class MakaleController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();
        // GET: Makale
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Detay(int id)
        {
            var data = db.Makales.FirstOrDefault(z => z.MakaleId == id);
            return View(data);
        }
        [Authorize(Roles = "Admin,Yazar")]
        public ActionResult MakaleEkle()
        {
            return View();
        }

    }
}