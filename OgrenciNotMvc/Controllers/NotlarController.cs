using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
		//public ActionResult Guncelle(int id)
		//{
		//	var guncelleme = db.Notlar.Find(id);
		//	db.Notlar.up
		//	db.SaveChanges();
		//	return RedirectToAction("Index");
		//}
	}
}