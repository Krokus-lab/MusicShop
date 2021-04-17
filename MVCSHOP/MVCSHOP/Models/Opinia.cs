using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSHOP.Models
{
    public class Opinia
    {
        public int IdOpinia { get; set; }
        public int IdKlient { get; set; }
        public int IdPlyta { get; set; }
        public string Tresc { get; set; }
    }
}
