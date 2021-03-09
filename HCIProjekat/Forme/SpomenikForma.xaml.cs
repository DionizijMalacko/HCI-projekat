using HCIProjekat.Modeli;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static HCIProjekat.Modeli.Spomenik;


//--< using >--
using Microsoft.Win32;
//--< using >>--

namespace HCIProjekat.Forme

{

    public partial class SpomenikForma : Window, INotifyPropertyChanged
    {
        //lokalne promenljive i getteri/setteri

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

        private Tip comboTip;
        public Tip ComboTip
        {
            get
            {
                return comboTip;
            }
            set
            {
                if (value != comboTip)
                {
                    comboTip = value;
                    OnPropertyChanged("ComboTip");
                }
            }
        }

        public ObservableCollection<string> Tipovi_oznake
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

        private string txtIkonicaPutanja;

        public string TxtIkonicaPutanja
        {
            get { return txtIkonicaPutanja; }
            set
            {
                if (value != txtIkonicaPutanja)
                {
                    txtIkonicaPutanja = value;
                    OnPropertyChanged("TxtIkonicaPutanja");
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

        private string lista_Etiketa;
        public string Lista_Etiketa
        {
            get { return lista_Etiketa; }
            set
            {
                if (value != lista_Etiketa)
                {
                    lista_Etiketa = value;
                    OnPropertyChanged("Lista_Etiketa");
                }
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


        public ObservableCollection<string> ComboKlima { get; set; }
        public ObservableCollection<string> ComboStatus { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public SpomenikForma()
        {
            ComboKlima = new ObservableCollection<string>();
            ComboKlima.Add("1. Polarna");
            ComboKlima.Add("2. Kontinentalna");
            ComboKlima.Add("3. Umereno-kontinentalna");
            ComboKlima.Add("4. Pustinjska");
            ComboKlima.Add("5. Suptropska");
            ComboKlima.Add("6. Tropska");

            

            ComboStatus = new ObservableCollection<string>();
            ComboStatus.Add("1. Eksploatisan");
            ComboStatus.Add("2. Dostupan");
            ComboStatus.Add("3. Nedostupan");


            etikete = new ObservableCollection<Etiketa>();

            etikete_oznake = new ObservableCollection<string>();
            etikete_oznake_odabrane = new ObservableCollection<string>();

            foreach (Etiketa e in MainWindow.kolekcija.Etikete)
            {
                etikete_oznake.Add(e.Id);
            }

            InitializeComponent();
            this.DataContext = this;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Odustani(object sender, RoutedEventArgs e)
        {
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
                txtIkonicaPutanja = ikonica.Source.ToString();
            }
        }

        private void Button_Izaberi_Etiketu(object sender, RoutedEventArgs e)
        {
            if (listaEtiketa.SelectedValue != null)
            {

                foreach (Etiketa e1 in MainWindow.kolekcija.Etikete)
                {
                    if (e1.Id.Equals(listaEtiketa.SelectedValue))
                    {
                        etikete.Add(e1);

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


            bool naseljen = false;
            bool zivotinje = false;
            bool ugrozen = false;

            if (txtId == null || txtIme == null || cboxTip.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Niste uneli sva obavezna polja!", "Dodavanje spomenika");
                return;
            }

            string comboKlima = cboxKlima.SelectedItem.ToString();

            string comboStatus = cboxStatus.SelectedItem.ToString();



            if (ugrozenDa.IsChecked == true)
            {
                ugrozen = true;
            }
            else ugrozen = false;

            if (naseljenDa.IsChecked == true)
            {
                naseljen = true;
            }
            else naseljen = false;

            if (zivotinjeDa.IsChecked == true)
            {
                zivotinje = true;
            }
            else zivotinje = false;

            foreach (Tip t in MainWindow.kolekcija.Tipovi)
            {
                if (t.Id.Equals(cboxTip.SelectedItem))
                {
                    comboTip = t;
                }
            }

            txtDatum = (DateTime)datum.SelectedDate;

            if (txtIkonicaPutanja == null)
            {
                txtIkonicaPutanja = comboTip.IkonicaPutanja;
            }


            Spomenik spomenik = new Spomenik(txtId, txtIme, txtOpis, comboTip.Id, comboKlima, txtIkonicaPutanja, ugrozen, comboStatus, zivotinje, naseljen, txtPrihod, txtDatum, etikete);

            bool passed = MainWindow.kolekcija.dodajSpomenik(spomenik);
            if (passed)
            {
                foreach (Tip t in MainWindow.kolekcija.Tipovi)
                {
                    if (t.Id.Equals(comboTip.Id))
                    {
                        t.TipSpomenici.Add(spomenik);
                    }
                }
                MainWindow.kolekcija.sacuvajTip();
                MainWindow.kolekcija.sacuvajSpomenik();
                System.Windows.MessageBox.Show("Uspešno dodavanje novog spomenika.", "Uspeh!");
                this.Close();
            }
            else
                System.Windows.MessageBox.Show("Vec postoji spomenik sa tom oznakom!", "Greska!");
        }


    }
}





    /*
    public string Slika
    {
        get
        {
            return slika;
        }
        set
        {
            slika = value;
        }
    }

    public SpoInter()
    {
        InitializeComponent();
        comboBox1.Items.Add("1. Polarna");
        comboBox1.Items.Add("2. Kontinentalna");
        comboBox1.Items.Add("3. Umereno-kontinentalna");
        comboBox1.Items.Add("4. Pustinjska");
        comboBox1.Items.Add("5. Suptropska");
        comboBox1.Items.Add("6. Tropska");

        comboBox2.Items.Add("1. Eksploatisan");
        comboBox2.Items.Add("2. Dostupan");
        comboBox2.Items.Add("3. Nedostupan");

    } 

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
    {

    }

    private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Spomenik spo = new Spomenik();
        spo.Ime = textBox1.Text;
        spo.Opis = textBox2.Text;


    } 

     <ComboBoxItem>Polarna</ComboBoxItem>
                <ComboBoxItem>Kontinentalna</ComboBoxItem>
                <ComboBoxItem>Umereno-kontinentalna</ComboBoxItem>
                <ComboBoxItem>Pustinjska</ComboBoxItem>
                <ComboBoxItem>Suptropska</ComboBoxItem>
                <ComboBoxItem>Tropska</ComboBoxItem>


     */



