using Microsoft.EntityFrameworkCore;
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

namespace _19_EF_TobbATobbKapcsolat
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

            //context.Add<Tanulo>(new Tanulo() { tanuloNev = "Józsi", szuletesiDatum = DateTime.Parse("2000.01.01") });
            //context.Add<Tanulo>(new Tanulo() { tanuloNev = "Béla", szuletesiDatum = DateTime.Parse("2001.11.01") });
            //context.Add<Tanulo>(new Tanulo() { tanuloNev = "Péter", szuletesiDatum = DateTime.Parse("2001.04.06") });
            //context.Add<Tanulo>(new Tanulo() { tanuloNev = "Rita", szuletesiDatum = DateTime.Parse("2002.05.01") });

            //context.Add<Teszt>(new Teszt() { tesztMegnevezes = "Prog. alapok" });
            //context.Add<Teszt>(new Teszt() { tesztMegnevezes = "Adatbázis kezelés" });
            //context.Add<Teszt>(new Teszt() { tesztMegnevezes = "EF haladó" });

            //context.SaveChanges();

            context.Tanulo.Load();
            context.Teszt.Load();
            context.TesztEredmenyek.Load();

            DG_eredmenyek.ItemsSource = context.TesztEredmenyek.Local.ToObservableCollection();

            CBO_tanulok.ItemsSource = context.Tanulo.Local.ToObservableCollection();
            CBO_tesztek.ItemsSource = context.Teszt.Local.ToObservableCollection();

            CBO_tanulok2.ItemsSource = context.Tanulo.Local.ToObservableCollection();
            CBO_teszt2.ItemsSource = context.Teszt.Local.ToObservableCollection();

        }

        private void BTN_mentes_Click(object sender, RoutedEventArgs e)
        {
            var tanulo = (Tanulo)CBO_tanulok.SelectedItem;
            var teszt = (Teszt)CBO_tesztek.SelectedItem;
            var eredmeny = int.Parse(CBO_eredmeny.Text);
            var idopont = DP_datum.SelectedDate;

            context.TesztEredmenyek.Add(new TesztEredmenyek() 
            {
                Tanulo = tanulo,
                Teszt = teszt,
                eredmeny=eredmeny,
                datum = (DateTime)idopont
            });

            context.SaveChanges();
        }

        private void CBO_tanulo2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lista = (
                         from t in context.Teszt
                         from te in t.tesztEredmenyek
                         where te.Tanulo.tanuloId == ((Tanulo)CBO_tanulok2.SelectedItem).tanuloId
                         select new { t.tesztMegnevezes, te.Tanulo.tanuloNev }
                         ).ToList();

            DG_lekerdezesTanulo.ItemsSource = lista;
        }

        private void CBO_teszt2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lista = (
                        from t in context.Tanulo
                        from te in t.tesztEredmenyek
                        where te.Teszt.tesztId == ((Teszt)CBO_teszt2.SelectedItem).tesztId
                        select new {t.tanuloNev, te.Teszt.tesztMegnevezes, te.datum, te.eredmeny}
                        ).ToList();
            DG_lekerdezesTeszt.ItemsSource = lista;
        }
    }
}
