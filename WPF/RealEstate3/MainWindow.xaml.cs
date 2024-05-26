using Microsoft.EntityFrameworkCore;
using RealEstate3.Models;
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

namespace RealEstate3
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
            context.Realestates.Load();
            context.Categories.Load();
            context.Sellers.Load();

            LB_names.ItemsSource = context.Sellers.Local.ToObservableCollection();

            this.DataContext = context.Sellers.Local.ToObservableCollection();
        }

        private void btn_loadAds_Click(object sender, RoutedEventArgs e)
        {
            lb_numberOfAds.Content = (from r in context.Realestates.Local where r.SellerId == ((Seller)LB_names.SelectedItem).Id select r).Count().ToString();
        }
    }
}
