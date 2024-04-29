using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_wpf_orszagok
{
    public class Orszag
    {
        public string kod { get; set; }
        public string megnevezes { get; set; }

        public string zaszlo
        {
            get
            {
                return string.Format("img\\{0}.png", kod).ToLower();
                //return string.Format(@"img\{0}.png", kod);
            }
        }

        public string kod2
        {
            get
            {
                return string.Format("Ország kód: {0}", kod);
            }
        }

        public Orszag(string sor)
        {
            string[] adatok = sor.Split(';');
            kod = adatok[0];
            megnevezes = adatok[1];
        }

    }
}
