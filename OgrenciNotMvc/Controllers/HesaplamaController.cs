using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class HesaplamaController : Controller
    {
        // GET: Hesaplama
        public ActionResult Index(double sayi1 = 0, double sayi2 = 0)//geri donuşlü metottur ve metod ıcınde deger verilmezse hata veriyor
        {
			double toplam = sayi1 + sayi2;
			double cikarma = sayi1 - sayi2;
			double carpma = sayi1 * sayi2;
			double bolme = (sayi2 != 0) ? sayi1 / sayi2 : 0;
			//double bolme = sayi1 / sayi2;

			ViewBag.toplam = toplam; // Hesaplanan sonucu ViewBag'e atadık
            ViewBag.cikarma = cikarma;
            ViewBag.carpma = carpma;
            ViewBag.bolme = bolme;

			ViewBag.sayi1 = sayi1; // İlk sayıyı ViewBag'e atadık
			ViewBag.sayi2 = sayi2; // İkinci sayıyı ViewBag'e atadık
			return View();
        }
	}
}