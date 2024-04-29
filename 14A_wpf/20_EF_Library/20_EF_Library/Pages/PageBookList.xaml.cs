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
using _20_EF_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace _20_EF_Library.Pages
{
    /// <summary>
    /// Interaction logic for PageBookList.xaml
    /// </summary>
    public partial class PageBookList : Page
    {
        _14aLibraryContext context = new _14aLibraryContext();

        public PageBookList()
        {
            InitializeComponent();

            context.Authors.Load();
            context.Types.Load();

            var a = context.Authors.Local.OrderBy(x => x.Fullname).ToList();
            a.Insert(0, new Author() { AuthorId = 0, Name = "Kérem válasszon" });
            CBO_szerzok.ItemsSource = a;
            CBO_szerzok.SelectedIndex = 0;

            var t = context.Types.Local.OrderBy(x => x.Name).ToList();
            t.Insert(0, new Types() { TypeId = 0, Name= "Kérem válasszon" });
            CBO_kategoriak.ItemsSource = t;
            CBO_kategoriak.SelectedIndex = 0;
        }

        private void BTN_kereses_Click(object sender, RoutedEventArgs e)
        {
            var szurtlista = (from b in context.Books select b);

            if (!string.IsNullOrEmpty(TB_cim.Text))
            {
                szurtlista = (from b in szurtlista
                              where b.Name.ToLower().Contains(TB_cim.Text.ToLower())
                              select b);
            }

            if (CBO_szerzok.SelectedIndex != 0)
            {
                szurtlista = (from b in szurtlista
                              where b.AuthorId == ((Author)CBO_szerzok.SelectedItem).AuthorId
                              select b);
            }

            if (CBO_kategoriak.SelectedIndex != 0)
            {
                szurtlista = (from b in szurtlista
                              where b.TypeId == ((Types)CBO_kategoriak.SelectedItem).TypeId
                              select b);
            }

            DG_konyvlista.ItemsSource = szurtlista.ToList();

        }
    }
}
