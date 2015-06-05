using Kino;
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

namespace AdministratorForme
{
    /// <summary>
    /// Interaction logic for BlagajnikPocetna.xaml
    /// </summary>
    public partial class BlagajnikPocetna : Window
    {
         public List<Osoba> osobe= new List<Osoba>() ;
        public List<Klijent> klijenti = new List<Klijent>();
        public List<Film> filmovi = new List<Film>();
        public List<Sala> sale = new List<Sala>();
        public List<SedmicniRaspored> raspored = new List<SedmicniRaspored>();
        public static List<Projekcija> projekcije = new List<Projekcija>();
        public List<Film> nova_filmovi = new List<Film>();
        public static List<bool> nece_da_moze = new List<bool>();
        public static string nesto;
        public static double osnova=0, cijenaLj=0, cijenaOb=0, cijenaVip=0;
        public static double ukupno = 0;
        public static double cijenaArtikli=0;
        Baza db = new Baza();
        public static string naziv;
        public static DateTime termin;
        public BlagajnikPocetna()
        {
            InitializeComponent();
           // UbaciUBazu();
            Ucitaj();

        }

        public void UbaciUBazu()
        {
            db.Filmovi.Add(new Film { Naziv = "Umri muski", GodinaIzdavanja = 1995 });
            db.Filmovi.Add(new Film{Naziv = "hamo", GodinaIzdavanja = 1995});
            db.Filmovi.Add(new Film{Naziv = "pipa", GodinaIzdavanja =  1995});
            db.Filmovi.Add(new Film{Naziv="ekipa", GodinaIzdavanja= 1995});
            db.Filmovi.Add(new Film{Naziv="celavii",GodinaIzdavanja= 1995});
            db.Filmovi.Add(new Film{Naziv="Umri muski", GodinaIzdavanja= 1995});
            db.SaveChanges();                                
        }

        public void Ucitaj()
        {
            bool proslo = false;
            filmovi = db.Filmovi.ToList();
            raspored = db.SedmicniRasporedi.ToList();
            if(raspored.Count() >0 )
            {
                proslo = true;
                projekcije = raspored[0].Projekcije; // da mi samo trenutni učita

            }


            foreach (Film f in filmovi)
            {
                foreach (Projekcija s in projekcije)
                {
                    Film fil = s.FilmFK;
                    if (fil.ID == f.ID)
                    {
                        nova_filmovi.Add(fil);
                    }

                }
            }
            if(proslo)
            {

                prvi.Content = nova_filmovi[0].Naziv;
                drugi.Content = nova_filmovi[1].Naziv;
                treci.Content = nova_filmovi[2].Naziv; ;
                cetvrti.Content = nova_filmovi[3].Naziv;
                peti.Content = nova_filmovi[4].Naziv;
                sesti.Content = nova_filmovi[5].Naziv;
            }
          


        }

    
        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            db.Klijenti.Add(new Klijent(ime.Text, prezime.Text, Convert.ToInt32(IDVip.Text), adresa.Text, Convert.ToDateTime(datumrodjenjaVIP.Text), brlicne.Text));
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void prvi_Click(object sender, RoutedEventArgs e)
        {
            foreach(Projekcija p in projekcije)
            {
                Film fl = p.FilmFK;
                if( fl.Naziv==prvi.Content.ToString()) 
                {
                    termini.Items.Add(p.VrijemeProjekcije);
                }
            }
        }

        private void drugi_Click(object sender, RoutedEventArgs e)
        {
            foreach (Projekcija p in projekcije)
            {
                Film fl = p.FilmFK;
                if (fl.Naziv == drugi.Content.ToString())
                {
                    termini.Items.Add(p.VrijemeProjekcije);
                }
            }
        }

        private void treci_Click(object sender, RoutedEventArgs e)
        {
            foreach (Projekcija p in projekcije)
            {
                Film fl = p.FilmFK;
                if (fl.Naziv == treci.Content.ToString())
                {
                    termini.Items.Add(p.VrijemeProjekcije);
                }
            }
        }

        private void cetvrti_Click(object sender, RoutedEventArgs e)
        {
            foreach (Projekcija p in projekcije)
            {
                Film fl = p.FilmFK;
                if (fl.Naziv == cetvrti.Content.ToString())
                {
                    termini.Items.Add(p.VrijemeProjekcije);
                }
            }
        }

        private void peti_Click(object sender, RoutedEventArgs e)
        {
            foreach (Projekcija p in projekcije)
            {
                Film fl = p.FilmFK;
                if (fl.Naziv == peti.Content.ToString())
                {
                    termini.Items.Add(p.VrijemeProjekcije);
                }
            }
        }

        private void sesti_Click(object sender, RoutedEventArgs e)
        {
            foreach (Projekcija p in projekcije)
            {
                Film fl = p.FilmFK;
                Cjenovnik c = p.CjenovnikFK;
                if (fl.Naziv == sesti.Content.ToString())
                {
                    termini.Items.Add(p.VrijemeProjekcije);
                    cijenaLj = c.DodatakZaLjubavnaMjesta;
                    cijenaVip = c.DodatakZaVip; osnova = c.Osnova;
                }
                
            }
        }

     
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Sala nova = new Sala();
                    nova.Show();
                    cijena_text.Text = Sala.cijena.ToString();
                    cijena_text.IsReadOnly = true;
                    ukupno_text.Text = (Sala.cijena + cijenaArtikli).ToString();                           
                    ukupno_text.IsReadOnly = true;
            
        }
    }
}
