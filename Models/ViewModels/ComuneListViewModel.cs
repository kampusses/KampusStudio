using System.Collections.Generic;
using KampusStudio.Models.InputModels;

namespace KampusStudio.Models.ViewModels
{
    public class ComuneListViewModel
    {
        public List<ComuneViewModel> Comuni { get; set; }
        public ComuneElencoInputModel Input { get; set; }
    }
}