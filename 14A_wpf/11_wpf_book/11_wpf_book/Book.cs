using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_wpf_book
{
    // Title;Author;RealYears;Year;Country;Language;Pages;ImageName;WikipediaLink

    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? TitRealYearsle { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public string? Language { get; set; }
        public int Pages { get; set; }
        public string? ImageName { get; set; }
        public string? WikipediaLink { get; set; }

        public string imgSource { get { return string.Format("/image/{0}", ImageName); } }

        public Book(string row) {
            string[] data = row.Split(';');
            Title = data[0];
            Author = data[1];
            TitRealYearsle = data[2];
            Year = int.Parse(data[3]);
            Country = data[4];
            Language = data[5];
            Pages = int.Parse(data[6]);
            ImageName = data[7];
            WikipediaLink = data[8];
        }
    }
}
