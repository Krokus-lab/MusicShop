using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Models
{
    public class Plyta
    {
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
    }
}
