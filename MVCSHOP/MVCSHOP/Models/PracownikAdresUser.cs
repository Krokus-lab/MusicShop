using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Models
{
    public class PracownikAdresUser
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Ulica { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Lokal { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string NumerLokal { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string KodPocztowy { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Miasto { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string UserPassword { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string UserLogin { get; set; }
       
        public string UserRole { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]


        public string Imie { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Nazwisko { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Telefon { get; set; }
    }
}
