using System.Collections.Generic;
using KampusStudio.Models.Services.Application;
using KampusStudio.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace kampus.Controllers
{
    public class ComuniController : Controller
    {
        private readonly IComuneService comuneService;
        public ComuniController(IComuneService comuneService)
        {
            this.comuneService = comuneService;

        }
        public IActionResult Index()
        {
            ViewBag.Titolo = "Kampus Studio - Elenco comuni";

            List<ComuneViewModel> comuni = comuneService.GetComuni();
            return View(comuni);
        }

        public IActionResult Dettaglio(string id)
        {

            ComuneViewModel comune = comuneService.GetComune(id);
            ViewBag.Titolo = "Kampus Studio - Comune di " + comune.nomeComune;
            return View(comune);
        }
    }
}