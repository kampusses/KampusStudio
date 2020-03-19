using System;
using System.Collections.Generic;
using KampusStudio.Models.ViewModels;

namespace KampusStudio.Models.Services.Application
{
    public class ComuneService
    {
        // codice che popola 20 istanze nel viewModel
        public List<ComuneViewModel> GetComune()
        {
            var elencoComuni = new List<ComuneViewModel>();
            for (int i = 1; i <= 20; i++)
            {
                var comune = new ComuneViewModel
                {
                    codiceCatastale = $"Cod{i}",
                    nomeComune = $"Comune{i}",
                    regione = i,
                    provincia = i,
                    ripartizioneGeografica = (RipartizioneGeografica) (i % 5),
                    abitanti = i * 1000,
                    prefisso = "0883",
                    cap = "76016"
                };
                elencoComuni.Add(comune);
            }
            return elencoComuni;
        }
    }
}