using System;
using System.Collections.Generic;

#nullable disable

namespace kampus.Models.Entities
{
    public partial class Comuni
    {
        public string CodiceCatastale { get; set; }
        public string NomeComune { get; set; }
        public int Regione { get; set; }
        public int Provincia { get; set; }
        public int FlagRegione { get; set; }
        public int FlagProvincia { get; set; }
        public int Abitanti { get; set; }
        public string Prefisso { get; set; }
        public string Cap { get; set; }
        public string CodiceIstat { get; set; }
    }
}
