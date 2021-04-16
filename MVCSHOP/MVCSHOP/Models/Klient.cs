using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Koszyks = new HashSet<Koszyk>();
            Opinia = new HashSet<Opinium>();
            Zamowienies = new HashSet<Zamowienie>();
        }

        public int IdKlient { get; set; }
        public int IdAdres { get; set; }
        public int IdSiteUser { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DataZostaniaKlientem { get; set; }

        public virtual Adre IdAdresNavigation { get; set; }
        public virtual SiteUser IdSiteUserNavigation { get; set; }
        public virtual ICollection<Koszyk> Koszyks { get; set; }
        public virtual ICollection<Opinium> Opinia { get; set; }
        public virtual ICollection<Zamowienie> Zamowienies { get; set; }
    }
}
