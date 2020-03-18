using OmerKurtaran.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OmerKurtaran.WebUI.Controllers
{
    public class EtiketController : Controller
    {
        OmerKurtaranEntities db = new OmerKurtaranEntities();
        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }


        public PartialViewResult EtiketWidget()
        {
            return PartialView(db.Etikets.ToList());
        }

        public ActionResult MakaleListele(int id)
        {
            var data = db.Makales.Where(z => z.Etikets.Any(y => y.EtiketId == id)).ToList();
            return PartialView("MakaleListeleWidget",data);
        }
         
    }
}