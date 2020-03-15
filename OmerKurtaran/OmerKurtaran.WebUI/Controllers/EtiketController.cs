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
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult EtiketWidget()
        {
            return PartialView(db.Etikets.ToList());
        }

    }
}