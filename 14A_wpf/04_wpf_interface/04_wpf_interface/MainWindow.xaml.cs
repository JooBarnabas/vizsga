using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace _04_wpf_interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // List<IAlakzat> alakzatok = new List<IAlakzat>();
       public ObservableCollection<IAlakzat> alakzatok { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            alakzatok = new ObservableCollection<IAlakzat>();
            this.DataContext = alakzatok;

            TB_sugar.Focus();
        }

        private void CBO_melyik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SP_kor == null || SP_negyzet == null)
            {
                return;
            }
            var melyik = ((ComboBoxItem)CBO_melyik.SelectedItem).Content.ToString();

            if (melyik == "Kör")
            {
                SP_kor.Visibility = Visibility.Visible;
                SP_negyzet.Visibility = Visibility.Hidden;
            }
            else
            {
                SP_kor.Visibility = Visibility.Collapsed;
                SP_negyzet.Visibility = Visibility.Visible;
            }
        }

        private void ButtonHozzaad(object sender, RoutedEventArgs e)
        {
            hozzaadAlakzat();
        }

        private void hozzaadAlakzat()
        {
            TBL_hiba.Text = "";
            var melyik = ((ComboBoxItem)CBO_melyik.SelectedItem).Content.ToString();

            try
            {
                if (melyik == "Kör")
                {
                    if (!double.TryParse(TB_sugar.Text, out double s))
                    {
                        // hiba üzenet
                        TBL_hiba.Text = "Csak szám lehet!";
                    }
                    else
                    {
                        alakzatok.Add(new Kor(double.Parse(TB_sugar.Text)));
                    }
                }
                else
                {
                    if (!double.TryParse(TB_oldal.Text, out double o))
                    {
                        TBL_hiba.Text = "Csak szám lehet!";
                    }
                    else
                    {
                        alakzatok.Add(new Negyzet(double.Parse(TB_oldal.Text)));
                    }
                }

            } catch(Exception ex) {
                TBL_hiba.Text = ex.Message;
            }


           // listboxFrissites();
        }

        //private void listboxFrissites()
        //{
        //    LBO_alakzatok.Items.Clear();
        //    foreach (var alakzat in alakzatok)
        //    {
        //        if (alakzat is Kor)
        //        {
        //            LBO_alakzatok.Items.Add($"Kör, sugár: {((Kor)alakzat).sugar}");
        //        }
        //        else
        //        {
        //            LBO_alakzatok.Items.Add($"Négyzet, oldal: {((Negyzet)alakzat).oldal}");
        //        }
        //    }

        //}

        //private void LBO_alakzatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var index = LBO_alakzatok.SelectedIndex;
        //    if (index == -1)
        //    {
        //        // nincs kiválasztva semmi
        //        LB_alakzat.Content = "";
        //        LB_kerulet.Content = string.Empty;
        //        LB_terulet.Content = string.Empty;
        //        LB_oldalakSzama.Content = string.Empty;
        //    }
        //    else
        //    {
        //        LB_alakzat.Content = $"Alakzat: {alakzatok[index].nev}";
        //        LB_kerulet.Content = $"Kerület: {alakzatok[index].kerulet}";
        //        LB_terulet.Content = $"Kerület: {alakzatok[index].kerulet}";
        //        LB_oldalakSzama.Content = $"Oldalak száma: {alakzatok[index].oldalakSzama}";
        //    }
        //}

        private void Enter_KeyUp(object sender, KeyEventArgs e)
        {
            // Debug.WriteLine(e.Key);
            if (e.Key == Key.Enter)
            {
                hozzaadAlakzat();
            }
        }


    }
}
