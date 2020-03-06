using Microsoft.AspNetCore.Mvc;

namespace kampus.Controllers
{
    public class ComuniController : Controller
    {
        public IActionResult Index()
        {
            return Content("Ciao, io sono l'index!");
        }

        public IActionResult Dettaglio(string id)
        {
            if (!string.IsNullOrEmpty(id)) return Content($"Sono il dettaglio e ho ricevuto l'id {id}");
            else return Content("Sono il dettaglio e non ho ricevuto nessun id");
        }
    }
}