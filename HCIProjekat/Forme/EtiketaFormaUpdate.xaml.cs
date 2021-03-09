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
    /// Interaction logic for EtiketaFormaUpdate.xaml
    /// </summary>
    public partial class EtiketaFormaUpdate : Window, INotifyPropertyChanged
    {
        public Etiketa staraEtiketa;

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }

        }


        private string txtId;
        public string TxtId
        {
            get { return txtId; }
            set
            {
                if (value != txtId)
                {
                    txtId = value;
                    OnPropertyChanged("TxtId");
                }
            }
        }


        private Color txtBoja;

        public Color TxtBoja
        {
            get { return txtBoja; }
            set
            {
                if (value != txtBoja)
                {
                    txtBoja = value;
                    OnPropertyChanged("TxtBoja");
                }
            }
        }


        private string txtOpis;
        public string TxtOpis
        {
            get { return txtOpis; }
            set
            {
                if (value != txtOpis)
                {
                    txtOpis = value;
                    OnPropertyChanged("TxtOpis");
                }
            }
        }

        private Color mediacolor;
        public Color Mediacolor
        {
            get { return mediacolor; }
            set
            {
                if (value != mediacolor)
                {
                    mediacolor = value;
                    OnPropertyChanged("Mediacolor");
                }
            }
        }

        public EtiketaFormaUpdate(Etiketa etiketa)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = this;
            staraEtiketa = etiketa;
            TxtId = etiketa.Id;
            TxtOpis = etiketa.Opis;
            TxtBoja = etiketa.Boja;
            Mediacolor = System.Windows.Media.Color.FromArgb(txtBoja.A, txtBoja.R, txtBoja.G, txtBoja.B);

        }

        private void colorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            Mediacolor = colorPicker.SelectedColor.Value;
            TxtBoja = Color.FromArgb(mediacolor.A, mediacolor.R, mediacolor.G, mediacolor.B);

        }

        private void Button_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Sacuvaj(object sender, RoutedEventArgs e)
        {
            Etiketa temp = new Etiketa(txtId, txtBoja, txtOpis);

            int idx = MainWindow.kolekcija.Etikete.IndexOf(staraEtiketa);
            MainWindow.kolekcija.Etikete[idx] = temp;
            MainWindow.kolekcija.sacuvajEtiketu();

            foreach (Spomenik sp in MainWindow.kolekcija.Spomenici)  //ovim prolazim kroz sve spomenike u kolekciji i gde ima ta etiketa ja je menjam!
            {
                if (sp.TagEtikete.Contains(staraEtiketa))
                {
                    int idx2 = sp.TagEtikete.IndexOf(staraEtiketa);
                    sp.TagEtikete[idx2] = temp;
                }
            }
            MainWindow.kolekcija.sacuvajSpomenik();

            foreach (Tip t in MainWindow.kolekcija.Tipovi) //prolaz kroz sve tipove i menjanje u njihovim spomenicima!
            {
                foreach (Spomenik sp in t.TipSpomenici)
                {
                    if (sp.TagEtikete.Contains(staraEtiketa))
                    {
                        int idx3 = sp.TagEtikete.IndexOf(staraEtiketa);
                        sp.TagEtikete[idx3] = temp;
                    }
                }
            }
            MainWindow.kolekcija.sacuvajTip();


            System.Windows.MessageBox.Show("Uspešna izmena etikete!", "Izmena etikete");
            this.Close();

        }
    }
}

