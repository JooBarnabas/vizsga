using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_EF_TobbATobbKapcsolat
{
    public class TesztEredmenyek
    {
        [Key]
        public int id { get; set; }

        public int tanuloId { get; set; }
        public Tanulo Tanulo { get; set; }

        public int tesztId { get; set; }
        public Teszt Teszt { get; set; }

        // egyéb mezők
        public int eredmeny { get; set; }

        public DateTime datum { get; set; }
    }
}
