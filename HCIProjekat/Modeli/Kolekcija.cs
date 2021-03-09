using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat.Modeli
{
    public class Kolekcija
    {
        //private static Kolekcija instance = null;

        //liste spomenika, tipova, etiketa
        private ObservableCollection<Spomenik> spomenici;
        private ObservableCollection<Tip> tipovi;
        private ObservableCollection<Etiketa> etikete;
        private ObservableCollection<Korisnik> korisnici;


        private string pathSpomenika = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "spomenici.txt");
        private string pathTipova = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.txt");
        private string pathEtiketa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.txt");
        private string pathKorisnika = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "korisnici.txt");

        private string korisnik = null;

        //konstruktor
        public Kolekcija() 
        {
            this.spomenici = new ObservableCollection<Spomenik>();  //Kolekcija(k)
            this.tipovi = new ObservableCollection<Tip>();
            this.etikete = new ObservableCollection<Etiketa>();
            this.korisnici = new ObservableCollection<Korisnik>();

            ucitajEtikete();
            ucitajSpomenike();
            ucitajTipove();
            ucitajKorisnike();
        }

        public Kolekcija(string k)
        {
            korisnik = k;
            pathSpomenika = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k + "spomenici.txt");
            pathTipova = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k + "tipovi.txt");
            pathEtiketa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k + "etikete.txt");
            pathKorisnika = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "korisnici.txt");

            ucitajEtikete();
            ucitajSpomenike();
            ucitajTipove();
            ucitajKorisnike();
            sacuvajSpomenik();
        }
        //_____________________________________________________________________________________________________________________

        //geteri i seteri

        public ObservableCollection<Korisnik> Korisnici
        {
            get
            {
                return this.korisnici;
            }

            set
            {
                if (value != this.korisnici)
                {
                    this.korisnici = value;
                }
            }
        }

        public ObservableCollection<Spomenik> Spomenici
        {
            get
            {
                return this.spomenici;
            }

            set
            {
                if (value != this.spomenici)
                {
                    this.spomenici = value;
                }
            }
        }

        public ObservableCollection<Tip> Tipovi
        {
            get
            {
                return this.tipovi;
            }

            set
            {
                if (value != this.tipovi)
                {
                    this.tipovi = value;
                }
            }
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return this.etikete;
            }

            set
            {
                if (value != this.etikete)
                {
                    this.etikete = value;
                }
            }
        }

        /*
        public static Kolekcija Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Kolekcija();
                }

                return instance;
            }

            set
            {
                instance = value;
            }

        } */

         //__________________________________________________________________________________________________________

        //ucitavanje

        public void ucitajKorisnike()
        {
            if (File.Exists(pathKorisnika))
            {

                using (StreamReader reader = File.OpenText(pathKorisnika))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    korisnici = (ObservableCollection<Korisnik>)serializer.Deserialize(reader, typeof(ObservableCollection<Korisnik>));
                }
            }
            else
            {
                korisnici = new ObservableCollection<Korisnik>();
            }


        }
        public void ucitajEtikete()
        {

            if (File.Exists(pathEtiketa))
            {

                using (StreamReader reader = File.OpenText(pathEtiketa))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    etikete = (ObservableCollection<Etiketa>)serializer.Deserialize(reader, typeof(ObservableCollection<Etiketa>));
                }
            }
            else
            {
                etikete = new ObservableCollection<Etiketa>();
            }
        }


        public void ucitajTipove()
        {
            if (File.Exists(pathTipova))
            {

                using (StreamReader reader = File.OpenText(pathTipova))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    tipovi = (ObservableCollection<Tip>)serializer.Deserialize(reader, typeof(ObservableCollection<Tip>));
                }
            }
            else
            {
                tipovi = new ObservableCollection<Tip>();
            }


        }
        public void ucitajSpomenike()
        {
            if (File.Exists(pathSpomenika))
            {

                using (StreamReader reader = File.OpenText(pathSpomenika))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    spomenici = (ObservableCollection<Spomenik>)serializer.Deserialize(reader, typeof(ObservableCollection<Spomenik>));
                }
            }
            else
            {
                spomenici = new ObservableCollection<Spomenik>();
            }


        }


        //______________________________________________________________________________________________

        //cuvanje
        public void sacuvajKorisnike()
        {
            using (StreamWriter writer = File.CreateText(pathKorisnika))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, korisnici);
                writer.Close();
            }


        }
        public void sacuvajSpomenik()
        {
            using (StreamWriter writer = File.CreateText(pathSpomenika))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, spomenici);
                writer.Close();
            }
        }

        public void sacuvajTip()
        {
            using (StreamWriter writer = File.CreateText(pathTipova))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, tipovi);
                writer.Close();
            }
        }

        public void sacuvajEtiketu()
        {
            using (StreamWriter writer = File.CreateText(pathEtiketa))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, etikete);
                writer.Close();
            }
        }


        public bool dodajEtiketu(Etiketa e)
        {
            foreach (Etiketa e1 in etikete)
            {
                if (e1.Id == e.Id)
                {

                    return false;
                }
            }
            etikete.Add(e);
            sacuvajEtiketu();

            return true;
        }

        public bool dodajTip(Tip tip)
        {
            foreach (Tip t1 in tipovi)
            {
                if (t1.Id == tip.Id)
                {
                    return false;
                }
            }
            tipovi.Add(tip);
            sacuvajTip();

            return true;
        }

        public bool dodajSpomenik(Spomenik spomenik)
        {
            foreach (Spomenik sp in spomenici)
            {
                if (sp.Id == spomenik.Id)
                {
                    return false;
                }
            }
            spomenici.Add(spomenik);
            sacuvajSpomenik();

            return true;

        }

        public bool obrisiEtiketu(Etiketa e)
        {
            foreach (Etiketa e1 in etikete)
            {
                if (e1.Id.Equals(e.Id))
                {
                    etikete.Remove(e);
                    sacuvajEtiketu();
                    return true;
                }
            }
            return false;
        }

        public bool obrisiSpomenik(Spomenik spomenik)
        {
            foreach (Spomenik sp in spomenici)
            {
                if (sp.Id.Equals(spomenik.Id))
                {
                    spomenici.Remove(sp);
                    sacuvajSpomenik();
                    return true;
                }
            }
            return false;
        }


        public bool obrisiTip(Tip tip)
        {
            foreach (Tip t in tipovi)
            {
                if (t.Id.Equals(tip.Id))
                {
                    tipovi.Remove(tip);
                    sacuvajTip();
                    return true;
                }
            }
            return false;
        }




    }
}
