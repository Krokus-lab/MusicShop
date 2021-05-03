using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Models
{
    public class Opinia
    {
        public int IdOpinia { get; set; }
        public int IdKlient { get; set; }
        public int IdPlyta { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Za długa tresc")]
        public string Tresc { get; set; }
    }
}
