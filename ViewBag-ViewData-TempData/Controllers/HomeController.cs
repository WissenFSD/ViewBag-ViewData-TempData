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

			//ViewBag : ViewBag verileri, Controllerdan, View' iletmek i�in tasarlanan dinamik bir tiptir. ViewBag genel bir tiptir. Sizler tiplerinizi ViewBag i�erisine koymak i�in, ViewBag'de bir ufa tan�mlama yapman�z yeterlidir.

			ViewBag.Baslik = "Bu sayfa inceleme sayfas�d�r.";
			ViewBag.Names = new List<string>() { "Numan", "Ay�e", "Ali", "Mehmet", "Kaz�m", "Teoman", "Berke", "Hamza", "G�l" };


			//ViewData : View bag gibi verileri controllerden view'lara iletmek i�in kullan�l�r. Ancak ViewBag'in aksiyine, ViewData key value �eklinde �al���r.

			List<string> cities = new List<string>()
			{
				"Kars","A�r�","Mardin","Bitlis","Diyarbak�r","Siirt","�zmir","Trabzon","Artvin","Erzurum"
			};
			ViewData["cities"] = cities;

			//TempData : Verilerin,farkl� metotlar aras�nda ve tek oturumda veri transfer edilmesini sa�lar.TempData verileri, HTTP iste�i s�resince tutar. 
			//TempData'n�n ya�am s�resi, bir sonraki iste�in gelmesi ile s�n�rl�d�r. 


			TempData["colors"] = new List<string>() { "Sar�", "Mavi", "K�rm�z�", "Bordo", "Beyaz", "Siyah", "Gri" };

			return RedirectToAction("Privacy");
		}

		public IActionResult Privacy()
		{
			// Peek metodu ile veriler okudu�unda action'lar aras� veri transfer i�in kullanabilirsiniz
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
