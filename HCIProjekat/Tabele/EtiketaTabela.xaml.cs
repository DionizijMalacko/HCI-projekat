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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCIProjekat.Modeli;
using HCIProjekat.Forme;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HCIProjekat.Tabele
{
    /// <summary>
    /// Interaction logic for EtiketaTabela.xaml
    /// </summary>
    public partial class EtiketaTabela : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Etiketa> etik;

        public EtiketaTabela()
        {
            etik = MainWindow.kolekcija.Etikete;
            InitializeComponent();
            this.DataContext = this;

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }


        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            Etiketa m = null;
            if (dgrMain.SelectedValue is Etiketa)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Da li ste sigurni da želite da obrišete etiketu?", "Brisanje etikete", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        //brise se etiketa u svim spomenicima i tipSpomenicima!
                        m = (Etiketa)dgrMain.SelectedValue;

                        MainWindow.kolekcija.obrisiEtiketu(m);

                        foreach (Spomenik sp in MainWindow.kolekcija.Spomenici)
                        {
                            if (sp.TagEtikete.Contains(m))
                            {
                                sp.TagEtikete.Remove(m);
                            }
                        }

                        foreach (Tip t in MainWindow.kolekcija.Tipovi)
                        {

                            foreach (Spomenik sp in t.TipSpomenici)
                            {
                                if (sp.TagEtikete.Contains(m))
                                {
                                    sp.TagEtikete.Remove(m);
                                }
                            }
                        }
                        MainWindow.kolekcija.sacuvajTip();
                        Etik = MainWindow.kolekcija.Etikete;
                        MainWindow.kolekcija.sacuvajSpomenik  ();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }


            }
            else
            {
                System.Windows.MessageBox.Show("Niste odabrali etiketu za brisanje!", "Brisanje etikete");

            }
        }


        private void Button_Izmeni(object sender, RoutedEventArgs e)
        {
            Etiketa m;

            if (dgrMain.SelectedValue is Etiketa)
            {
                m = (Etiketa)dgrMain.SelectedValue;

                var s = new EtiketaFormaUpdate(m);
                s.ShowDialog();

            }
            else
            {
                System.Windows.MessageBox.Show("NIste odabrali nijednu etiketu.", "Izmena etikete");
            }

        }

        private void Button_Obrisi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public ObservableCollection<Etiketa> Etik
        {
            get
            {
                return this.etik;
            }
            set
            {
                if (value != this.etik)
                {
                    this.etik = value;
                    OnPropertyChanged("Etik");
                }
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            string filter = textbox.Text;

            ICollectionView cv = CollectionViewSource.GetDefaultView(etik);

            if (filter == "")
            {
                cv.Filter = null;
            }
            else
            {
                string[] words = filter.Split(' ');
                if (words.Contains(""))
                    words = words.Where(word => word != "").ToArray();
                cv.Filter = o =>
                {
                    Etiketa etiketa = o as Etiketa;
                    return words.Any(word => etiketa.Id.ToUpper().Contains(word.ToUpper()));
                };

                dgrMain.ItemsSource = etik;
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
