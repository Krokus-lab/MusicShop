using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Models
{
    public class KlientAdresUser
    {
        public string Ulica { get; set; }
        public string Lokal { get; set; }
        public string NumerLokal { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }

        public string UserPassword { get; set; }
        public string UserLogin { get; set; }
        public string UserRole { get; set; }

        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DataZostaniaKlientem { get; set; }
    }
}
