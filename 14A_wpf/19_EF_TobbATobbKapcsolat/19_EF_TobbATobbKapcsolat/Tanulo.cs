using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_EF_TobbATobbKapcsolat
{
    public class Tanulo
    {
        [Key]
        public int tanuloId { get; set; }

        [StringLength(50)]
        [Required]
        public string tanuloNev { get; set; }

        public DateTime szuletesiDatum { get; set; }

        public ICollection<TesztEredmenyek> tesztEredmenyek { get; set; }
    }
}
