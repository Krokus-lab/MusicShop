using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Models
{
    public class Plyta
    {

        public int IdPlyta { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Tytul { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Autor { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Gatunek { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Zdjecie1 { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Zdjecie2 { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za dlugo")]
        public string Opis { get; set; }
        public DateTime DataWydania { get; set; }
    }
}
