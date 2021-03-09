using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Serialization;

namespace HCIProjekat.Modeli
{
    public class Tip : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string id;
        private string ime;
        private string opis;
        private ImageSource ikonica; //trenutno se ne koristi 
        private string ikonicaPutanja;
        [NonSerialized] ObservableCollection<Spomenik> tipSpomenici;


        public Tip() { }

        public Tip(string id, string ime, string opis, string ikonicaPutanja, ObservableCollection<Spomenik> sp)
        {
            this.id = id;
            this.ime = ime;
            this.opis = opis;
            this.ikonicaPutanja = ikonicaPutanja;
            this.tipSpomenici = sp;
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    OnPropertyChanged("Id");
                }
            }

        }

        public string Ime
        {
            get
            {
                return this.ime;
            }
            set
            {
                if (value != this.ime)
                {
                    this.ime = value;
                    OnPropertyChanged("Ime");
                }
            }

        }

        public string Opis
        {
            get
            {
                return this.opis;
            }
            set
            {
                if (value != this.opis)
                {
                    this.opis = value;
                    OnPropertyChanged("Opis");
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
                }
            }

        }

        public string IkonicaPutanja
        {
            get
            {
                return this.ikonicaPutanja;
            }

            set
            {
                if (value != this.ikonicaPutanja)
                {
                    this.ikonicaPutanja = value;
                    OnPropertyChanged("IkonicaPutanja");
                }
            }
        }

        [XmlIgnore]
        public ObservableCollection<Spomenik> TipSpomenici
        {
            get
            {
                return this.tipSpomenici;
            }

            set
            {
                if (value != this.tipSpomenici)
                {
                    this.tipSpomenici = value;
                    OnPropertyChanged("TipSpomenici");
                }
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
