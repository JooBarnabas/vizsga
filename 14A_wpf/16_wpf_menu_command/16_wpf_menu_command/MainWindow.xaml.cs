using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace _16_wpf_menu_command
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

        private void CMD_open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog megnyitas = new OpenFileDialog();
            megnyitas.Filter = "Szöveg fájl (*.txt)|*.txt|CSV fájl (*.csv)|*.csv";
            megnyitas.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (megnyitas.ShowDialog() == true)
            {
                TB_szoveg.Text = File.ReadAllText(megnyitas.FileName);
            }
        }

        private void CMD_open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute =true;
        }

        private void CMD_save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog mentes = new SaveFileDialog();
            mentes.Filter = "Szöveg fájl (*.txt)|*.txt|CSV fájl (*.csv)|*.csv";
            mentes.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (mentes.ShowDialog() == true)
            {
                File.WriteAllText(mentes.FileName, TB_szoveg.Text);
            }
        }

        private void CMD_save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (TB_szoveg != null)
            {
                if (string.IsNullOrEmpty(TB_szoveg.Text))
                {
                    e.CanExecute =false;
                } else
                {
                    e.CanExecute =true;
                }
            }
        }

        private void CMD_kilepes_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void CMD_kilepes_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute=true;
        }
    }
}
