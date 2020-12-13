using System;
using System.Collections.Generic;

#nullable disable

namespace kampus.Models.Entities
{
    public partial class Regioni
    {
        public int CodiceRegione { get; set; }
        public string NomeRegione { get; set; }
        public int RipartizioneGeografica { get; set; }
        public string CodiceCapoluogo { get; set; }
    }
}
