using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public interface IComuneService
    {
         Task<List<ComuneViewModel>> GetComuniAsync();
         Task<ComuneViewModel> GetComuneAsync(string id);
    }
}