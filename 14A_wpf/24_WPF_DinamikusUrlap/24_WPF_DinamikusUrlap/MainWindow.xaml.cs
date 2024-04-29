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

namespace _24_WPF_DinamikusUrlap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Grid sajatGrid = new Grid();

        public MainWindow()
        {
            InitializeComponent();

            ablak.Width = 400;
            ablak.Height = 400;
            ablak.Title = "Dinamikus űrlap";

            sajatGrid.ShowGridLines = true;

            ColumnDefinition oszlop1 = new ColumnDefinition();
            ColumnDefinition oszlop2 = new ColumnDefinition();
            ColumnDefinition oszlop3 = new ColumnDefinition();

            sajatGrid.ColumnDefinitions.Add(oszlop1);
            sajatGrid.ColumnDefinitions.Add(oszlop2);
            sajatGrid.ColumnDefinitions.Add(oszlop3);

            oszlop1.Width = new GridLength(100);
            oszlop2.Width = new GridLength(2, GridUnitType.Star);

            RowDefinition sor1 = new RowDefinition();
            RowDefinition sor2 = new RowDefinition();
            RowDefinition sor3 = new RowDefinition();

            sajatGrid.RowDefinitions.Add(sor1);
            sajatGrid.RowDefinitions.Add(sor2);
            sajatGrid.RowDefinitions.Add(sor3);

            sajatGrid.Background = Brushes.Yellow;

            // label
            Label cimke = new Label();
            cimke.Content = "Cimke";
            cimke.FontSize = 16;
            cimke.Name = "c1";

            Grid.SetRow(cimke, 0);
            Grid.SetColumn(cimke, 0);

            sajatGrid.Children.Add(cimke);

            // textbox
            TextBox tb1 = new TextBox();
            tb1.Width = 50;
            tb1.HorizontalAlignment = HorizontalAlignment.Left;
            tb1.VerticalAlignment = VerticalAlignment.Top;
            Grid.SetRow(tb1, 0);
            Grid.SetColumn(tb1 , 1);
            sajatGrid.Children.Add(tb1);

            // button
            Button gomb1 = new Button()
            {
                Content = "GOMB",
                Padding = new Thickness(5),
                Name = "gomb1"
            };
            gomb1.Click += new RoutedEventHandler(Gomb_kattintas);

            Grid.SetRow(gomb1, 1);
            Grid.SetColumn(gomb1, 1);
            sajatGrid.Children.Add(gomb1);

            ablak.Content = sajatGrid;
        }

        private void Gomb_kattintas(object sender, RoutedEventArgs e)
        {
            var sg = sajatGrid.Children;
            //var c = (Label)sg[0];
            //c.Content = "Valami";

            var c = (from x in sg.OfType<Label>()
                     where x.Name == "c1"
                     select x).SingleOrDefault();
            c.Content = "Valami";
            c.FontSize = 30;

            if (sender is Button)
            {
                string melyikGomb = (sender as Button).Name;
                MessageBox.Show(melyikGomb);
            }
        }
    }
}