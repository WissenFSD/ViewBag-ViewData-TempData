using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewBag_ViewData_TempData.Models;

namespace ViewBag_ViewData_TempData.Controllers
{
	public class HomeController : Controller
	{

		public HomeController()
		{

		}

		public IActionResult Index()
		{

			//ViewBag : ViewBag verileri, Controllerdan, View' iletmek için tasarlanan dinamik bir tiptir. ViewBag genel bir tiptir. Sizler tiplerinizi ViewBag içerisine koymak için, ViewBag'de bir ufa tanýmlama yapmanýz yeterlidir.

			ViewBag.Baslik = "Bu sayfa inceleme sayfasýdýr.";
			ViewBag.Names = new List<string>() { "Numan", "Ayþe", "Ali", "Mehmet", "Kazým", "Teoman", "Berke", "Hamza", "Gül" };


			//ViewData : View bag gibi verileri controllerden view'lara iletmek için kullanýlýr. Ancak ViewBag'in aksiyine, ViewData key value þeklinde çalýþýr.

			List<string> cities = new List<string>()
			{
				"Kars","Aðrý","Mardin","Bitlis","Diyarbakýr","Siirt","Ýzmir","Trabzon","Artvin","Erzurum"
			};
			ViewData["cities"] = cities;

			//TempData : Verilerin,farklý metotlar arasýnda ve tek oturumda veri transfer edilmesini saðlar.TempData verileri, HTTP isteði süresince tutar. 
			//TempData'nýn yaþam süresi, bir sonraki isteðin gelmesi ile sýnýrlýdýr. 


			TempData["colors"] = new List<string>() { "Sarý", "Mavi", "Kýrmýzý", "Bordo", "Beyaz", "Siyah", "Gri" };

			return RedirectToAction("Privacy");
		}

		public IActionResult Privacy()
		{
			// Peek metodu ile veriler okuduðunda action'lar arasý veri transfer için kullanabilirsiniz
			var colors = TempData.Peek("colors");
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
