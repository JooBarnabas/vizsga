using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;

namespace _18_EF_EgyATobbKapcsolat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IskolaContext context = new IskolaContext();

        public MainWindow()
        {
            InitializeComponent();

            //Osztaly osztaly = new Osztaly() {osztalyNev="14A", osztalyFonok="Nits László" };
            //context.Add<Osztaly>(osztaly);

            //osztaly = new Osztaly() {osztalyNev="11A", osztalyFonok="Balog Bence" };
            //context.Add<Osztaly>(osztaly);

            //context.SaveChanges();

            //Tanulo tanulo = new Tanulo() {tanuloNev="Béla",szuletesiDatum=DateTime.Parse("2000.01.01"),osztalyId=1 };
            //context.Add<Tanulo>(tanulo);

            //tanulo = new Tanulo() { tanuloNev = "Kata", szuletesiDatum = DateTime.Parse("2001.02.02"), osztalyId = 1 };
            //context.Add<Tanulo>(tanulo);

            //tanulo = new Tanulo() { tanuloNev = "Józsi", szuletesiDatum = DateTime.Parse("2002.02.02"), osztalyId = 2 };
            //context.Add<Tanulo>(tanulo);

            //context.SaveChanges();

            context.Tanulo.Load(); // select * from tanulo
            context.Osztaly.Load();

            DG_tanulok.ItemsSource = context.Tanulo.Local.ToObservableCollection();

            DG_osztaly.ItemsSource = context.Osztaly.Local.ToObservableCollection();

            // var osszesTanulo = (from t in context.Tanulo select t).ToList();

            //var osszesTanulo = (from t in context.Tanulo 
            //                    select new {t.tanuloNev, t.szuletesiDatum, t.Osztaly.osztalyNev }
            //                    ).ToList();

            var osszesTanulo = (from t in context.Tanulo
                                where t.Osztaly.osztalyNev == "14A"
                                select new { t.tanuloNev, t.szuletesiDatum, t.Osztaly.osztalyNev }
                                ).ToList();

            DG_lekerdezes.ItemsSource = osszesTanulo;


            var o = context.Osztaly.Local.OrderBy(x => x.osztalyNev).ToList();
            o.Insert(0, new Osztaly() { osztalyId = 0, osztalyNev = "Kérem válasszon!" });
            CBO_osztalyok.SelectedIndex = 0;
            CBO_osztalyok.ItemsSource = o;

        }

        private void CBO_osztalyok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tanulok = (from t in context.Tanulo
                           where t.Osztaly.osztalyNev == ((Osztaly)CBO_osztalyok.SelectedItem).osztalyNev
                           select new { t.tanuloNev, t.szuletesiDatum, t.Osztaly.osztalyNev }
                           ).ToList();
            DG_lista.ItemsSource = tanulok;
        }
    }
}
