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

namespace _01_wpf_teglalap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BTN_szamitas_Click(object sender, RoutedEventArgs e)
        {
            int aOldal;
            int bOldal;
            int kerulet;
            int terulet;

            if (int.TryParse(TB_aOldal.Text, out aOldal) && int.TryParse(TB_bOldal.Text, out bOldal))
            {
                LB_hibaUzenet.Content = "";
                terulet = aOldal * bOldal;
                kerulet = 2 * (aOldal + bOldal);

                LB_kerulet.Content = kerulet.ToString();
                LB_terulet.Content = terulet.ToString();
            }
            else
            {
                LB_hibaUzenet.Content = "Hibás adatok";
                LB_kerulet.Content = "";
                LB_terulet.Content = "";
            }
        }
    }
}
