namespace KampusStudio.Models.ViewModels
{
    public class ComuneViewModel
    {
        public string codiceCatastale {get; set;}
        public string nomeComune {get; set;}
        public int regione {get; set;}
        public int provincia {get; set;}
        public RipartizioneGeografica ripartizioneGeografica {get; set;}
        public int abitanti {get; set;}
        public string prefisso {get; set;}
        public string cap {get; set;}
    }
}