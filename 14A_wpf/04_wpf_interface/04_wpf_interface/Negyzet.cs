using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_wpf_interface
{
    public class Negyzet : IAlakzat
    {

        private double _oldal;

        public double oldal
        {
            get { return _oldal; }
            set { 
                if (value <= 0) { throw new ArgumentException("Az oldal csak pozitív szám lehet!"); }
                else { _oldal = value; }
                
            }
        }

        public double kerulet { get { return 4*oldal; } }

        public double terulet => oldal * oldal;

        public string nev { get { return "Négyzet"; } }

        public int oldalakSzama { get { return 4; } }

        public Negyzet(double oldal)
        {
                this.oldal = oldal;
        }
    }
}
