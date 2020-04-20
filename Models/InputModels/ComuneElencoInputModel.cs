using System;
using KampusStudio.Customizations.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudio.Models.InputModels
{
    [ModelBinder(BinderType = typeof(ComuneElencoInputModelBinder))]
    public class ComuneElencoInputModel
    {
        public ComuneElencoInputModel(string search, int page, string orderby, bool ascending)
        {

            if (orderby != "nomeComune" && orderby != "abitanti")
            {
                orderby = "nomeComune";
                ascending = true;
            }

            //SANITIZZAZIONE
            Search = search ?? "";
            Page = Math.Max(1, page);
            OrderBy = orderby;
            Ascending = ascending;

            // IMPOSTAZIONI DI PAGINA
            Limit = 10;
            Offset = (Page - 1) * Limit;
        }
        public string Search { get; }
        public int Page { get; }
        public string OrderBy { get; }
        public bool Ascending { get; }
        public int Limit { get; }
        public int Offset { get; }
    }
}