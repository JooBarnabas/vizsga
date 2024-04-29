using RealEstateGUI.Models;
using System.Text;
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

namespace RealEstateGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        IngatlanContext context = new IngatlanContext();

        public MainWindow()
        {
            InitializeComponent();

            context.Sellers.Load();
            context.Realestates.Load();

            this.DataContext = context.Sellers.Local.ToObservableCollection();
        }

        private void BTN_hirdetesekBetoltese_Click(object sender, RoutedEventArgs e)
        {
            LB_hirdetesekSzama.Content = (from r in context.Realestates.Local
                                          where r.SellerId == ((Seller)LBO_sellers.SelectedItem).Id
                                          select r
                                            ).Count();

            // var lista = context.Realestates.Local.ToObservableCollection();

        }
    }
}


// Scaffold-DbContext "Server=localhost;Database=ingatlan;Uid=root;Pwd=;" Pomelo.EntityFrameworkCore.MySql -OutputDir Models

