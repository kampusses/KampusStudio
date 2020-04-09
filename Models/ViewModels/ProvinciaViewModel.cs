using System;
using System.Data;

namespace KampusStudio.Models.ViewModels
{
    public class ProvinciaViewModel
    {
        public int codiceProvincia {get; set;}
        public int codiceRegione {get; set;}
        public string nomeProvincia {get; set;}
        public string siglaProvincia {get; set;}
    
        public static ProvinciaViewModel FromDataRow(DataRow provinciaRow)
        {
            var provinciaViewModel = new ProvinciaViewModel
            {
                codiceProvincia = (int) provinciaRow["codiceProvincia"],
                codiceRegione = (int) provinciaRow["codiceProvincia"],
                nomeProvincia = (string) provinciaRow["nomeProvincia"],
                siglaProvincia = (string) provinciaRow["siglaProvincia"]
            };
            return provinciaViewModel;
        }
    }
}