using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_wpf_evfolyam
{
    public class Tanulo
    {
        public string nev { get; set; }
        public string osztaly { get; set;}

        public int matematika { get; set; }
        public int informatika { get; set; }

        public int? angol { get; set; }
        public int? nemet { get; set; }

        public Tanulo(string sor)
        {
            string[] adatok = sor.Split(';');
            nev = adatok[0];
            osztaly = adatok[1];
            matematika = int.Parse(adatok[2]);
            angol = (adatok[3] != "" ? int.Parse(adatok[3]) : null);
            nemet = (adatok[4] != "" ? int.Parse(adatok[4]) : null);
            informatika = int.Parse(adatok[5]);
            informatika = int.Parse(adatok[5]);
        }
    }
}
