using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls; //mozda treba da obrisem?
using System.Windows.Media;

namespace HCIProjekat.Modeli
{
    public class Spomenik : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string id;
        private String ime;
        private string opis;
        private string tipSpomenika;
        private string klima;  //Enum { }
        private ImageSource ikonica; 
        private string ikonicaPutanja;
        private bool ekoloskaUgrozenost;
        private string turistickiStatus;  //Enum { }
        private bool ugrozenihZivotinja;
        private bool naseljenRegion;
        private double prihod;
        private DateTime datumOtkrivanja;
        private ObservableCollection<Etiketa> tagEtikete;

        private double x = -1;
        private double y = -1;

        public Spomenik() { }

        public Spomenik(string id, string ime, string opis, string tipSpomenika, string klima, string ikonicaPutanja,
                                bool ekoloskaUgrozenost, string turistickiStatus, bool ugrozenihZivotinja, bool naseljenRegion, double prihod, DateTime datumOtkrivanja, ObservableCollection<Etiketa> tagEtikete)
        {
            this.id = id;
            this.ime = ime;
            this.opis = opis;
            this.tipSpomenika = tipSpomenika;
            this.klima = klima;
            this.ikonicaPutanja = ikonicaPutanja;
            this.ekoloskaUgrozenost = ekoloskaUgrozenost;
            this.turistickiStatus = turistickiStatus;
            this.ugrozenihZivotinja = ugrozenihZivotinja;
            this.naseljenRegion = naseljenRegion;
            this.prihod = prihod;
            this.datumOtkrivanja = datumOtkrivanja;
            this.tagEtikete = tagEtikete;
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }

        }

        public String Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }

        }
        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }

        }

        public string Klima
        {
            get
            {
                return klima;
            }
            set
            {
                if (value != klima)
                {
                    klima = value;
                    OnPropertyChanged("Klima");
                }
            }

        }

        public string Tip
        {
            get
            {
                return tipSpomenika;
            }

            set
            {
                if (value != tipSpomenika)
                {
                    tipSpomenika = value;
                    OnPropertyChanged("Tip");
                }
            }

        }

        public ImageSource Ikonica
        {
            get
            {
                return ikonica;
            }

            set
            {
                if (value != ikonica)
                {
                    ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public string IkonicaPutanja
        {
            get
            {
                return ikonicaPutanja;
            }

            set
            {
                if (value != ikonicaPutanja)
                {
                    ikonicaPutanja = value;
                    OnPropertyChanged("IkonicaPutanja");
                }
            }
        }

        public bool EkoloskaUgrozenost
        {
            get
            {
                return ekoloskaUgrozenost;
            }

            set
            {
                if (value != ekoloskaUgrozenost)
                {
                    ekoloskaUgrozenost = value;
                    OnPropertyChanged("EkoloskaUgrozenost");
                }
            }
        }

        public bool NaseljenRegion
        {
            get
            {
                return naseljenRegion;
            }

            set
            {
                if (value != naseljenRegion)
                {
                    naseljenRegion = value;
                    OnPropertyChanged("NaseljenRegion");
                }
            }
        }

        public bool UgrozenihZivotinja
        {
            get
            {
                return ugrozenihZivotinja;
            }

            set
            {
                if (value != ugrozenihZivotinja)
                {
                    ugrozenihZivotinja = value;
                    OnPropertyChanged("UgrozenihZivotinja");
                }
            }
        }

        public string TuristickiStatus
        {
            get
            {
                return turistickiStatus;
            }

            set
            {
                if (value != turistickiStatus)
                {
                    turistickiStatus = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }

        public double Prihod
        {
            get
            {
                return prihod;
            }

            set
            {
                if (value != prihod)
                {
                    prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }

        public DateTime DatumOtkrivanja
        {
            get
            {
                return datumOtkrivanja;
            }

            set
            {
                if (value != datumOtkrivanja)
                {
                    datumOtkrivanja = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }

        public ObservableCollection<Etiketa> TagEtikete
        {
            get
            {
                return this.tagEtikete;
            }
            set
            {
                this.tagEtikete = value;
                OnPropertyChanged("TagEtikete");
            }
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value != x)
                    x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value != y)
                    y = value;
                OnPropertyChanged("Y");
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
