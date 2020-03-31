using System.Collections.Generic;
using System.Threading.Tasks;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public interface IRegioneService
    {
        Task<List<RegioneViewModel>> GetRegioniAsync();
        Task<RegioneViewModel> GetRegioneAsync(int id);
    }
}