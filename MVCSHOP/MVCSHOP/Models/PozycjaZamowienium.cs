using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class PozycjaZamowienium
    {
        public int IdPozycjaZamowienia { get; set; }
        public int IdPlyta { get; set; }
        public int IdZamowienie { get; set; }
        public int Ilosc { get; set; }

        public virtual Plytum IdPlytaNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
