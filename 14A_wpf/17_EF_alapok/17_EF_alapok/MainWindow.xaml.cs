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

using Microsoft.EntityFrameworkCore;

namespace _17_EF_alapok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeesContext employeesContext = new EmployeesContext();

        public MainWindow()
        {
            InitializeComponent();

            employeesContext.People.Load();
            DG_adatok.ItemsSource = employeesContext.People.Local.ToObservableCollection();
            
        }
    }
}
