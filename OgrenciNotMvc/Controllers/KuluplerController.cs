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
	}
}