using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class Plytum
    {
        public Plytum()
        {
            Opinia = new HashSet<Opinium>();
            PozycjaKoszykas = new HashSet<PozycjaKoszyka>();
            PozycjaZamowienia = new HashSet<PozycjaZamowienium>();
        }

        public int IdPlyta { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public string Gatunek { get; set; }
        public string Zdjecie1 { get; set; }
        public string Zdjecie2 { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public string Opis { get; set; }
        public DateTime DataWydania { get; set; }

        public virtual ICollection<Opinium> Opinia { get; set; }
        public virtual ICollection<PozycjaKoszyka> PozycjaKoszykas { get; set; }
        public virtual ICollection<PozycjaZamowienium> PozycjaZamowienia { get; set; }
    }
}
