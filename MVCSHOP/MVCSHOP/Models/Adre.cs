using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class Adre
    {
        public int IdAdres { get; set; }
        public string Ulica { get; set; }
        public string Lokal { get; set; }
        public string NumerLokal { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }

        public virtual Klient Klient { get; set; }
        public virtual Pracownik Pracownik { get; set; }
    }
}
