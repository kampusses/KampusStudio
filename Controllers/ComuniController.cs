using Microsoft.AspNetCore.Mvc;

namespace kampus.Controllers
{
    public class ComuniController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Titolo = "Kampus Studio - Elenco comuni";
            return View();
        }

        public IActionResult Dettaglio(string id)
        {
            ViewBag.Titolo = "Kampus Studio - Comune di XXXX";
            /* Inserire il codice per inserire il nome del comune nel TITLE della pagina */
            return View();
        }
    }
}