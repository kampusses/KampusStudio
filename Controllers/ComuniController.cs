using System.Collections.Generic;
using KampusStudio.Models.Services.Application;
using KampusStudio.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace kampus.Controllers
{
    public class ComuniController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Titolo = "Kampus Studio - Elenco comuni";
            var comuneService = new ComuneService();
            List<ComuneViewModel> comuni = comuneService.GetComune();
            return View(comuni);
        }

        public IActionResult Dettaglio(string id)
        {
            ViewBag.Titolo = "Kampus Studio - Comune di XXXX";
            /* Aggiungere il codice per inserire il nome del comune nel TITLE della pagina */
            return View();
        }
    }
}