using System;
using KampusStudio.Customizations.ModelBinders;
using Microsoft.AspNetCore.Mvc;

namespace KampusStudio.Models.InputModels
{
    [ModelBinder(BinderType = typeof(ComuneElencoInputModelBinder))]
    public class ComuneElencoInputModel
    {
        public ComuneElencoInputModel(string search, string searchtype, int page, string orderby, bool ascending, string cap, string prefisso)
        {
            if (orderby != "nomeComune" && orderby != "abitanti")
            {
                orderby = "nomeComune";
                ascending = true;
            }

            //SANITIZZAZIONE
            Search = search ?? "";
            if (searchtype == null || (searchtype != "Nome comune" && searchtype != "CAP" && searchtype != "Prefisso")) SearchType = "Nome comune";
            else SearchType = searchtype;
            Page = Math.Max(1, page);
            OrderBy = orderby;
            Ascending = ascending;
            Cap = cap;
            Prefisso = prefisso;

            // IMPOSTAZIONI DI PAGINA
            Limit = 10;
            Offset = (Page - 1) * Limit;
        }
        public string Search { get; }
        public string SearchType { get; }
        public int Page { get; }
        public string OrderBy { get; }
        public bool Ascending { get; }
        public string Cap { get; }
        public string Prefisso { get; }
        public int Limit { get; }
        public int Offset { get; }
    }
}