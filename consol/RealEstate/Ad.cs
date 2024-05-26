using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Ad
    {

        //id;rooms;latlong;floors;area;description;freeOfCharge;imageUrl;createAt;sellerId;sellerName;sellerPhone;categoryId;categoryName
        //1;5;47.5410485803319,19.1516419487702;1;165;;0;https://drive.google.com/file/d/1qs5XyJNnnT_meJn_qVJLwASvY1By2bVj;2021-11-17;56;Fazekas Zoltán;+36 1 9929-8217;1;ház

        public int id { get; set; }
        public int rooms { get; set; }
        private double lat { set; get; }
        private double lon { get; set; }

        public string latlong
        {
            get
            {
                return String.Format($"{this.lat},{this.lon}");
            }
            set
            {
                this.lat = Convert.ToDouble(value.Split(',')[0].Replace(".", ","));
                this.lon = Convert.ToDouble(value.Split(',')[1].Replace(".", ","));
            }
        }
        public int floors { get; set; }
        public int area { get; set; }
        public string description { get; set; }
        public bool freeOfCharge { get; set; }
        public string imageUrl { get; set; }
        public DateTime createAt { get; set; }
        public Seller seller { get; set; }
        public Category category { get; set; }

        public Ad(string sor)
        {
            string[] m = sor.Split(';');
            id = int.Parse(m[0]);
            rooms = int.Parse(m[1]);
            latlong = m[2];
            floors = int.Parse(m[3]);
            area = int.Parse(m[4]);
            description = m[5];
            freeOfCharge = m[6] == "1";
            imageUrl = m[7];
            createAt = DateTime.Parse(m[8]);
            seller = new Seller { id = int.Parse(m[9]), name = m[10], phone = m[11] };
            category = new Category { id = int.Parse(m[12]), name = m[13] };
        }

        public static List<Ad> LoadFromCsv(string filename)
        {
            List<Ad> realestates = new List<Ad>();

            foreach (var item in File.ReadAllLines(filename).Skip(1))
            {
                realestates.Add(new Ad(item));
            }
            return realestates;
        }

        public double DistanceTo(double Lat, double Long)
        {
            double dx = Math.Abs(Lat - this.lat);
            double dy = Math.Abs(Long - this.lon);

            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }

    }
}
