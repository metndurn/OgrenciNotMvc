using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
		// GET: Ogrenciler
		DbMvcOkulEntities db = new DbMvcOkulEntities(); // Veritabanı ile bağlantı kurduk
		public ActionResult Index()
        {
			var ogrenciler = db.Ogrenciler.ToList(); // Ogrenciler tablosundaki verileri listeledik
			return View(ogrenciler);
        }
		[HttpGet]
		public ActionResult YeniOgrenci()
		{
			List<SelectListItem> kulupler = (from x in db.Kulupler.ToList()
											 select new SelectListItem
											 {
												 Text = x.KulupAd,
												 Value = x.KulupId.ToString()
											 }).ToList();
			ViewBag.kulupler = kulupler; // Kulupler listesini ViewBag'e atadık
			return View();
		}
		[HttpPost]
		public ActionResult YeniOgrenci(Ogrenciler ogrenciler)
		{
			var kulup = db.Kulupler.Where(x => x.KulupId == ogrenciler.Kulupler.KulupId).FirstOrDefault();//Kulüp ID'sine göre kulüp bilgilerini aldık
			ogrenciler.Kulupler = kulup; // Ogrenciler modeline kulüp bilgilerini atadık
			db.Ogrenciler.Add(ogrenciler);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Sil(int id)
		{
			var ogrenci = db.Ogrenciler.Find(id);
			db.Ogrenciler.Remove(ogrenci);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult OgrenciGetir(int id)
		{
			var ogrenci = db.Ogrenciler.Find(id); // Güncellenecek öğrenciyi bulduk
			return View("OgrenciGetir", ogrenci); // Öğrenci bilgilerini güncelleme sayfasına gönderdik
		}
	}
}