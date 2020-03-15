using Microsoft.AspNetCore.Mvc;

namespace kampus.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Titolo = "Kampus Studio";
            return View();
        }

    }
}