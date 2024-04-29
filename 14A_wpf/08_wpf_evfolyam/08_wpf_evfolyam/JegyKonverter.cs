using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _08_wpf_evfolyam
{
    public class JegyKonverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // változó -> űrlap
            int? jegy = (int?)value;
            if (jegy == null) { return "-"; } else { return jegy.ToString(); }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // űrlap -> változó
            string jegy = (string?)value;
            if (jegy == "-") { return null; } else { return int.Parse(jegy); }

        }
    }
}
