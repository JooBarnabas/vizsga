using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace _08_wpf_evfolyam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tanulo> tanulok = new List<Tanulo>();
        List<string> osztalyok = new List<string>();
        List<string> jegyek = new List<string>() {"-","1", "2", "3", "4", "5"};

        ICollectionView sajatNezet;

        public MainWindow()
        {
            InitializeComponent();
            adatokBeolvasasa();
            osztalyokKigyujtese();

            sajatNezet = CollectionViewSource.GetDefaultView(tanulok);
            this.DataContext = sajatNezet;

            CBO_matematika.ItemsSource = jegyek;
            CBO_angol.ItemsSource = jegyek;
            CBO_nemet.ItemsSource = jegyek;
            CBO_informatika.ItemsSource = jegyek;

            CBO_osztalyok.ItemsSource = osztalyok;
            CBO_osztalyok.SelectedIndex = 0;
        }

        private void adatokBeolvasasa()
        {
            foreach (var sor in File.ReadAllLines("evfolyam.csv").Skip(1)) {
                tanulok.Add(new Tanulo(sor));
            }
        }

        private void osztalyokKigyujtese()
        {
            foreach (var egyTanulo in tanulok)
            {
                if (!osztalyok.Contains(egyTanulo.osztaly)) osztalyok.Add(egyTanulo.osztaly);
            }
            osztalyok.Sort();
        }

        private void CBO_osztalyok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sajatNezet.Filter = oszalySzuro;
        }

        private bool oszalySzuro(object obj)
        {
           Tanulo tanulo = obj as Tanulo;
            if (tanulo != null)
            {
                return tanulo.osztaly == CBO_osztalyok.SelectedItem.ToString();
            }
            return false;
        }
    }
}
