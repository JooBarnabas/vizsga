using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;

namespace _25_100_panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid sajatRacs = new Grid();

        public MainWindow()
        {
            InitializeComponent();

            urlapGeneralas();
        }

        private void urlapGeneralas()
        {
            ablak.Width = 600;
            ablak.Height = 500;
            ablak.Title = "Mátrix";

            //  sajatRacs.ShowGridLines = true;

            for (int i = 0; i < 10; i++)
            {
                ColumnDefinition oszlop = new ColumnDefinition();
                oszlop.Width = new GridLength(1, GridUnitType.Star);
                sajatRacs.ColumnDefinitions.Add(oszlop);

                RowDefinition sor = new RowDefinition();
                sor.Height = new GridLength(1, GridUnitType.Star);
                sajatRacs.RowDefinitions.Add(sor);
            }

            ColumnDefinition utolso_oszlop = new ColumnDefinition();
            utolso_oszlop.Width = new GridLength(100, GridUnitType.Pixel);
            sajatRacs.ColumnDefinitions.Add(utolso_oszlop);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Border keret = new Border();
                    keret.Background = Brushes.Blue;
                    keret.Margin = new Thickness(1);
                    keret.Name = "k_" + i + "_" + j;
                    keret.MouseDown += new MouseButtonEventHandler(gombKattintas);

                    Grid.SetRow(keret, i);
                    Grid.SetColumn(keret, j);

                    sajatRacs.Children.Add(keret);
                }
            }

            Button gombReset = new Button();
            gombReset.Content = "RESET";
            gombReset.Margin = new Thickness(5);
            gombReset.Padding = new Thickness(5);
            gombReset.Name = "BTN_Reset";
            gombReset.Click += new RoutedEventHandler(gombKattintas);

            Grid.SetRow(gombReset, 0);
            Grid.SetColumn(gombReset, 10);

            sajatRacs.Children.Add(gombReset);


            ablak.Content = sajatRacs;
        }

        private void gombKattintas(object sender, RoutedEventArgs e)
        {
            if (sender is Border)
            {
                Border b = sender as Border;
                //b.Background = Brushes.Red;

                string[] koordinata = b.Name.Split('_');
                int sor = int.Parse(koordinata[1]);
                int oszlop = int.Parse(koordinata[2]);

                var sg = sajatRacs.Children;

                for (int i = 0; i < 10; i++)
                {
                    // sor
                    string nev = "k_" + sor + "_" + i;
                    var k = (from x in sg.OfType<Border>()
                             where x.Name == nev
                             select x).SingleOrDefault();
                    if (k.Background == Brushes.Red)
                    {
                        k.Background = Brushes.Blue;
                    }
                    else
                    {
                        k.Background = Brushes.Red;
                    }

                    // oszlop
                    if (i != sor)
                    {
                        nev = "k_" + i + "_" + oszlop;
                        k = (from x in sg.OfType<Border>()
                             where x.Name == nev
                             select x).SingleOrDefault();
                        if (k.Background == Brushes.Red)
                        {
                            k.Background = Brushes.Blue;
                        }
                        else
                        {
                            k.Background = Brushes.Red;
                        }
                    }
                }
            }

            if (sender is Button)
            {
                var b = sender as Button;
                if (b.Name == "BTN_Reset")
                {
                    var sg = sajatRacs.Children;
                    for (int i = 0; i < 100; i++)
                    {
                        ((Border)sg[i]).Background = Brushes.Blue;
                    }
                }
            }
        }
    }
}