using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
		// GET: Kulupler
		DbMvcOkulEntities db = new DbMvcOkulEntities(); // Veritabanı ile bağlantı kurduk
		public ActionResult Index()
        {
            var kulupler = db.Kulupler.ToList(); // Kulupler tablosundaki verileri listeledik
			return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniKulup(Kulupler kulupler)
		{
			db.Kulupler.Add(kulupler);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Sil(int id)
		{
			var kulup = db.Kulupler.Find(id); // Silinecek kulübü bulduk
			db.Kulupler.Remove(kulup); // Kulübü veritabanından sildik
			db.SaveChanges(); // Değişiklikleri kaydettik
			return RedirectToAction("Index");
		}
		public ActionResult KulupGetir(int id)//guncelleme yapmak ıcın kulubu baska sayfada ıslememiz lazım o yuzden buraya ıhtıyac vardır
		{
			var kulup = db.Kulupler.Find(id); // Güncellenecek kulübü bulduk
			return View("KulupGetir",kulup); // Kulüp bilgilerini güncelleme sayfasına gönderdik
		}
		public ActionResult Guncelle(Kulupler kulupler)
		{
			var kulup = db.Kulupler.Find(kulupler.KulupId); // Güncellenecek kulübü bulduk
			kulup.KulupAd = kulupler.KulupAd; // Kulüp adını güncelledik
			kulup.KulupKontenjan = kulupler.KulupKontenjan; // Kulüp kontenjanını güncelledik
			db.SaveChanges(); // Değişiklikleri kaydettik
			return RedirectToAction("Index","Kulupler");
		}
	}
}