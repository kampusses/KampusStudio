using System;
using System.Data;

namespace KampusStudio.Models.ViewModels
{
    public class RegioneViewModel
    {
        public int codiceRegione {get; set;}
        public string nomeRegione {get; set;}
        public RipartizioneGeografica ripartizioneGeografica {get; set;}
    
        public static RegioneViewModel FromDataRow(DataRow regioneRow)
        {
            var regioneViewModel = new RegioneViewModel
            {
                codiceRegione = (int) regioneRow["codiceRegione"],
                nomeRegione = (string) regioneRow["nomeRegione"],
                ripartizioneGeografica = (RipartizioneGeografica) regioneRow["ripartizioneGeografica"] -1
            };
            return regioneViewModel;
        }
    }
}