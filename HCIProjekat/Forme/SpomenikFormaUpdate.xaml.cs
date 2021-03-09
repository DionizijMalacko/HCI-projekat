using HCIProjekat.Modeli;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCIProjekat.Forme
{
    /// <summary>
    /// Interaction logic for SpomenikFormaUpdate.xaml
    /// </summary>
    public partial class SpomenikFormaUpdate : Window, INotifyPropertyChanged
    {
        private Spomenik stariSpomenik;

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


        private string comboKlima;
        public string ComboKlima
        {
            get
            {
                return comboKlima;
            }
            set
            {
                if (value != comboKlima)
                {
                    comboKlima = value;
                    OnPropertyChanged("ComboKlima");
                }
            }
        }

        private string comboStatus;
        public string ComboStatus
        {
            get
            {
                return comboStatus;
            }
            set
            {
                if (value != comboStatus)
                {
                    comboStatus = value;
                    OnPropertyChanged("ComboStatus");
                }
            }
        }

        private Tip tip;
        public Tip Tip
        {
            get
            {
                return tip;
            }
            set
            {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        private bool ugrozen;
        public bool Ugrozen
        {
            get
            {
                return ugrozen;
            }
            set
            {
                if (value != ugrozen)
                {
                    ugrozen = value;
                    OnPropertyChanged("Ugrozen");
                }
            }
        }

        private bool zivotinje;
        public bool Zivotinje
        {
            get
            {
                return zivotinje;
            }
            set
            {
                if (value != zivotinje)
                {
                    zivotinje = value;
                    OnPropertyChanged("Zivotinje");
                }
            }
        }

        private bool naseljen;
        public bool Naseljen
        {
            get
            {
                return naseljen;
            }
            set
            {
                if (value != naseljen)
                {
                    naseljen = value;
                    OnPropertyChanged("Naseljen");
                }
            }
        }

        // ____________________________________________

        private bool neUgrozen;
        public bool NeUgrozen
        {
            get
            {
                return neUgrozen;
            }
            set
            {
                if (value != neUgrozen)
                {
                    neUgrozen = value;
                    OnPropertyChanged("NeUgrozen");
                }
            }
        }

        private bool neZivotinje;
        public bool NeZivotinje
        {
            get
            {
                return neZivotinje;
            }
            set
            {
                if (value != neZivotinje)
                {
                    neZivotinje = value;
                    OnPropertyChanged("NeZivotinje");
                }
            }
        }

        private bool neNaseljen;
        public bool NeNaseljen
        {
            get
            {
                return neNaseljen;
            }
            set
            {
                if (value != neNaseljen)
                {
                    neNaseljen = value;
                    OnPropertyChanged("NeNaseljen");
                }
            }
        }

        // ____________________________________________

        private string slika;

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


        private double txtPrihod;
        public double TxtPrihod
        {
            get
            {
                return txtPrihod;
            }
            set
            {
                if (value != txtPrihod)
                {
                    txtPrihod = value;
                    OnPropertyChanged("TxtPrihod");
                }
            }
        }


        private DateTime txtDatum;

        public DateTime TxtDatum
        {
            get { return txtDatum; }
            set
            {
                if (value != txtDatum)
                {
                    txtDatum = value;
                    OnPropertyChanged("TxtDatum");
                }
            }
        }

        private ObservableCollection<Etiketa> etikete;
        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return etikete;
            }
            set
            {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }


        private string tip_string; //da bi ispisao tip u combobox
        public string Tip_string
        {
            get
            {
                return tip_string;
            }
            set
            {
                if (value != tip_string)
                {
                    tip_string = value;
                    OnPropertyChanged("Tip_string");
                }
            }
        }

        public ObservableCollection<string> Tipovi_oznake  //puni combobox sa imenima tipova
        {
            get
            {
                ObservableCollection<string> temp = new ObservableCollection<string>();
                foreach (Tip t in MainWindow.kolekcija.Tipovi)
                {
                    temp.Add(t.Id);
                }
                return temp;
            }
        }




        //strukture za punjenje listview-ova etiketa
        private ObservableCollection<string> etikete_oznake;
        public ObservableCollection<string> Etikete_oznake
        {
            get
            {
                return etikete_oznake;
            }
            set
            {
                if (value != etikete_oznake)
                {
                    etikete_oznake = value;
                    OnPropertyChanged("Etikete_oznake");
                }
            }
        }

        private ObservableCollection<string> etikete_oznake_odabrane;
        public ObservableCollection<string> Etikete_oznake_odabrane
        {
            get
            {
                return etikete_oznake_odabrane;
            }
            set
            {
                if (value != etikete_oznake_odabrane)
                {
                    etikete_oznake_odabrane = value;
                    OnPropertyChanged("Etikete_oznake_odabrane");
                }
            }
        }
        //__________________________________________________________




        //kolekcije za pravljenje gotovih comboboxova
        public ObservableCollection<string> ComboKlimaK { get; set; }
        public ObservableCollection<string> ComboStatusK { get; set; }




        //konstruktor 
        public SpomenikFormaUpdate(Spomenik sp)
        {
            stariSpomenik = sp;

            ComboKlimaK = new ObservableCollection<string>();
            ComboKlimaK.Add("1. Polarna");
            ComboKlimaK.Add("2. Kontinentalna");
            ComboKlimaK.Add("3. Umereno-kontinentalna");
            ComboKlimaK.Add("4. Pustinjska");
            ComboKlimaK.Add("5. Suptropska");
            ComboKlimaK.Add("6. Tropska");

            ComboStatusK = new ObservableCollection<string>();
            ComboStatusK.Add("1. Eksploatisan");
            ComboStatusK.Add("2. Dostupan");
            ComboStatusK.Add("3. Nedostupan"); 
            

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            this.txtId = sp.Id;
            this.txtIme = sp.Ime;
            this.txtOpis = sp.Opis;
            this.txtDatum = sp.DatumOtkrivanja;
            this.txtPrihod = sp.Prihod;
            this.slika = sp.IkonicaPutanja;

            ikonica.Source = new BitmapImage(new Uri(slika));

            this.tip_string = sp.Tip;
            this.comboKlima = sp.Klima;
            this.comboStatus = sp.TuristickiStatus;

            this.etikete = sp.TagEtikete;

            this.ugrozen = sp.EkoloskaUgrozenost;
            this.zivotinje = sp.UgrozenihZivotinja;
            this.naseljen = sp.NaseljenRegion;

            this.neUgrozen = sp.EkoloskaUgrozenost.Equals(false);
            this.neZivotinje = sp.UgrozenihZivotinja.Equals(false);
            this.neNaseljen = sp.NaseljenRegion.Equals(false);

            etikete_oznake = new ObservableCollection<string>();
            etikete_oznake_odabrane = new ObservableCollection<string>();

            foreach (Etiketa e in etikete) //ubacivanje etiketa u listu odabranih/postojecih
            {
                etikete_oznake_odabrane.Add(e.Id);
            }

            foreach (Etiketa e in MainWindow.kolekcija.Etikete) //ubacivanje ostalih raspolozivih etiketa u listu etiketa
            {
                if (!etikete_oznake_odabrane.Contains(e.Id))
                {
                    etikete_oznake.Add(e.Id);
                }
            }

        }




        private void Button_Izaberi_Etiketu(object sender, RoutedEventArgs e)
        {
            if (listaEtiketa.SelectedValue != null)
            {
                foreach (Etiketa et in MainWindow.kolekcija.Etikete)
                {
                    if (et.Id.Equals(listaEtiketa.SelectedValue))
                    {
                        etikete.Add(et);
                    }
                }

                etikete_oznake_odabrane.Add((string)listaEtiketa.SelectedValue);
                etikete_oznake.Remove((string)listaEtiketa.SelectedValue);

            }
            else return;

        }

        private void Button_Izbaci_Etiketu(object sender, RoutedEventArgs e)
        {
            if (listaEtiketaOdabranih.SelectedValue != null)
            {
                int idx = -1;
                foreach (Etiketa et in etikete)
                {
                    if (et.Id.Equals(listaEtiketaOdabranih.SelectedValue))
                    {
                        idx = etikete.IndexOf(et);
                    }
                }
                etikete.RemoveAt(idx);


                etikete_oznake.Add((string)listaEtiketaOdabranih.SelectedValue);
                etikete_oznake_odabrane.Remove((string)listaEtiketaOdabranih.SelectedValue);
            }
            else return;
        }

        private void Button_Sacuvaj(object sender, RoutedEventArgs e)
        {

            if (txtId == null || txtId == "" || txtIme == "" || txtIme == null || cboxTip.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Niste uneli neophodne informacije!", "Izmena spomenika");
                return;
            }

            ComboKlima = cboxKlima.SelectedItem.ToString();

            ComboStatus = cboxStatus.SelectedItem.ToString();


            if (ugrozenDa.IsChecked == true)
            {
                ugrozen = true;
            }
            else ugrozen = false;

            if (zivotinjeDa.IsChecked == true)
            {
                zivotinje = true;
            }
            else zivotinje = false;

            if (naseljenDa.IsChecked == true)
            {
                naseljen = true;
            }
            else naseljen = false;


            txtDatum = (DateTime)datum.SelectedDate;

            if (slika == null)
            {
                foreach (Tip t in MainWindow.kolekcija.Tipovi)
                {
                    if (t.Id.Equals(cboxTip.SelectedItem))
                    {
                        slika = t.IkonicaPutanja;
                    }

                }

            }


            Spomenik temp = new Spomenik(txtId, txtIme, txtOpis, cboxTip.SelectedItem.ToString(), comboKlima, slika, ugrozen, comboStatus, zivotinje, naseljen, txtPrihod, txtDatum, etikete);


            foreach (Tip t in MainWindow.kolekcija.Tipovi)
            {
                if (t.Id.Equals(cboxTip.SelectedItem.ToString()))
                {
                    t.TipSpomenici.Add(temp);


                }

            }
            MainWindow.kolekcija.sacuvajTip();

            foreach (Tip t in MainWindow.kolekcija.Tipovi)
            {
                if (t.Id.Equals(stariSpomenik.Tip))
                {

                    t.TipSpomenici.Remove(stariSpomenik);
                }

            }

            MainWindow.kolekcija.sacuvajTip();

            int idx2 = -1;
            foreach (Spomenik spomenik in MainWindow.kolekcija.Spomenici)
            {
                if (spomenik.Id.Equals(temp.Id))
                {
                    idx2 = MainWindow.kolekcija.Spomenici.IndexOf(spomenik);
                }
            }


            MainWindow.kolekcija.Spomenici.RemoveAt(idx2);
            MainWindow.kolekcija.Spomenici.Add(temp);

            MainWindow.kolekcija.sacuvajSpomenik();
            System.Windows.MessageBox.Show("Uspešno dodavanje novog spomenika.", "Uspeh!");
            this.Close();

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
                slika = ikonica.Source.ToString();
            }
        }

        private void Button_Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}

