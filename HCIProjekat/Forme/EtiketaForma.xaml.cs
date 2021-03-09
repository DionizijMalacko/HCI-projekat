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

namespace HCIProjekat.Forme
{
    /// <summary>
    /// Interaction logic for EtiketaInter.xaml
    /// </summary>
    public partial class EtiketaForma : Window
    {
        
        /*
        private Kolekcija kolekcije;
        private bool unos = false; */

        private string txtId;
        private Color txtBoja;
        private String txtOpis;

        public EtiketaForma()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;


            this.DataContext = this;
        }

        /*
        public EtiketaForma(Etiketa etiketa)
        {
            InitializeComponent();
            this.DataContext = this;
            this.id.IsReadOnly = true;

            kolekcije = Kolekcija.Instance;

            txtId = etiketa.Id;
            txtOpis = etiketa.Opis;
            txtBoja = etiketa.Boja;
            this.Title = "Izmena etikete";

        } */

        private void Button_Sacuvaj(object sender, RoutedEventArgs e)
        {
            if (!(txtBoja.R == 0 && txtBoja.B == 0 && txtBoja.G == 0 && txtBoja.A == 0) && txtId != null)
            {
                Etiketa etiketa = new Etiketa(txtId, txtBoja, txtOpis);
                bool passed = MainWindow.kolekcija.dodajEtiketu(etiketa);
                if (passed)
                {
                    System.Windows.MessageBox.Show("Uspešno dodavanje nove etikete.", "Uspeh!");
                    MainWindow.kolekcija.sacuvajEtiketu();
                    this.Close();
                }
                else
                    System.Windows.MessageBox.Show("Vec postoji etiketa sa tom oznakom!", "Greska!");
            }
            else
                System.Windows.MessageBox.Show("Unesite boju etikete i popunite obavezna polja!", "Greska!");
        }

        /*
        private bool proveraUnosa()
        {
            bool retVal = false;

            BindingExpression beId = this.Id.GetBindingExpression(TextBox.TextProperty);
            BindingExpression beOpis = this.txtOpis.GetBindingExpression(TextBox.TextProperty);

            beId.UpdateSource();
            beOpis.UpdateSource();

            if (beId.HasError || beOpis.HasError || colorPicker.SelectedColor == null)
            {
                retVal = true;
            }

            return retVal;
        } */

        private void Button_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public string TxtId
        {
            get
            {
                return this.txtId;
            }
            set
            {
                this.txtId = value;
            }
        }

        public Color TxtBoja
        {
            get
            {
                return this.txtBoja;
            }
            set
            {
                    this.txtBoja = value;
            }
        }

        public String TxtOpis
        {
            get
            {
                return this.txtOpis;
            }
            set
            {
                this.txtOpis = value;
            }
        }

        private void colorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            System.Windows.Media.Color mediacolor = colorPicker.SelectedColor.Value;
            txtBoja = Color.FromArgb(mediacolor.A, mediacolor.R, mediacolor.G, mediacolor.B);
        }

        /*
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        } */

    }
}

