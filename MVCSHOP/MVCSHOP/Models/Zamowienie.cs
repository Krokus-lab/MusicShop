using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            PozycjaZamowienia = new HashSet<PozycjaZamowienium>();
        }

        public int IdZamowienie { get; set; }
        public int IdKlient { get; set; }
        public DateTime DataZamowienia { get; set; }
        public string StanZamowienia { get; set; }
        public decimal CenaZamowienia { get; set; }

        public virtual Klient IdKlientNavigation { get; set; }
        public virtual ICollection<PozycjaZamowienium> PozycjaZamowienia { get; set; }
    }
}
