using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudio.Models.Services.Application;
using KampusStudio.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kampus.Controllers
{
    public class RegioniController : Controller
    {
        private readonly IRegioneService regioneService;
        public RegioniController(IRegioneService regioneService)
        {
            this.regioneService = regioneService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Titolo = "Kampus Studio - Elenco regioni";
            List<RegioneViewModel> regioni = await regioneService.GetRegioniAsync();
            return View(regioni);
        }

        public async Task<IActionResult> Dettaglio(int id)
        {
            RegioneViewModel regione = await regioneService.GetRegioneAsync(id);
            ViewBag.Titolo = "Kampus Studio - Regione " + regione.nomeRegione;
            return View(regione);
        }
    }
}