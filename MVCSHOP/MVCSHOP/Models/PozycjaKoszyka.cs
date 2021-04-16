using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class PozycjaKoszyka
    {
        public int IdPozycjaKoszyka { get; set; }
        public int IdKoszyk { get; set; }
        public int IdPlyta { get; set; }
        public int Ilosc { get; set; }

        public virtual Koszyk IdKoszykNavigation { get; set; }
        public virtual Plytum IdPlytaNavigation { get; set; }
    }
}
