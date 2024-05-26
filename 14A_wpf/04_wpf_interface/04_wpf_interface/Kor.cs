using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_wpf_interface
{
    public class Kor : IAlakzat
    {
        private double _sugar;

        public double sugar
        {
            get { return _sugar; }
            set
            {
                if (value <= 0) { throw new ArgumentException("A sugár csak pozitív szám lehet!"); }
                else { _sugar = value; }

            }
        }
        public string nev => "Kör";
        
        public double kerulet => 2 * sugar * Math.PI;

        public double terulet => sugar * sugar * Math.PI;

        public int oldalakSzama => 1;

        public Kor(double sugar)
        {
                this.sugar = sugar;
        }
    }
}
