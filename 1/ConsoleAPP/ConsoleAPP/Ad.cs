using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPP
{
    public class Ad
    {
        // id;rooms;latlong;floors;area;description;freeOfCharge;imageUrl;createAt;sellerId;sellerName;sellerPhone;categoryId;categoryName

        public int Id { get; set; }
        public int Rooms { get; set; }
       // public string LatLong { get; set; }
        public int Floors { get; set; }
        public int Area { get; set; }
        public string Description { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; }
        public Seller Seller { get; set; }

        private double lat { set; get; }
        private double lon { get; set; }

        public string LatLong
        {
            get
            {
                return String.Format($"{this.lat},{this.lon}");
            }
            set
            {
                this.lat = Convert.ToDouble(value.Split(',')[0].Replace(".",","));
                this.lon = Convert.ToDouble(value.Split(',')[1].Replace(".", ","));
            }
        }

        public Ad(string row)
        {
            string[] data = row.Split(';');
            this.Id = Convert.ToInt32(data[0]);
            this.Rooms = Convert.ToInt32(data[1]);
            this.LatLong = data[2];
            this.Floors = Convert.ToInt32(data[3]);
            this.Area = Convert.ToInt32(data[4]);
            this.Description = data[5];
            this.FreeOfCharge = data[6] == "1";
            this.ImageUrl = data[7];
            this.CreatedAt = Convert.ToDateTime(data[8]);

            this.Seller = new Seller() { Id = Convert.ToInt32(data[9]), Name = data[10], Phone = data[11] };
            this.Category = new Category() { Id = Convert.ToInt32(data[12]), Name = data[13] };

            
        }

        public static List<Ad> LoadFromCsv(string fileName)
        {
            List<Ad> adList = new List<Ad>();

            foreach (string row in File.ReadLines(fileName).ToList().Skip(1))
            {
                adList.Add(new Ad(row));
            }

            return adList;
        }
        //public static IEnumerable<Ad> LoadFromCsv(string fileName)
        //{
        //    foreach (string row in File.ReadLines(fileName).ToList().Skip(1))
        //    {
        //        yield return new Ad(row);
        //    }
        //}

        public double DistanceTo(double lat, double lon) {

            double dx = Math.Abs(lat - this.lat);
            double dy = Math.Abs(lon - this.lon);

            return Math.Sqrt(Math.Pow(dx,2) + Math.Pow(dy,2));
        }
    }
}
