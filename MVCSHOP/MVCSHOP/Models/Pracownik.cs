using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class Pracownik
    {
        public int IdPracownik { get; set; }
        public int IdAdres { get; set; }
        public int IdSiteUser { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public virtual Adre IdAdresNavigation { get; set; }
        public virtual SiteUser IdSiteUserNavigation { get; set; }
    }
}
