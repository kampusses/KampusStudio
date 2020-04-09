using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public interface IProvinciaService
    {
        Task<List<ProvinciaViewModel>> GetProvinceAsync();
        Task<ProvinciaViewModel> GetProvinciaAsync(int id);
    }
}