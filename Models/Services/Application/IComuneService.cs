using System.Collections.Generic;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public interface IComuneService
    {
         List<ComuneViewModel> GetComuni();
         ComuneViewModel GetComune(string id);
    }
}