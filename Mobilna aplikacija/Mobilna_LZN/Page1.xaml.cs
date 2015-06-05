using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Mobilna_LZN;

namespace PhoneApp1
{
    
    public partial class Page1 : PhoneApplicationPage
    {
        public List<string> filmovi = new List<string>();
        public List<bool> je_li = new List<bool>();
        public List<Film> ponude = new List<Film>();

        bool generisano = false;
        public Page1()
        {
            InitializeComponent();

            
            //FileStream str = new FileStream(@"C:\Users\Student\Desktop\Mobilna_LZN\Mobilna_LZN\Bin\Debug", FileMode.OpenOrCreate, FileAccess.Write);
            //using (System.IO.TextReader reader = System.IO.File.OpenText(ime))
            //{


            //    string text = reader.ReadLine();
            //    filmovi.Add(text);

            //}

            //using (BazaContext db = new BazaContext(BazaContext.ConnectionString))
            //{
            //    //db.CreateIfNotExists();

            //    //Table<Film> _filmovi = db.GetTable<Film>();
            //    //var filmoviUpit = from j in filmovi.ToList() select j;
            //    //foreach (var Film in _filmovi)
            //    //{
            //    //    PivotItem p = new PivotItem();

            //    //    filmovi.Add(Film._ime.ToString());

            //    //    //Kontrola popravkeKontrola = new Kontrola();
            //    //    //popravkeKontrola.id.Text = "Id popravke:  " + popravka.Id;
            //    //    //popravkeKontrola.cijena.Text = "Cijena:  " + popravka.Cijena + " KM";
            //    //    //popravkeKontrola.datumPrijema.Text = "Datum prijema zahtjeva:  " + popravka.DatumPrijema.ToShortDateString();
            //    //    //popravkeKontrola.tip.Text = "Vrsta popravke:  " + popravka.Tip;
            //    //    //popravkeKontrola.vozilo.Text = "Naziv vozila:  " + popravka.Vozilo;
            //    //    //popravkeKontrola.dijelovi.Text = "Lista dijelova:  " + popravka.Dijelovi;
            //    //    //popravkeKontrola.datumZavrsetka.Text = "Datum zavrsetka popravke:  " + popravka.DatumZavrsetka.ToShortDateString();

            //    //    //p.Header = "Br popravke " + popravka.Id;
            //    //    //p.Content = popravkeKontrola;
            //    //    //mojPivot.Items.Add(p);
            //    //}
            //}

            // ponude.Add(new Ponude() { ime = "Avengers", put_slike = "avengers.jpg" });
            //using (BazaContext db = new BazaContext(BazaContext.ConnectionString))
            //{
            //    //Table<Film> film = db.GetTable<Film>();
            //    //var jelaQuery = from j in jela.ToList() select j;
            //    //foreach (var jelo in jelaQuery)
            //    //{
            //    //    PivotItem p = new PivotItem();
            //    //    JeloKontrola jeloKontrola = new JeloKontrola();
            //    //    jeloKontrola.ImeText.Text = jelo.Cijena + " KM";
            //    //    jeloKontrola.OpisText.Text = jelo.Opis;
            //    //    if (jelo.Slika.ToArray() != null && jelo.Slika.ToArray() is Byte[])
            //    //    {
            //    //        MemoryStream stream = new MemoryStream(jelo.Slika.ToArray());
            //    //        BitmapImage image = new BitmapImage();
            //    //        image.SetSource(stream);
            //    //        jeloKontrola.slikaKontrola.Source = image;
            //    //    }
            //    //    p.Header = jelo.Ime;
            //    //    p.Content = jeloKontrola;
            //    //    mojPivot.Items.Add(p);
            //    //}

                
            //}
            Ucitaj();
        }

        void Postavi_bool()
        {

            for (int i = 0; i < 22; i++)
            {
                je_li.Add(false);
            }
        }

        void dodaj()
        {

           // Table<Film> filmovi = .GetTable<Film>();   

            filmovi.Add("Umri muški");
            filmovi.Add("Despicable me 2");
            filmovi.Add("Bad boys");
            filmovi.Add("Crni gruja");
            filmovi.Add("Glup, gluplji");
            filmovi.Add("Avengers");
            filmovi.Add("The Pursuit of Happyness");
            filmovi.Add("Mali zmaj kokos");
            filmovi.Add("Frozen");
            filmovi.Add("Zvončica");
            filmovi.Add("Schinders list");
            filmovi.Add("Raging bull");
            filmovi.Add("Casablanca");
            filmovi.Add("Titanik");
            filmovi.Add("Gladiator");
            filmovi.Add("Lord of the Rings: The Return of the King");
            filmovi.Add("Saving private Ryan");
            filmovi.Add("Unforgiven");
            filmovi.Add("Rocky");
            filmovi.Add("Brave heart");
            filmovi.Add("The exorcist");
            filmovi.Add("The Great Gatsby");

        }


        public void Ucitaj()
        {
            Postavi_bool();
            dodaj();

            int brojac = 0;
            Random rnd = new Random();
        
            List<string> nova = new List<string>();
            while (true)
            {
                int br = rnd.Next(1, 22);
                if (!je_li[br])
                {
                    je_li[br] = true;
                    brojac++;
                    nova.Add(filmovi[br]);
                }
                if (brojac == 7)
                {
                    generisano = true;
                    break;
                }
            }

            if (generisano)
            {
                prvi.Content = filmovi[0];
                drugi.Content = filmovi[1];
                treci.Content = filmovi[2];
                cetvrti.Content = filmovi[3];
                peti.Content = filmovi[4];
                sesti.Content = filmovi[5];
                sedmi.Content = filmovi[6];
            }
           
               
        }

        private void prvi_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void drugi_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void treci_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void cetvrti_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void peti_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void sesti_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }

        private void sedmi_Checked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
        }




    }
}