using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            ViewBag.Titolo = "Kampus Studio - Elenco comuni";
            List<ComuneViewModel> comuni = await comuneService.GetComuniAsync();
            return View(comuni);
        }

        public async Task<IActionResult> Dettaglio(string id)
        {
            ComuneViewModel comune = await comuneService.GetComuneAsync(id);
            ViewBag.Titolo = "Kampus Studio - Comune di " + comune.nomeComune;
            return View(comune);
        }
    }
}