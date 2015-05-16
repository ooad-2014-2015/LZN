using Kino;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for AdministratorPočetna.xaml
    /// </summary>
    public partial class AdministratorPočetna : Window
    {
        ObservableCollection<Film> filmovi;
        bool zatvaranjaButton;
        Cjenovnik cjenovnik;

        public AdministratorPočetna()
        {
            InitializeComponent();
            zatvaranjaButton = false;

            cjenovnik = new Cjenovnik
            {
                Osnova = 4,
                DodatakZa3D = 1,
                DodatakZaLjubavnaMjesta = 1,
                DodatakZaNocneProjekcije = 1,
                DodatakZaPremijere = 3,
                DodatakZaVip = 2,
                ID = 1,
                DodatakZaPretpremijere = 1,
                PopustZaRodjendaskePakete = 5,
                PopustZaVipKorisnike = 5,
                Username = "dzemal",
                ZadnjaIzmjena = DateTime.Now,
                DodatakZaFilmoveDuzeOd120Min = 1
            };
            filmovi = new ObservableCollection<Film> { //Filmove i sale obrisati
                new Film{ID = 1, Naziv = "Titanik", GodinaIzdavanja = 1997, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Kate Winslet", "Leonardo Di Caprio"}, Reziser = "James Cameron", Sinopsis = "Neki opis", Slika = null, KorisnikKojiJeKreiraoFIlm ="dzemal", VrijemeTrajanja = 145, KorisnikKojiJeNapravioPosljednjeIzmjene = "dzemal"},
                new Film{ID = 2, Naziv = "Život je lijep", GodinaIzdavanja = 1995, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Roberto Beninni"}, Reziser = "Ne znam", Sinopsis = "Neki opis", Slika = null, KorisnikKojiJeKreiraoFIlm ="dzemal", VrijemeTrajanja = 115, KorisnikKojiJeNapravioPosljednjeIzmjene = "dzemal"}
            };
            tabela.ItemsSource = filmovi; 
            pozdrav.Content = "Dobrodošao Džemale"; //izmjeniti
            prijavljanKorisnik.Content = "Prijavljeni ste kao Džemal Čengić"; //izmjeniti 
            PopuniCjenovnik(cjenovnik);
        }

        private void PopuniCjenovnik(Cjenovnik cjenovnik) //ovdje dodati pravi cjenovnik iz baze
        {
            cjenovnikOsnova.Text = cjenovnikOsnova1.Text = Convert.ToString(cjenovnik.Osnova);
            cjenovnik3D.Text = cjenovnik3D1.Text = Convert.ToString(cjenovnik.DodatakZa3D);
            cjenovnikFilmDuziOd120Min.Text = cjenovnikFilmDuziOd120Min1.Text = Convert.ToString(cjenovnik.DodatakZaFilmoveDuzeOd120Min);
            cjenovnikLjubavna.Text = cjenovnikLjubavna1.Text = Convert.ToString(cjenovnik.DodatakZaLjubavnaMjesta);
            cjenovnikNocnaProjekcija.Text = cjenovnikNocnaProjekcija1.Text = Convert.ToString(cjenovnik.DodatakZaNocneProjekcije);
            cjenovnikPopustRodjendan.Text = cjenovnikPopustRodjendan1.Text = Convert.ToString(cjenovnik.PopustZaRodjendaskePakete);
            cjenovnikPopustVIP.Text = cjenovnikPopustVIP1.Text = Convert.ToString(cjenovnik.PopustZaVipKorisnike);
            cjenovnikPremijera.Text = cjenovnikPremijera1.Text = Convert.ToString(cjenovnik.DodatakZaPremijere);
            cjenovnikPretpremijera.Text = cjenovnikPretpremijera1.Text = Convert.ToString(cjenovnik.DodatakZaPretpremijere);
            cjenovnikVIP.Text = cjenovnikVIP1.Text = Convert.ToString(cjenovnik.DodatakZaVip);
        }
        private void PozivFormeZaKreiranjeRasporeda(object sender, RoutedEventArgs e)
        {
            var prozor = new KreiranjeSedmicnogRasporeda();
            //this.Hide();
            prozor.ShowDialog();
            //this.ShowDialog();
        }
        private void PozivFormeZaUnosFilmaButtonClick(object sender, RoutedEventArgs e)
        {
            var f = new FormaZaUnosFilma(filmovi);
            f.ShowDialog();
            tabela.ItemsSource = filmovi;
        }
        private void PonistiPretraguButtonClick(object sender, RoutedEventArgs e)
      {
          id.Clear();
          naziv.Clear();
          godina.Clear();
          reziser.Clear();
          zanr.Clear();
          donjaGranica.Clear();
          gornjaGranica.Clear();

          tabela.ItemsSource = filmovi;
      }
        private void EditovanjeFilmaButtonClick(object sender, RoutedEventArgs e)
        {
            if(tabela.SelectedIndex != -1)
            {
                var f = new PrikazEditovanjeFilma(filmovi[tabela.SelectedIndex], false);
                f.ShowDialog();
                PonistiPretraguButtonClick(sender, e);
                PretragaButtonClick(sender, e);
            }
        }
        private void PretragaButtonClick(object sender, RoutedEventArgs e)
        {
            int godinaIzdavanja = 0, donja = 0, gornja = 0, idFilma = 0;
            string nazivFilma = String.Empty, reziserFilma = String.Empty, zanrFilma = String.Empty;

            Int32.TryParse(donjaGranica.Text, out donja);
            Int32.TryParse(gornjaGranica.Text, out gornja);
            Int32.TryParse(id.Text, out idFilma);
            Int32.TryParse(godina.Text, out godinaIzdavanja);
            nazivFilma = naziv.Text;
            reziserFilma = reziser.Text;
            zanrFilma = zanr.Text;

            var lista = (from f in filmovi

                         where (idFilma == 0 || f.ID == idFilma) &&
                         (godinaIzdavanja == 0 || godinaIzdavanja == f.GodinaIzdavanja) &&
                         ((donja == 0 && gornja == 0) || (donja <= f.VrijemeTrajanja && gornja >= f.VrijemeTrajanja)) &&
                         (nazivFilma == String.Empty || nazivFilma == " " || f.Naziv.ToLower().Contains(nazivFilma.ToLower())) &&
                         (reziserFilma == String.Empty || reziserFilma == " " || f.Reziser.ToLower().Contains(reziserFilma.ToLower())) &&
                         (zanrFilma == String.Empty || zanrFilma == "" || zanrFilma == f.Zanr)

                         select f).ToList();

            tabela.ItemsSource = lista;
        }
        private void BrisanjeFilmaButtonClick(object sender, RoutedEventArgs e)
        {
            if(tabela.SelectedIndex != -1 && MessageBox.Show("Da li ste sigurni da želite izbrisati film iz baze podataka", "Brisanje filma", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                filmovi.RemoveAt(tabela.SelectedIndex); //Dodati provjeru da li je film u nekoj projekciji, ako jeste zabraniti brisanje
                tabela.ItemsSource = filmovi;
                MessageBox.Show("Film uspješno obrisan", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }
        private void OdjavaButtonClick(object sender, RoutedEventArgs e)
        {
            zatvaranjaButton = true;
            this.Close();
        }
        private void ZatvaranjeProzora(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (zatvaranjaButton)
                return;

            if (MessageBox.Show("Da li ste sigurni da želite izaći?\nSvi podaci koji nisu spašeni će biti izgubljeni", "", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.No)
            {
                e.Cancel = true;
                return;
            }
            Application.Current.Shutdown();
        }
        private void IzmjeniCjenovnikButtonClick(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li želite potvrditi izmjene?", "Izmjena cjenovnika", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if (
           cjenovnikOsnova1.Text.Length == 0 ||
          cjenovnik3D1.Text.Length == 0 ||
          cjenovnikFilmDuziOd120Min1.Text.Length == 0 ||
          cjenovnikLjubavna1.Text.Length == 0 ||
          cjenovnikNocnaProjekcija1.Text.Length == 0 ||
          cjenovnikPopustRodjendan1.Text.Length == 0 ||
          cjenovnikPopustVIP1.Text.Length == 0 ||
          cjenovnikPremijera1.Text.Length == 0 ||
          cjenovnikPretpremijera1.Text.Length == 0 ||
          cjenovnikVIP1.Text.Length == 0)
          {
                statusCjenovnik.ItemsSource = ("Morate popuniti sva polja cjenovnika!");
                Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                nit.Start();
                return;
          }

            double osnova = 0;
            int dimenzionalnost = 0, duzinaVecaOd120 = 0, ljubavna = 0, premijera = 0, pretpremijera = 0, VIP = 0, popustVIP = 0, popustRodjendan = 0, nocnaProjekcija = 0;

            try
            {
                osnova = Double.Parse(cjenovnikOsnova1.Text);
                duzinaVecaOd120 = Int32.Parse(cjenovnikFilmDuziOd120Min1.Text);
                ljubavna = Int32.Parse(cjenovnikLjubavna1.Text);
                premijera = Int32.Parse(cjenovnikPremijera1.Text);
                pretpremijera = Int32.Parse(cjenovnikPretpremijera1.Text);
                VIP = Int32.Parse(cjenovnikVIP1.Text);
                popustVIP = Int32.Parse(cjenovnikPopustVIP1.Text);
                dimenzionalnost = Int32.Parse(cjenovnik3D1.Text);
                popustRodjendan = Int32.Parse(cjenovnikPopustRodjendan1.Text);
                nocnaProjekcija = Int32.Parse(cjenovnikNocnaProjekcija1.Text);
            }
            catch(Exception)
            {
                statusCjenovnik.ItemsSource = ("Neispravan unos");
                Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                nit.Start();
                return;
            }
            Cjenovnik novi = new Cjenovnik(osnova, nocnaProjekcija, ljubavna, VIP, premijera, dimenzionalnost, popustVIP, popustRodjendan, duzinaVecaOd120, pretpremijera, DateTime.Now, "username logovanog korisnika", 1);//Zadnja 2 parametra izmjenit
            cjenovnik = novi;
            PopuniCjenovnik(cjenovnik);
        }
        private void IzmjeniBojuStatusBar()
        {
            Brush boja = Brushes.Red;
            Dispatcher.BeginInvoke((Action)(() => boja = statusCjenovnik.Background));

            for (int i = 1; i <= 5; i++)
            {
                Dispatcher.BeginInvoke((Action)(() => statusCjenovnik.Background = Brushes.Red));
                Thread.Sleep(800);

                Dispatcher.BeginInvoke((Action)(() => statusCjenovnik.Background = boja));
                Thread.Sleep(800);
            }
        }
    }
}
