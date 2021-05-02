using System;
using System.Collections.Generic;


namespace MVCSHOP.Models
{
    public class Zamowienia
    {
        public int IdZamowienie { get; set; }
        public int IdKlient { get; set; }
        public DateTime DataZamowienia { get; set; }
        public string StanZamowienia { get; set; }
        public decimal CenaZamowienia { get; set; }

    }
}
