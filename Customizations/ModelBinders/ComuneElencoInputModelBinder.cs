using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using KampusStudio.Models.InputModels;

namespace KampusStudio.Customizations.ModelBinders
{
    public class ComuneElencoInputModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //Recuperiamo i valori grazie ai value provider
            string search = bindingContext.ValueProvider.GetValue("Search").FirstValue;
            string orderBy = bindingContext.ValueProvider.GetValue("OrderBy").FirstValue;
            int.TryParse(bindingContext.ValueProvider.GetValue("Page").FirstValue, out int page);
            bool.TryParse(bindingContext.ValueProvider.GetValue("Ascending").FirstValue, out bool ascending);
            string cap = bindingContext.ValueProvider.GetValue("Cap").FirstValue;
            string prefisso = bindingContext.ValueProvider.GetValue("Prefisso").FirstValue;

            //Creiamo l'istanza del ComuneElencoInputModel
            var inputModel = new ComuneElencoInputModel(search, page, orderBy, ascending, cap, prefisso);

            //Impostiamo il risultato per notificare che la creazione è avvenuta con successo
            bindingContext.Result = ModelBindingResult.Success(inputModel);

            //Restituiamo un task completato
            return Task.CompletedTask;
        }
    }
}