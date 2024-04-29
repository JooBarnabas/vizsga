using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_object_binding
{
    public class Ember : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public string nev { get; set; }

        private string _nev;

        public string nev
        {
            get { return _nev; }
            set { _nev = value; OnPropertyChanged("nev"); }
        }

        //public int eletkor { get; set; }
        private int _eletkor;

        public int eletkor
        {
            get { return _eletkor; }
            set { _eletkor = value; OnPropertyChanged("eletkor"); }
        }

        // public string varos { get; set; }
        private string _varos;

        public string varos
        {
            get { return _varos; }
            set { _varos = value; OnPropertyChanged("varos"); }
        }


        public Ember()
        {
            this.nev = "Béla";
            this.eletkor = 30;
            this.varos = "Győr";
        }

        
    }
}
