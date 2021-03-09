using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCIProjekat.Modeli
{
    public class Etiketa : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        private string id;
        private Color boja;
        private string opis;


        public Etiketa() { }

        public Etiketa(string i, Color b, string o)
        {
            id = i;
            boja = b;
            opis = o;
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

        public Color Boja
        {
            get
            {
                return this.boja;
            }
            set
            {
                if (value != this.boja)
                {
                    this.boja = value;
                    OnPropertyChanged("Boja");
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



        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
