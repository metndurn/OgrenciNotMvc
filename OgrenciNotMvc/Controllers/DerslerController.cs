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
    }
}