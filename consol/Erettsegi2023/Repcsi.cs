using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erettsegi2023
{   internal class Sebessegkategoria
        {
            private int Utazosebesseg;
            public string Kategorianev
            {
                get
                {
                    if (Utazosebesseg < 500) return "Alacsony sebességű";
                    else if (Utazosebesseg < 1000) return "Szubszonikus";
                    else if (Utazosebesseg < 1200) return "Transzszonikus";
                    else return "Szuperszonikus";
                }
            }
            public Sebessegkategoria(int utazosebesseg)
            {
                Utazosebesseg = utazosebesseg;
            }
        }
    internal class Repcsi
    {
        //        típus;év;utas;személyzet;utazósebesség;felszállótömeg;fesztáv
        //        Airbus A300;1972;220-336;3;911;142000;44,84

        public string típus { get; set; }
        public int év { get; set; }
        public string utas { get; set; }
        public string személyzet { get; set; }
        public int Utazosebesseg { get; set; }
        public string SebKategoria { get; set; }
        public int felszállótömeg { get; set; }
        public double fesztáv { get; set; }

        public int max => utas.Contains('-') ? int.Parse(utas.Split('-')[1]) : int.Parse(utas);
        public int maxUtas { 
            get 
            { 
                if (utas.Contains('-')) { return int.Parse(utas.Split('-')[1]); }
                else return int.Parse(utas); 
            } 
        }

        public Repcsi(string sor)
        {
            string[] m = sor.Split(';');

            típus = m[0];
            év = int.Parse(m[1]);
            utas = m[2];
            személyzet = m[3];
            Utazosebesseg = int.Parse(m[4]);
            felszállótömeg = int.Parse(m[5]);
            fesztáv = double.Parse(m[6].Replace('.',','));
            SebKategoria = new Sebessegkategoria(Utazosebesseg).Kategorianev;
        }
    }
}
