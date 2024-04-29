using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;
using System.Configuration;

using _23_WPF_AB_Butorbolt.Models;

namespace _23_WPF_AB_Butorbolt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ButorModel> butorok = new List<ButorModel>();
        List<AlapanyagModel> alapanyagok = new List<AlapanyagModel>();

        public MainWindow()
        {
            InitializeComponent();
           //  string connectionString = "Server=localhost;Database=butorbolt;Uid=root;Pwd=;";
            //MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            //MySqlCommand cmd = new MySqlCommand("select * from butor where id=3",con);
            //con.Open();
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //con.Close();

            butorok = ButorModel.select(null,"");
            DG_adatok.ItemsSource = butorok;

            alapanyagok = AlapanyagModel.select();
            alapanyagok.Insert(0, new AlapanyagModel(null, "Összes alapanyag"));
            CBO_alapanyag.ItemsSource = alapanyagok;
            CBO_alapanyag.SelectedIndex = 0;
        }

        private void BTN_kereses_Click(object sender, RoutedEventArgs e)
        {
            butorok = ButorModel.select((int?)CBO_alapanyag.SelectedValue, TB_megnevezes.Text);
            DG_adatok.ItemsSource = butorok;
        }

        private void BTN_uj_Click(object sender, RoutedEventArgs e)
        {
            ButorModel uj = new ButorModel();
            var ablak = new ButorReszletek(uj);
            if (ablak.ShowDialog() == true)
            {
                // OK GOMB
                butorok = ButorModel.select(null, "");
                DG_adatok.ItemsSource = butorok;
            }

        }

        private void BTN_modosit_Click(object sender, RoutedEventArgs e)
        {
            if (DG_adatok.SelectedItem != null)
            {
                ButorModel modosit = (ButorModel)DG_adatok.SelectedItem;
                var ablak = new ButorReszletek(modosit);
                if (ablak.ShowDialog() == true)
                {
                    butorok = ButorModel.select(null, "");
                    DG_adatok.ItemsSource = butorok;
                }
            }
        }

        private void BTN_torol_Click(object sender, RoutedEventArgs e)
        {
            if (DG_adatok.SelectedItem != null)
            {
                ButorModel torles = (ButorModel)DG_adatok.SelectedItem;
                if (MessageBox.Show("Törölhető-e a kijelölt bútor? ("+torles.megnevezes+")","Törlés",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ButorModel.delete(torles);
                    butorok = ButorModel.select(null, "");
                    DG_adatok.ItemsSource = butorok;
                }
            }
        }
    }
}
