using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eszaki_kozephegyseg_kilatoi
{
    internal class ViewpointModel
    {
        public int id { get; set; }
        public string viewpointName { get; set; }
        public string mountain { get; set; }
        public double height { get; set; }
        public string description { get; set; }
        public DateOnly built { get; set; }
        public string imageUrl { get; set; }
        public int locationId { get; set; }

        public ViewpointModel(string sor)
        {
            string[] s = sor.Split(';');
            id = int.Parse(s[0]);
            viewpointName = s[1];
            mountain = s[2];
            if (s[3].Contains('.'))
            {
                height = double.Parse(s[3].Replace('.', ','));
            }
            else
            {
                height = double.Parse(s[3]);
            }
            description = s[4];
            built = DateOnly.Parse(s[5]);
            imageUrl = s[6];
            locationId = int.Parse(s[7]);
        }

        public static List<ViewpointModel> loadViewpoints(string filename)
        {
            List<ViewpointModel> viewpoints = new List<ViewpointModel>();
            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                viewpoints.Add(new ViewpointModel(item));
            }
            return viewpoints;
        }


    }
}
