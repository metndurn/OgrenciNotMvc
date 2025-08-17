using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DerslerController : Controller
    {
		// GET: Default
		DbMvcOkulEntities db = new DbMvcOkulEntities();//veritabanı ile baglantı kurduk
		public ActionResult Index()
        {
            var dersler = db.Dersler.ToList(); //Dersler tablosundaki verileri listeledik
			return View(dersler);
        }

		[HttpGet]// Yeni ders eklemek icin sayfa acildi
		public ActionResult YeniDers() //Yeni ders eklemek icin sayfa acildi
		{
			return View();
		}

		[HttpPost]// Yeni ders eklemek icin sayfa gonderildi
		public ActionResult YeniDers(Dersler dersler)//geriye deger donduren metod olmus oldu
		{
			db.Dersler.Add(dersler); //Dersler tablosuna yeni ders ekledik
			db.SaveChanges(); //Degisiklikleri kaydettik
			return RedirectToAction("Index");
		}
		public ActionResult Sil(int id) //Silme islemi icin id degeri alindi
		{
			var ders = db.Dersler.Find(id);
			db.Dersler.Remove(ders);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DersGetir(int id) //Guncelleme islemi icin ders bilgileri alindi
		{
			var ders = db.Dersler.Find(id); //Guncellenecek dersi bulduk
			return View("DersGetir",ders); //Ders bilgilerini guncelleme sayfasina gonderdik
		}
	}
}