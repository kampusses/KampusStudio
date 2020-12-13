using System;
using System.Collections.Generic;

#nullable disable

namespace kampus.Models.Entities
{
    public partial class Regione
    {
        public int CodiceRegione { get; private set; }
        public string NomeRegione { get; private set; }
        public int RipartizioneGeografica { get; private set; }
        public string CodiceCapoluogo { get; private set; }
    }
}
