using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class Koszyk
    {
        public Koszyk()
        {
            PozycjaKoszykas = new HashSet<PozycjaKoszyka>();
        }

        public int IdKoszyk { get; set; }
        public int IdKlient { get; set; }

        public virtual Klient IdKlientNavigation { get; set; }
        public virtual ICollection<PozycjaKoszyka> PozycjaKoszykas { get; set; }
    }
}
