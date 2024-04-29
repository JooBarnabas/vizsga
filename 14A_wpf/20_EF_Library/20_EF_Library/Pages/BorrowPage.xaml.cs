using _20_EF_Library.Models;
using Microsoft.EntityFrameworkCore;
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

namespace _20_EF_Library.Pages
{
    /// <summary>
    /// Interaction logic for BorrowPage.xaml
    /// </summary>
    public partial class BorrowPage : Page
    {

        _14aLibraryContext context = new _14aLibraryContext();

        public BorrowPage()
        {
            InitializeComponent();

            context.Students.Load();
            context.Borrows.Load();
            context.Books.Load();
            context.Authors.Load();

            CBO_osztaly.ItemsSource = (from o in context.Students
                                      select o.Class).ToList().Distinct().OrderBy(x => x);
            CBO_osztaly.SelectedIndex = 0;
        }

        private void CBO_osztaly_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tanuloSzures();
        }

        private void TB_kereses_TextChanged(object sender, TextChangedEventArgs e)
        {
            tanuloSzures();
        }

        private void LB_tanulok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_tanulok.SelectedItem != null)
            {
                konySzures();
            } else
            {
                LB_kolcsonzottKonyvek.ItemsSource = null;
            }
        }

        private void konySzures()
        {
            var konyvLista = (from k in context.Borrows
                              where k.StudentId == ((Student)LB_tanulok.SelectedItem).StudentId
                              select new
                              {
                                  k.BorrowId,
                                  k.Book.Name,
                                  k.Book.Author.Fullname,
                                  datum = string.Format("{0:yyyy.MM.dd} - {1:yyyy.MM.dd}", k.TakenDate, k.BroughtDate)
                              }).ToList();
            LB_kolcsonzottKonyvek.ItemsSource = konyvLista;
        }

        private void tanuloSzures()
        {
            var tanuloLista = (from t in context.Students
                               where t.Class == (string)CBO_osztaly.SelectedItem && 
                                (t.Name.Contains(TB_kereses.Text) || t.Surname.Contains(TB_kereses.Text))
                               orderby t.Name, t.Surname
                               select t).ToList();

            LB_tanulok.ItemsSource = tanuloLista;
        }

        
    }
}
