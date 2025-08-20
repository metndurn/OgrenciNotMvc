using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
		// GET: Notlar
		DbMvcOkulEntities db = new DbMvcOkulEntities(); // Veritabanı ile bağlantı kurduk
		public ActionResult Index()
        {
			var notlar = db.Notlar.ToList(); // Notlar tablosundaki verileri listeledik
			return View(notlar);
        }
		[HttpGet]
		public ActionResult YeniNot()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniNot(Notlar notlar)
		{
			db.Notlar.Add(notlar);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult NotGetir(int id)
		{
			var not = db.Notlar.Find(id); // Güncellenecek notu bulduk
			return View("NotGetir", not);
		}
		/*burada post ekleyıp metod ısmı ve ıcınde ki degerlerı sıfır yaptık null olmasın dıye sımdılık bunlar degıstı*/
		[HttpPost]
		public ActionResult NotGetir(Notlar notlar,NotIslemi model, int Sinav1=0,int Sinav2 = 0, int Sinav3 = 0, int Proje = 0)
		{
			if (model.Islem=="Hesapla")
			{
				//islem 1
				int ortalamaHesapla = (Sinav1 + Sinav2 + Sinav3 + Proje) / 4;
				ViewBag.Ortalama = ortalamaHesapla;
			}
			if (model.Islem=="NotGuncelle")
			{
				//islem 2
				var not = db.Notlar.Find(notlar.NotId); // Güncellenecek notu bulduk
				not.Sinav1 = notlar.Sinav1;
				not.Sinav2 = notlar.Sinav2;
				not.Sinav3 = notlar.Sinav3;
				not.Proje = notlar.Proje;
				not.Ortalama = notlar.Ortalama;
				//not.Ortalama = (not.Sinav1 + not.Sinav2 + not.Sinav3 + not.Proje) / 4; // Ortalama hesaplama
				//not.Durum = not.Ortalama >= 50 ? true : false; // Durum kontrolü
				db.SaveChanges(); // Değişiklikleri kaydettik
				return RedirectToAction("Index","Notlar");
			}
			return View();
		}
	}
}