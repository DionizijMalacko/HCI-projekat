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
    /// Interaction logic for SpomenikTabela.xaml
    /// </summary>
    public partial class SpomenikTabela : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Spomenik> spom;

        MainWindow mainWindow;


        //konstruktor
        public SpomenikTabela()
        {
            Spom = MainWindow.kolekcija.Spomenici;


            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            this.DataContext = this;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        private void Button_Izmeni(object sender, RoutedEventArgs e)
        {
            if(dgrMain.SelectedValue is Spomenik)
            {
                Spomenik sp = (Spomenik)dgrMain.SelectedValue;

                var s = new SpomenikFormaUpdate(sp);
                s.ShowDialog();

            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali nijedan spomenik.", "Izmena spomenika");
            }
        }


        private void Button_Obrisi(object sender, RoutedEventArgs e)
        {
            Spomenik sp = null;
            if (dgrMain.SelectedValue is Spomenik)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Da li ste sigurni da želite da obrišete Spomenik?", "Brisanje Spomenika", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        sp = (Spomenik)dgrMain.SelectedItem;

                        foreach (Tip t in MainWindow.kolekcija.Tipovi)
                        {
                            if (sp.Tip.Equals(t.Id))
                            {

                                t.TipSpomenici.Remove(sp);
                                mainWindow.UkloniBrisanjemSliku(sp);
                            }
                        }

                        MainWindow.kolekcija.obrisiSpomenik(sp);

                        Spom = MainWindow.kolekcija.Spomenici;

                        MainWindow.kolekcija.sacuvajSpomenik();
                        MainWindow.kolekcija.sacuvajTip();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;

                }
            }
        }

        public ObservableCollection<Spomenik> Spom
        {
            get
            {
                return this.spom;
            }
            set
            {
                if (value != this.spom)
                {
                    this.spom = value;
                    OnPropertyChanged("Spom");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(spom);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Spomenik man = o as Spomenik;
                    string[] words = filter.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    bool jedan = words.Any(word => man.Id.ToUpper().Contains(word.ToUpper()));
                    bool dva = words.Any(word => man.Ime.ToUpper().Contains(word.ToUpper()));


                    return jedan && dva;
                };

                dgrMain.ItemsSource = spom;
            }
        }

        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }

}
