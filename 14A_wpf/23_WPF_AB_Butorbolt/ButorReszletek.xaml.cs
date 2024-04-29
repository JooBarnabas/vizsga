using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using _23_WPF_AB_Butorbolt.Models;

namespace _23_WPF_AB_Butorbolt
{
    /// <summary>
    /// Interaction logic for ButorReszletek.xaml
    /// </summary>
    public partial class ButorReszletek : Window
    {
        public ButorModel BModel { get; private set; }
        List<AlapanyagModel> alapanyagok = new List<AlapanyagModel>();

        int id = 0;

        public ButorReszletek(ButorModel model)
        {
            InitializeComponent();
            BModel = model;
            this.DataContext = BModel;
            id = model.id;

            alapanyagok = AlapanyagModel.select();
            CBO_alapanyag.ItemsSource = alapanyagok;
        }

        private void BTN_OK_Click(object sender, RoutedEventArgs e)
        {
            if (id==0)
            {
                // insert rekord
                this.BModel.id = ButorModel.insert(this.BModel);
            }
            else
            {
                // update rekord
                ButorModel.update(this.BModel);
            }
            DialogResult = true;
            Close();
        }

        private void BTN_Megse_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
