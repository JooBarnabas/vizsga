using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace _18_EF_EgyATobbKapcsolat
{
    public class Osztaly
    {
        [Key] 
        public int osztalyId { get; set; }

        [Required]
        [StringLength(10)]
        public string osztalyNev { get; set; }

        public string osztalyFonok { get; set; }

        // kapcsolat
        // 1 -> N
        public ICollection<Tanulo> Tanulo { get; set; }
    }
}
