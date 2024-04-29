using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace _11_wpf_book
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Book> books = new List<Book>();
        List<string?> languages = new List<string?>();

        ICollectionView filteredBooks;


        public MainWindow()
        {
            InitializeComponent();
            loadBooks();
            getLanguages();

            filteredBooks = CollectionViewSource.GetDefaultView(books);

            CBO_languages.ItemsSource = languages;
            CBO_languages.SelectedIndex = 0;

            LBO_books.ItemsSource = filteredBooks;

            this.DataContext = books;
        }

        private void getLanguages()
        {
            languages = books.Select(b => b.Language).Distinct().ToList();
            languages.Sort();
            //foreach (var book in books)
            //{
            //    if (!languages.Contains(book.Language)) languages.Add(book.Language);
            //}
        }

        private void loadBooks()
        {
            foreach (var book in File.ReadAllLines("books.csv").Skip(1)) {
                books.Add(new Book(book));
            }
        }

        private void CBO_languages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filteredBooks.Filter = (object obj) =>
            {
                Book book = (Book)obj;
                if (book != null)
                {
                    return book.Language == CBO_languages.SelectedItem.ToString();
                }
                return false;
            };
        }

       

        private void HL_wiki_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
        }
    }
}
