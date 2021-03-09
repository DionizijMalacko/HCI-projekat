using HCIProjekat.Modeli;
using Microsoft.Win32;
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

namespace HCIProjekat.Forme
{
    /// <summary>
    /// Interaction logic for TipFormaUpdate.xaml
    /// </summary>
    public partial class TipFormaUpdate : Window, INotifyPropertyChanged
    {
        public Tip stariTip;

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


        private string slika = null;
        public string Slika
        {
            get { return slika; }
            set
            {
                if (value != slika)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
                }
            }

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

        public TipFormaUpdate(Tip tip)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this;

            stariTip = tip;

            TxtId = tip.Id;
            TxtOpis = tip.Opis;
            TxtIme = tip.Ime;
            Slika = tip.IkonicaPutanja;

            ikonica.Source = new BitmapImage(new Uri(tip.IkonicaPutanja));
        }


        private void Button_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Sacuvaj(object sender, RoutedEventArgs e)
        {
            if (txtId != null && txtId != "" && txtIme != null && txtIme != "" && slika != null) //menjam spomenicima tip
            {
                foreach (Spomenik sp in stariTip.TipSpomenici)
                {
                    sp.Tip = txtId;
                }


                Tip temp = new Tip(txtId, txtIme, txtOpis, slika, stariTip.TipSpomenici);

                int idx = MainWindow.kolekcija.Tipovi.IndexOf(stariTip);
                MainWindow.kolekcija.Tipovi[idx] = temp;
                MainWindow.kolekcija.sacuvajTip();


                foreach (Spomenik sp in MainWindow.kolekcija.Spomenici) //prolazim kroz sve spomenike u kolekciji i menjam im tip
                {
                    if (sp.Tip.Equals(stariTip.Id))
                    {
                        sp.Tip = temp.Id;
                    }
                }

                MainWindow.kolekcija.sacuvajSpomenik();


                System.Windows.MessageBox.Show("Uspešna izmena tipa!", "Izmena tipa");
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Unesite obavezna polja!", "Greska");
            }
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
                slika = fileDialog.FileName;
            }
        }
    }
}
