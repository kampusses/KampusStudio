using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudio.Models.Services.Application;
using KampusStudio.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudio.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly IProvinciaService provinciaService;
        public ProvinceController(IProvinciaService provinciaService)
        {
            this.provinciaService = provinciaService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Titolo = "Kampus Studio - Elenco province";
            List<ProvinciaViewModel> province = await provinciaService.GetProvinceAsync();
            return View(province);
        }

        public async Task<IActionResult> Dettaglio(int id)
        {
            ProvinciaViewModel provincia = await provinciaService.GetProvinciaAsync(id);
            ViewBag.Titolo = "Kampus Studio - Provincia " + provincia.nomeProvincia;
            return View(provincia);
        }
    }
}