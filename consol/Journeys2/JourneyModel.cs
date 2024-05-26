using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journeys2
{
    internal class JourneyModel
    {
        //id;vehicleid;vehicletype;country;description;departure;capacity;pictureUrl
        //5;1;repülőgép;Maldív szigetek; Képeslapra illő tengerpari villák, türkizkék tenger, vakítóan fehér homokos strandok, csodás naplementék írják le ezt a paradicsomi helyet.A Maldív-szigetek nagyon népszerű célpont a nászutasok körében, de a kalandot keresők is szívesen felfedezik a tenger szépségét egy könnyű búvárkodás, sznorkelezés vagy szörfözés alkalmával.A világ korallzátonyinak 5%-a itt található, rendkívül színes vízi élővilággal.Habár csak mintegy félmillió ember lakja, kultúrája mégis rendkívül változatos, köszönhetően a hódító népeknek. Az ország földrajzi elhelyezkedése miatt az emberek és kultúrák olvasztótégelye volt.A lakosság egyharmada él a sziget fővárosában, Malén, a többiek elszórtan a 200 szigeten. ;2022.04.13;164;http://vizsga2022.cluster.jedlik.eu/picture/maldives.jpg

        public int id { get; set; }
        public VehicleModel vehicle { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        public DateOnly departure { get; set; }
        public int capacity { get; set; }
        public string pictureUrl { get; set; }

        public JourneyModel(string sor)
        {
            string[] s = sor.Split(';');
            id = int.Parse(s[0]);
            vehicle = new VehicleModel{ id = int.Parse(s[1]), type = s[2] };
            country = s[3];
            description = s[4];
            departure = DateOnly.Parse(s[5]);
            if (s[6] == "")
            {
                s[6] = null;
            }
            else
            {
               capacity = int.Parse(s[6]); 
            }
            pictureUrl = s[7];
        }

        public static List<JourneyModel> LoadFromCsv(string filename)
        {
            List<JourneyModel> journeys = new List<JourneyModel>();
            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                journeys.Add(new JourneyModel(item));
            }
            return journeys;
        }
    }
}
