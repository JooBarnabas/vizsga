using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace _18_EF_EgyATobbKapcsolat
{
    public class Tanulo
    {
        [Key]
        public int tanuloId { get; set; }

        [Required]
        [StringLength(50)]
        public string tanuloNev { get; set; }

        public DateTime szuletesiDatum { get; set; }

        // kapcsolat
        // N -> 1
        public Osztaly Osztaly { get; set; }
        public int osztalyId { get; set; } // név egyezés !!!
    }
}
