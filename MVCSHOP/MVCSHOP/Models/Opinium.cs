using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class Opinium
    {
        public int IdOpinia { get; set; }
        public int IdKlient { get; set; }
        public int IdPlyta { get; set; }
        public string Tresc { get; set; }

        public virtual Klient IdKlientNavigation { get; set; }
        public virtual Plytum IdPlytaNavigation { get; set; }
    }
}
