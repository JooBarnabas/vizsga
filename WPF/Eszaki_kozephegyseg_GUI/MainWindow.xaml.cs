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
using Eszaki_kozephegyseg_GUI.Models;
using Microsoft.EntityFrameworkCore;

namespace Eszaki_kozephegyseg_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NcmviewpointsContext context = new NcmviewpointsContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Viewpoints.Load();
            context.Locations.Load();

            LB_hegyseggek.ItemsSource = context.Locations.Local.ToObservableCollection();
        }

        private void LB_hegyseggek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var kilatok = (from v in context.Viewpoints
                           where v.Location == LB_hegyseggek.SelectedIndex
                           orderby v.Height descending
                           select new { v.ViewpointName, v.Description, v.Mountain, v.Height, v.Built, v.ImageUrl }
               ).ToList();
            DG_kilatok.ItemsSource = kilatok;
        }
    }
}
