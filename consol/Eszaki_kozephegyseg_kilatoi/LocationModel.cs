using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eszaki_kozephegyseg_kilatoi
{
    internal class LocationModel
    {
        public int id { get; set; }
        public string location { get; set; }

        public LocationModel(string sor)
        {
            string[] s = sor.Split(';');
            id = int.Parse(s[0]);
            location = s[1];
        }


        public static List<LocationModel> loadLocations(string filename)
        {
            List<LocationModel> locations = new List<LocationModel>();
            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                locations.Add(new LocationModel(item));
            }
            return locations;
        }
    }
}
