using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_wpf_interface
{
    public interface IAlakzat
    {
        public double kerulet { get; }
        public double terulet { get; }
        public string nev { get; }
        public int oldalakSzama { get; }
    }
}
