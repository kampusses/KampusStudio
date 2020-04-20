using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudio.Models.ViewModels;
using KampusStudio.Models.InputModels;

namespace KampusStudio.Models.Services.Application
{
    public interface IComuneService
    {
         Task<List<ComuneViewModel>> GetComuniAsync(ComuneElencoInputModel model);
         Task<ComuneViewModel> GetComuneAsync(string id);
    }
}