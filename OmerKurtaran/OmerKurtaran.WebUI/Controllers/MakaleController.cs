using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmerKurtaran.WebUI.Controllers
{
    using Models;
    using OmerKurtaran.WebUI.App_Classes;
    using System.Drawing;

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
        [Authorize(Roles = "Admin")]
        public ActionResult MakaleEkle()
        {
            return View();
        }

        [AllowAnonymous]
        public string Begen(int id)
        {
            Makale mkl = db.Makales.FirstOrDefault(z=>z.MakaleId == id);
            mkl.Begeni++;
            db.SaveChanges();
            return mkl.Begeni.ToString();
        }

        [Authorize(Roles ="Admin,Yazar")]
        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = db.Kategoris.ToList();
            return View();
        }

        [Authorize(Roles = "Admin,Yazar")]
        [HttpPost]
        public ActionResult Ekle(Makale mkl, HttpPostedFileBase resim)
        {
            Image img = Image.FromStream(resim.InputStream);

            Bitmap kckResim = new Bitmap(img,Settings.ResimKucukBoyut);
            Bitmap ortaResim = new Bitmap(img, Settings.ResimOrtaBoyut);
            Bitmap bykResim = new Bitmap(img, Settings.ResimBuyukBoyut);

            kckResim.Save(Server.MapPath("/Content/MakaleResim/KucukBoyut/"+resim.FileName));
            ortaResim.Save(Server.MapPath("/Content/MakaleResim/OrtaBoyut/" + resim.FileName));
            bykResim.Save(Server.MapPath("/Content/MakaleResim/BuyukBoyut/" + resim.FileName));

            Resim rsm = new Resim();
            rsm.BuyukBoyut = "/Content/MakaleResim/BuyukBoyut/" + resim.FileName;
            rsm.OrtaBoyut = "/Content/MakaleResim/OrtaBoyut/" + resim.FileName;
            rsm.KucukBoyut = "/Content/MakaleResim/KucukBoyut/" + resim.FileName;

            db.Resims.Add(rsm);
            db.SaveChanges();

            mkl.ResimID = rsm.Resimıd;
            mkl.GoruntulenmeSayisi = 0;
            mkl.Begeni = 0;
            int kullaniciID = db.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name).KullaniciId;
            mkl.KullaniciID = kullaniciID;

            db.Makales.Add(mkl);
            db.SaveChanges();

            return RedirectToAction("Index","Home");
        }


    }
}