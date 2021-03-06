using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudio.Models.InputModels;
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
        public async Task<IActionResult> Index(ComuneElencoInputModel input)
        {
            ViewBag.Titolo = "Kampus Studio - Elenco comuni";
            ListViewModel<ComuneViewModel> comuni = await comuneService.GetComuniAsync(input);

            ComuneListViewModel viewModel = new ComuneListViewModel
            {
                Comuni = comuni,
                Input = input
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Dettaglio(string id)
        {
            ComuneViewModel comune = await comuneService.GetComuneAsync(id);
            ViewBag.Titolo = "Kampus Studio - Comune di " + comune.nomeComune;
            return View(comune);
        }
    }
}