using System;
using System.Data;

namespace KampusStudio.Models.ViewModels
{
    public class RegioneViewModel
    {
        public int codiceRegione {get; set;}
        public string nomeRegione {get; set;}
        public RipartizioneGeografica ripartizioneGeografica {get; set;}
        public ComuneViewModel codiceCapoluogo {get; set;}
        public int abitanti {get; set;}
        public int numComuni {get; set;}
    
        public static RegioneViewModel FromDataRow(DataRow regioneRow)
        {
            var regioneViewModel = new RegioneViewModel
            {
                codiceRegione = (int) regioneRow["codiceRegione"],
                nomeRegione = (string) regioneRow["nomeRegione"],
                ripartizioneGeografica = (RipartizioneGeografica) regioneRow["ripartizioneGeografica"] -1,
                codiceCapoluogo = new ComuneViewModel(),
                abitanti = 0,
                numComuni = 0
            };
            return regioneViewModel;
        }
    }
}