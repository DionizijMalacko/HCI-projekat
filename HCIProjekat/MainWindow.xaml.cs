using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Xml.Serialization;
using HCIProjekat.Forme;
using HCIProjekat.Help;
using HCIProjekat.Modeli;
using HCIProjekat.Tabele;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public static Kolekcija kolekcija;

        private Point startPoint;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private ObservableCollection<Tip> tipovi;

        public ObservableCollection<Tip> Tipovi
        {
            get
            {
                return tipovi;
            }
            set
            {
                if (tipovi != value)
                {
                    tipovi = value;
                    OnPropertyChanged("Tipovi");
                }
            }
        }


        //konstruktor
        public MainWindow()
        {

            kolekcija = new Kolekcija();

            tipovi = kolekcija.Tipovi;

            this.DataContext = this;

            //demoMod = new DemoMod();

            InitializeComponent();

            ucitajNaMapu();
        }

        //metoda koja pravi tooltip koji se prikazuje kada se misem dodje na ikonicu na mapi
        private ToolTip napraviWrapPanel(Spomenik m)
        {
            WrapPanel wp = new WrapPanel();
            wp.Orientation = Orientation.Vertical;

            TextBox id = new TextBox();
            id.IsEnabled = false;
            id.Text = "Id: " + m.Id;
            wp.Children.Add(id);

            TextBox ime = new TextBox();
            ime.IsEnabled = false;
            ime.Text = "Ime: " + m.Ime;
            wp.Children.Add(ime);


            TextBox tip = new TextBox();
            tip.IsEnabled = false;
            tip.Text = "Tip: " + m.Tip;
            wp.Children.Add(tip);



            TextBox opis = new TextBox();
            opis.IsEnabled = false;
            opis.Text = "Opis: " + m.Opis;
            wp.Children.Add(opis);


            TextBox datum = new TextBox();
            datum.IsEnabled = false;
            datum.Text = "Datum: " + m.DatumOtkrivanja.ToShortDateString();
            wp.Children.Add(datum);

            TextBox klima = new TextBox();
            klima.IsEnabled = false;
            klima.Text = "Klima: " + m.Klima;
            wp.Children.Add(klima);

            TextBox ugrozen = new TextBox();
            ugrozen.IsEnabled = false;
            if (m.EkoloskaUgrozenost)
                ugrozen.Text = "Ekoloski ugrozen: Da";
            else
                ugrozen.Text = "Ekoloski ugrozen: Ne";
            wp.Children.Add(ugrozen);

            TextBox zivotinje = new TextBox();
            zivotinje.IsEnabled = false;
            if (m.UgrozenihZivotinja)
                zivotinje.Text = "Ugrozene zivotinje: Da";
            else
                zivotinje.Text = "Strateska Vaznost: Ne";
            wp.Children.Add(zivotinje);

            TextBox naseljen = new TextBox();
            naseljen.IsEnabled = false;
            if (m.NaseljenRegion)
                naseljen.Text = "Naseljen region: Da";
            else
                naseljen.Text = "Naseljen region: Ne";
            wp.Children.Add(naseljen);


            TextBox status = new TextBox();
            status.IsEnabled = false;
            status.Text = "Turisticki status: " + m.TuristickiStatus;
            wp.Children.Add(status);

            TextBox prihod = new TextBox();
            prihod.IsEnabled = false;
            prihod.Text = "Prihod: " + m.Prihod;
            wp.Children.Add(prihod);

            TextBox etikete = new TextBox();
            etikete.IsEnabled = false;
            etikete.Text = "Etikete:" + System.Environment.NewLine;
            string ListaEtiketa = "";
            StringBuilder sb = new StringBuilder(ListaEtiketa);
            ObservableCollection<Etiketa> list = m.TagEtikete;
            foreach (Etiketa et in list)
            {
                sb.Append(et.Id);
                sb.Append(System.Environment.NewLine);
            }
            ListaEtiketa = sb.ToString();
            etikete.Text += ListaEtiketa;
            ListaEtiketa = "";
            wp.Children.Add(etikete);

            ToolTip tt = new ToolTip();
            tt.Content = wp;

            return tt;
        }

        // Ucitava na Mapu Sveta sve spomenike koji su prethodno stavljeni
        private void ucitajNaMapu()
        {
            foreach (Spomenik sp in kolekcija.Spomenici)
            {
                bool result = MapaSveta.Children.Cast<Image>().Any(x => x.Tag != null && x.Tag.ToString() == sp.Id);
                if (result)
                    continue;

                if (sp.X != -1 || sp.Y != -1)
                {
                    Image img = new Image();
                    if (!sp.IkonicaPutanja.Equals(""))
                        img.Source = new BitmapImage(new Uri(sp.IkonicaPutanja));


                    img.Width = 50;
                    img.Height = 50;
                    img.Tag = sp.Id;

                    img.ToolTip = napraviWrapPanel(sp);

                    img.PreviewMouseLeftButtonDown += DraggedImagePreviewMouseLeftButtonDown;
                    img.MouseMove += DraggedImageMouseMove;

                    MapaSveta.Children.Add(img);
                    Canvas.SetLeft(img, sp.X - 20);
                    Canvas.SetTop(img, sp.Y - 20);

                }
            }
        }


        //__________________________________________________________________
        private void Novi_Tip_Click(object sender, RoutedEventArgs e)
        {
            var s = new TipForma();
            s.Show();
        }

        private void Novi_Spomenik_Click(object sender, RoutedEventArgs e)
        {
            var s = new SpomenikForma();
            s.Show();

        }

        private void Nova_Etiketa_Click(object sender, RoutedEventArgs e)
        {
            var s = new EtiketaForma();
            s.Show();
        }

        private void PregledSpomenika_Click(object sender, RoutedEventArgs e)
        {
            var s = new SpomenikTabela();
            s.Show();
        }

        private void PregledTipova_Click(object sender, RoutedEventArgs e)
        {
            var s = new TipTabela();
            s.Show();
        }

        private void PregledEtiketa_Click(object sender, RoutedEventArgs e)
        {
            var s = new EtiketaTabela();
            s.Show();
        }
        //__________________________________________________________________

        //DRAG&DROP metode


        //postavlja ikonicu spomenika na mapu
        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("spomenik"))
            {
                Spomenik sp = e.Data.GetData("spomenik") as Spomenik;

                bool result = MapaSveta.Children.Cast<Image>().Any(x => x.Tag != null && x.Tag.ToString() == sp.Id);

                Point d0 = e.GetPosition(MapaSveta);

                foreach (Spomenik temp in kolekcija.Spomenici)
                {
                    if (temp.Id != sp.Id)
                    {
                        if (temp.X != -1 && temp.X != -1)
                        {
                            if (Math.Abs(temp.X - d0.X) <= 30 && Math.Abs(temp.Y - d0.Y) <= 30)
                            {
                                System.Windows.MessageBox.Show("Spomenik sa ovom lokacijom već postoji na mapi!" +
                                    " Ponovo unesite spomenik na mapu.",
                                    "Premeštanje spomenika na mapi");
                                return;
                            }
                        }
                    }
                }


                if (result == false)
                {
                    Image img = new Image();

                    if (!sp.IkonicaPutanja.Equals(""))
                    {
                        img.Source = new BitmapImage(new Uri(sp.IkonicaPutanja));
                    }

                    img.Width = 50;
                    img.Height = 50;
                    img.Tag = sp.Id;

                    var positionX = e.GetPosition(MapaSveta).X;
                    var positionY = e.GetPosition(MapaSveta).Y;

                    sp.X = positionX;
                    sp.Y = positionY;

                    img.ToolTip = napraviWrapPanel(sp);

                    img.PreviewMouseLeftButtonDown += DraggedImagePreviewMouseLeftButtonDown;
                    img.MouseMove += DraggedImageMouseMove;


                    foreach (Spomenik spomenik in MainWindow.kolekcija.Spomenici)
                    {
                        if (spomenik.Id.Equals(sp.Id))
                        {
                            spomenik.X = positionX;
                            spomenik.Y = positionY;
                        }
                    }

                    kolekcija.sacuvajSpomenik();

                    MapaSveta.Children.Add(img);
                    Canvas.SetLeft(img, positionX - 20);
                    Canvas.SetTop(img, positionY - 20);
                }
                else
                {
                    System.Windows.MessageBox.Show("Spomenik sa ovom oznakom već postoji na mapi!", "Dodavanje spomenika na mapu");

                }

            }
        }

        private void Canvas_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("spomenik") || sender == e.Source)
            {

                e.Effects = DragDropEffects.None;
            }
        }

        private void Stablo_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Stablo_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);

            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                try
                {
                    Spomenik selektovan = (Spomenik)treeSpomenici.SelectedValue;
                    if (selektovan != null)
                    {
                        DataObject dragData = new DataObject("spomenik", selektovan);
                        DragDrop.DoDragDrop(treeSpomenici, dragData, DragDropEffects.Move);
                    }
                }
                catch
                {
                    return;
                }
            }

        }

        private void DraggedImageMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);

            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                Spomenik selektovan = (Spomenik)treeSpomenici.SelectedValue;

                if (selektovan != null)
                {
                    Image img = sender as Image;
                    MapaSveta.Children.Remove(img);
                    DataObject dragData = new DataObject("spomenik", selektovan);
                    DragDrop.DoDragDrop(img, dragData, DragDropEffects.Move);

                }

            }

        }



        private void DraggedImagePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);

            Image img = sender as Image;

            foreach (Spomenik sp in MainWindow.kolekcija.Spomenici)
            {
                if (sp.Id.Equals(img.Tag))
                {
                    TreeViewItem tvi = null; //lokalna promenljiva koja mi treba da oznacim tip gde se nalazi spomenik u stablu
                    TreeViewItem tvi2 = null;

                    foreach (Tip t in MainWindow.kolekcija.Tipovi)
                    {
                        if (sp.Tip.Equals(t.Id))
                        {
                            tvi = treeSpomenici.ItemContainerGenerator.ContainerFromItem(t) as TreeViewItem;

                        }
                        foreach (Spomenik spomenik in t.TipSpomenici)
                        {
                            if (spomenik.Id.Equals(img.Tag))
                            {
                                tvi2 = tvi.ItemContainerGenerator.ContainerFromItem(spomenik) as TreeViewItem;
                            }
                        }
                    }


                    //tvi2 = tvi.ItemContainerGenerator.ContainerFromItem(r) as TreeViewItem;



                    if (tvi2 != null)
                    {
                        tvi2.IsSelected = true;
                    }

                }
            }

            if (e.LeftButton == MouseButtonState.Released)
                e.Handled = true;

        }

        public bool UkloniBrisanjemSliku(Spomenik spomenik)
        {
            Image img = null;
            foreach (Image i in MapaSveta.Children)
            {
                if (i.Tag.Equals(spomenik.Id))
                    img = i;
            }
            MapaSveta.Children.Remove(img);

            return true;
        }

        private void UkloniSaMape_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (treeSpomenici.SelectedValue is Spomenik)
                {
                    Spomenik selected = (Spomenik)treeSpomenici.SelectedItem;

                    bool postoji = MapaSveta.Children.Cast<Image>()
                           .Any(x => x.Tag != null && x.Tag.ToString() == selected.Id);
                    if (postoji)
                    {
                        Image img = null;
                        foreach (Image i in MapaSveta.Children)
                        {
                            if (i.Tag.Equals(selected.Id))
                                img = i;
                        }
                        MapaSveta.Children.Remove(img);


                        foreach (Spomenik sp in MainWindow.kolekcija.Spomenici)
                        {
                            if (selected.Id.Equals(sp.Id))
                            {
                                sp.X = -1;
                                sp.Y = -1;
                            }
                        }


                        kolekcija.sacuvajSpomenik();

                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Oznacite spomenik u stablu koji zelite da obrisete!", "Greska!");
                }
            }
            catch
            {
                return;
            }


        }

        //__________________________________________________________________________

        /*
        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            demoMod.pokreniDemo();
        } 
        */
        private void NoviSpomenik_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new SpomenikForma();
            s.Show();
        }

        private void NoviTips_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new TipForma();
            s.Show();
        }

        private void NovaEtiketa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new EtiketaForma();
            s.Show();
        }

        private void PregledSpomenika_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new SpomenikTabela();
            s.Show();
        }

        private void PregledTip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new TipTabela();
            s.Show();
        }

        private void PregledEtiketa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new EtiketaTabela();
            s.Show();
        }


        private void About_Click(object sender, RoutedEventArgs e)
        {

            var s = new About();
            s.Show();

        }

        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.Help.ShowHelp(null, @"C:\Users\Denim\Documents\HelpNDoc\Output\Build chm documentation\Pomoc.chm");

        }



    }

}
