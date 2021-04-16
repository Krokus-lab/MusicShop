using System;
using System.Collections.Generic;

#nullable disable

namespace MVCSHOP.Models
{
    public partial class SiteUser
    {
        public int IdSiteUser { get; set; }
        public string UserPassword { get; set; }
        public string UserLogin { get; set; }
        public string UserRole { get; set; }

        public virtual Klient Klient { get; set; }
        public virtual Pracownik Pracownik { get; set; }
    }
}
