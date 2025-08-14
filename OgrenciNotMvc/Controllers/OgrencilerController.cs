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
    }
}