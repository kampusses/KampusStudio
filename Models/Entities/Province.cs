using System;
using System.Collections.Generic;

#nullable disable

namespace kampus.Models.Entities
{
    public partial class Provincia
    {
        public int CodiceProvincia { get; private set; }
        public int CodiceRegione { get; private set; }
        public string NomeProvincia { get; private set; }
        public string SiglaProvincia { get; private set; }

        public virtual Comune Comune { get; private set; }
        public virtual Regione Regione { get; private set; }
    }
}
