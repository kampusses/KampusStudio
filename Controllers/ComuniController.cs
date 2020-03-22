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
            List<ComuneViewModel> comuni = comuneService.GetComuni();
            return View(comuni);
        }

        public IActionResult Dettaglio(string id)
        {
            var comuneService = new ComuneService();
            ComuneViewModel comune = comuneService.GetComune(id);
            ViewBag.Titolo = "Kampus Studio - Comune di " + comune.nomeComune;
            return View(comune);
        }
    }
}