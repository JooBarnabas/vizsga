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

using _15_wpf_menu_pages.Pages;

namespace _15_wpf_menu_pages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FRM_nyito.Content = new NyitoPage();
        }

        private void MI_negyzet_Click(object sender, RoutedEventArgs e)
        {
            FRM_nyito.Content = new NegyzetPage();
        }

        private void MI_teglalap_Click(object sender, RoutedEventArgs e)
        {
            FRM_nyito.Content = new TeglalapPage();
        }

        private void MI_kor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
