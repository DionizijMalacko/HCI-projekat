using Microsoft.Win32;
using HCIProjekat.Modeli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace HCIProjekat.Forme
{
    
    public partial class TipForma : Window, INotifyPropertyChanged
    {

        /*
        private Kolekcija kolekcija;
        private bool unos = false; */


        private string txtId;
        public string TxtId
        {
            get
            {
                return txtId;
            }
            set
            {
                if (value != txtId)
                {
                    txtId = value;
                    OnPropertyChanged("TxtId");
                }
            }
        }
        private string txtIme;

        public string TxtIme
        {
            get
            {
                return txtIme;
            }
            set
            {
                if (value != txtIme)
                {
                    txtIme = value;
                    OnPropertyChanged("TxtIme");
                }
            }
        }


        private string txtIkonicaPutanja = null;

        public string TxtIkonicaPutanja
        {
            get { return txtIkonicaPutanja; }
            set { txtIkonicaPutanja = value; }

        }


        private string txtOpis;

        public string TxtOpis
        {
            get
            {
                return txtOpis;
            }
            set
            {
                if (value != txtOpis)
                {
                    txtOpis = value;
                    OnPropertyChanged("TxtOpis");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }


        public TipForma()
        {
            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Sacuvaj(object sender, RoutedEventArgs e)
        {
            if (txtIkonicaPutanja != null && txtId != null && txtIme != null)
            {
                ObservableCollection<Spomenik> spomeniciTipa = new ObservableCollection<Spomenik>();
                Tip tip = new Tip(txtId, txtIme, txtOpis, txtIkonicaPutanja, spomeniciTipa);
                bool passed = MainWindow.kolekcija.dodajTip(tip);
                if (passed)
                {
                    System.Windows.MessageBox.Show("Uspešno dodavanje novog tipa.", "Uspeh!");
                    MainWindow.kolekcija.sacuvajTip();
                    this.Close();
                }
                else
                    System.Windows.MessageBox.Show("Vec postoji tip sa tom oznakom!", "Greska!");
            }
            else
                System.Windows.MessageBox.Show("Unesite ikonicu tipa i obavezna polja!", "Greska!");
        }

        private void Button_Izaberi_Ikonicu(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();


            fileDialog.Title = "Izaberi ikonicu";
            fileDialog.Filter = "Images|*.jpg;*.jpeg;*.png|" +
                                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                "Portable Network Graphic (*.png)|*.png";
            if (fileDialog.ShowDialog() == true)
            {
                ikonica.Source = new BitmapImage(new Uri(fileDialog.FileName));
                txtIkonicaPutanja = fileDialog.FileName;
            }
        }

    }
}
