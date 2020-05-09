using System;
using System.Data;

namespace KampusStudio.Models.ViewModels
{
    public class ComuneViewModel
    {
        public string codiceCatastale {get; set;}
        public string nomeComune {get; set;}
        public RegioneViewModel regione {get; set;}
        public ProvinciaViewModel provincia {get; set;}
        public int flagProvincia {get; set;}
        public int flagRegione {get; set;}
        public int abitanti {get; set;}
        public string prefisso {get; set;}
        public string cap {get; set;}

        public static ComuneViewModel FromDataRow(DataRow comuneRow)
        {
            var comuneViewModel = new ComuneViewModel
            {
                codiceCatastale = (string) comuneRow["codiceCatastale"],
                nomeComune = (string) comuneRow["nomeComune"],
                regione = new RegioneViewModel(),
                provincia = new ProvinciaViewModel(),
                abitanti = (int) comuneRow["abitanti"],
                prefisso = (string) comuneRow["prefisso"],
                cap = (string) comuneRow["cap"],
                flagProvincia = (int) comuneRow["flagProvincia"],
                flagRegione = (int) comuneRow["flagRegione"]
            };
            return comuneViewModel;
        }
    }
}