using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_EF_TobbATobbKapcsolat
{
    public class Teszt
    {
        [Key]
        public int tesztId { get; set; }

        [Required]
        [StringLength(100)]
        public string tesztMegnevezes { get; set; }

        public ICollection<TesztEredmenyek> tesztEredmenyek { get; set; }
    }
}
