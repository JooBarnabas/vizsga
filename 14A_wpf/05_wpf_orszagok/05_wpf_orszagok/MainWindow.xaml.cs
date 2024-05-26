using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _05_wpf_orszagok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Orszag> orszagok { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            orszagok = new ObservableCollection<Orszag>();
            beolvas();

            this.DataContext = orszagok;
        }

        private void beolvas()
        {
            string[] lista;
            lista = File.ReadAllLines("orszagok.csv");
            foreach (string line in lista)
            {
                orszagok.Add(new Orszag(line));
            }
        }
    }
}
