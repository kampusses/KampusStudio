using System;
using System.Collections.Generic;

#nullable disable

namespace kampus.Models.Entities
{
    public partial class Province
    {
        public int CodiceProvincia { get; set; }
        public int CodiceRegione { get; set; }
        public string NomeProvincia { get; set; }
        public string SiglaProvincia { get; set; }
    }
}
