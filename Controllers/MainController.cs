using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MAGAZA.Models;

namespace MAGAZA.Controllers
{
    public class MainController : Controller
    {
        Magaza mgz = new Magaza();
        datacontext dtx = new datacontext();
        // GET: Main
        public ActionResult Index()
        {
            List<Magaza> magaz = dtx.MagazamTablom.ToList();
            return View(magaz);
        }
       
        [HttpPost]
        public ActionResult Ekle(string urunturu, string urunad, string urunaciklama, int fiyat,HttpPostedFileBase urungorsel)
        {
            var dosyaisim = Path.GetFileName(urungorsel.FileName);
            var yol = Path.Combine(Server.MapPath("/img"), dosyaisim);
            urungorsel.SaveAs(yol);
            mgz.urunturu = urunturu;
            mgz.urunad = urunad;
            mgz.urunaciklama = urunaciklama;
            mgz.fiyat = fiyat;
            mgz.urungorsel = "/img/" + dosyaisim;
            dtx.MagazamTablom.Add(mgz);
            dtx.SaveChanges();
            return Redirect("Index");
        }
        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Eklesayfasi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sil(int id)
        {
            var sil = dtx.MagazamTablom.Where(x => x.Id == id).ToList();
            dtx.MagazamTablom.Remove(sil[0]);
            dtx.SaveChanges();
            return View("Eklesayfasi");
        }
        public ActionResult sil()
        {
            
            return View();
        }
        public ActionResult guncelle(int id)
        {
            List<Magaza> ara = dtx.MagazamTablom.Where(a => a.Id == id).ToList();
            return View("urunguncelle", ara);
        }
        public ActionResult urunguncelle(int Id, string urunturu, string urunad, string urunaciklama, int fiyat, HttpPostedFileBase urungorsel)
        {
            var dosyaisim = Path.GetFileName(urungorsel.FileName);
            var yol = Path.Combine(Server.MapPath("/img"), dosyaisim);

            var gunceldeger = dtx.MagazamTablom.Find(Id);
            gunceldeger.urunturu = urunturu;
            gunceldeger.urunad = urunad;
            gunceldeger.urunaciklama = urunaciklama;
            gunceldeger.fiyat = fiyat;
            gunceldeger.urungorsel = "/img/" + dosyaisim;
            dtx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult turegore(string isim)
        {
            List<Magaza> magazm = dtx.MagazamTablom.Where(x => x.urunturu.StartsWith(isim)).ToList();
            return View("Index",magazm);
        }
        public ActionResult fiyatagore(int fiyat1,int fiyat2)
        {
            List<Magaza> magazma = dtx.MagazamTablom.Where(x => x.fiyat < fiyat2 && x.fiyat > fiyat1).ToList();
            return View("Index",magazma);
        }


    }
}