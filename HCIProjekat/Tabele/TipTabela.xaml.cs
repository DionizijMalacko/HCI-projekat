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
using System.Windows.Shapes;
using HCIProjekat.Modeli;
using HCIProjekat.Forme;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HCIProjekat.Tabele
{
    /// <summary>
    /// Interaction logic for TipTabela.xaml
    /// </summary>
    public partial class TipTabela : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Tip> tp;

        MainWindow mainWindow;


        //konstruktor
        public TipTabela()
        {
            Tp = MainWindow.kolekcija.Tipovi;
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

            this.DataContext = this;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        private void Button_Izmeni(object sender, RoutedEventArgs e)
        {
            Tip t;

            if (dgrMain.SelectedValue is Tip)
            {
                t = (Tip)dgrMain.SelectedValue;

                var s = new TipFormaUpdate(t);
                s.ShowDialog();

            }
            else
            {
                System.Windows.MessageBox.Show("NIste odabrali nijedan Tip.", "Izmena tipa");
            }
        }


        private void Button_Obrisi(object sender, RoutedEventArgs e)
        {
            Tip t = null;
            if (dgrMain.SelectedValue is Tip)
            {
                t = (Tip)dgrMain.SelectedValue;
                bool koristen = false;

                if (t.TipSpomenici.Count != 0)
                {
                    koristen = true;
                }

                if (koristen)
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Da li ste sigurni da želite da obrišete tip? " +
                    "Brisanjem ovog tipa brisete sve njegove spomenike ", "Brisanje tipa", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            //brisemo tip i sve spomenike tog tipa

                            List<Spomenik> lista = new List<Spomenik>();
                            foreach (Spomenik sp in MainWindow.kolekcija.Spomenici) //napravis listu sa indexima spomenika koji su tog tipa
                            {
                                if (sp.Tip.Equals(t.Id))
                                {
                                    lista.Add(sp);
                                    mainWindow.UkloniBrisanjemSliku(sp);
                                }
                            }
                            foreach (Spomenik i in lista) //pobrises ih iz kolekcije
                            {
                                MainWindow.kolekcija.Spomenici.Remove(i);


                            }


                            MainWindow.kolekcija.obrisiTip(t);

                            Tp = MainWindow.kolekcija.Tipovi;

                            MainWindow.kolekcija.sacuvajSpomenik();
                            MainWindow.kolekcija.sacuvajTip();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            break;
                    }

                }
                else
                {
                    MainWindow.kolekcija.obrisiTip(t);
                    Tp = MainWindow.kolekcija.Tipovi;
                    MainWindow.kolekcija.sacuvajTip();
                }

            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali tip za brisanje!", "Brisanje tipa");
            }
        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(tp);
            if (filter == "")
                cv.Filter = null;
            else
            {
                string[] words = filter.Split(' ');
                if (words.Contains(""))
                    words = words.Where(word => word != "").ToArray();
                cv.Filter = o =>
                {
                    Tip tip = o as Tip;
                    bool jedan = words.Any(word => tip.Id.ToUpper().Contains(word.ToUpper()));
                    bool dva = words.Any(word => tip.Ime.ToUpper().Contains(word.ToUpper()));

                    return jedan && dva;
                };
                dgrMain.ItemsSource = tp;
            }

        }



        public ObservableCollection<Tip> Tp
        {
            get
            {
                return this.tp;
            }
            set
            {
                if (value != this.tp)
                {
                    this.tp = value;
                    OnPropertyChanged("Tp");
                }
            }
        }

        public virtual void OnPropertyChanged(string str)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }

    }
}
