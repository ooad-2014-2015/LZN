using Kino;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        ObservableCollection<Artikal> artikli;
        ObservableCollection<Korisnik> korisnici; 
        bool zatvaranjaButton;
        Cjenovnik cjenovnik; 

        public AdministratorPočetna()
        {
            InitializeComponent();
            zatvaranjaButton = false;

            #region Za brisanje
            korisnici = new ObservableCollection<Korisnik>{
                new Korisnik{ID = 1, Ime = "Džemal", Prezime = "Čengić", Spol = "Muško", TipKorisnika = "Administrator sistema", Username = "cenga", Password = Convert.ToString(("neki password").GetHashCode())},
                new Korisnik{ID = 2, Ime = "Adna", Prezime = "Tahić", Spol = "Žensko", TipKorisnika = "Blagajnik", Username = "tahicka", Password = Convert.ToString(("1234565789").GetHashCode())},
                new Korisnik{ID = 3, Ime = "Amina", Prezime = "Krekić", Spol = "Žensko", TipKorisnika = "Finansijski menadžer", Username = "krekicamina", Password = Convert.ToString(("0000").GetHashCode())}
            };
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
            artikli = new ObservableCollection<Artikal>{
                new Artikal{ID = 1, Cijena = 2, Kolicina = 0.3, NaStanju = 50, Naziv = "Coca-Cola"},
                new Artikal{ID = 2, Cijena = 2.5, Kolicina = 0.25, NaStanju = 100, Naziv = "Kokice"},
                new Artikal{ID = 3, Cijena = 3, Kolicina = 0.2, NaStanju = 75, Naziv = "Kikiriki"},
                new Artikal{ID = 4, Cijena = 1, Kolicina = 0.1, NaStanju = 40, Naziv = "Košpice"}
            };
            #endregion
            tabela.ItemsSource = filmovi; 
            tabelaArtikli.ItemsSource = artikli;
            tabelaKorisnici.ItemsSource = korisnici;
            pozdrav.Content = "Dobrodošao Džemale"; //izmjeniti
            prijavljanKorisnik.Content = "Prijavljeni ste kao Džemal Čengić"; //izmjeniti 
            PopuniCjenovnik(cjenovnik);
            korisnikSpolPretraga.ItemsSource = new List<string> { "Žensko", "Muško" };
            korisnikPravaPristupaPretraga.ItemsSource = new List<string> { "Blagajnik", "Finansijski menadžer", "Administrator sistema" };
        }

        #region Metode za cjenovnik

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
            catch (Exception)
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
        #endregion
        #region Metode za obradu filmova

        private void PozivFormeZaUnosFilmaButtonClick(object sender, RoutedEventArgs e)
        {
            var f = new FormaZaUnosFilma(filmovi);
            this.Hide();
            f.ShowDialog();
            tabela.ItemsSource = filmovi;
            this.ShowDialog();
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
            if (tabela.SelectedIndex != -1)
            {
                Film temp = tabela.SelectedItem as Film;
                var f = new PrikazEditovanjeFilma(temp, false);
                this.Hide();
                f.ShowDialog();
                this.ShowDialog();
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
                         ((donja == 0 && gornja == 0) || (donja <= f.VrijemeTrajanja && gornja >= f.VrijemeTrajanja) || (gornja == 0 && donja < f.VrijemeTrajanja)) &&
                         (nazivFilma == String.Empty || nazivFilma == " " || f.Naziv.ToLower().Contains(nazivFilma.ToLower())) &&
                         (reziserFilma == String.Empty || reziserFilma == " " || f.Reziser.ToLower().Contains(reziserFilma.ToLower())) &&
                         (zanrFilma == String.Empty || zanrFilma == "" || zanrFilma == f.Zanr)

                         select f).ToList();

            tabela.ItemsSource = lista;
        }
        private void BrisanjeFilmaButtonClick(object sender, RoutedEventArgs e)//Dodati provjeru da li je film u nekoj projekciji, ako jeste zabraniti brisanje
        {
            if (tabela.SelectedIndex != -1 && MessageBox.Show("Da li ste sigurni da želite izbrisati film iz baze podataka", "Brisanje filma", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Film temp = tabela.SelectedItem as Film;
                for (int i = 0; i < filmovi.Count; i++) 
                {
                    if (filmovi[i].ID == temp.ID)
                    {
                        filmovi.RemoveAt(i);
                        break;
                    }
                }
                tabela.ItemsSource = filmovi;
                MessageBox.Show("Film uspješno obrisan", "", MessageBoxButton.OK, MessageBoxImage.Information);
                PonistiPretraguButtonClick(sender, e);
                return;
            }
        }
        #endregion
        #region Metode za obradu artikala

        private void PonistiPretragUArtikalaButtonClick(object sender, RoutedEventArgs e)
        {
            idArtikla.Clear();
            nazivArtikla.Clear();
            naStanjuGornja.Clear();
            naStanjuDonja.Clear();
            cijenaGornjaArtikla.Clear();
            cijenaDonjaArtikla.Clear();
            kolicinaArtikla.Clear();

            tabelaArtikli.ItemsSource = artikli;
        }
        private void BrisanjeArtiklaButtonClick(object sender, RoutedEventArgs e)
        {
            if (tabelaArtikli.SelectedIndex != -1 && MessageBox.Show("Da li ste sigurni da želite izbrisati artikal iz baze podataka", "Brisanje artikla", MessageBoxButton.YesNo,
             MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Artikal temp = tabelaArtikli.SelectedItem as Artikal;
                for (int i = 0; i < artikli.Count; i++)
                {
                    if (artikli[i].ID == temp.ID)
                    {
                        artikli.RemoveAt(i);
                        break;
                    }
                }
                tabelaArtikli.ItemsSource = artikli;
                MessageBox.Show("Artikal uspješno obrisan", "", MessageBoxButton.OK, MessageBoxImage.Information);
                OcistiPolja();
                PonistiPretragUArtikalaButtonClick(sender, e);
                return;
            }
        }
        private void PretragaArtikli(object sender, RoutedEventArgs e)
        {
            int id = 0, donjeStanje = 0, gornjeStanje = 0;
            string ime = String.Empty;
            double velicina = 0, cijenaDonja = 0, cijenaGornja = 0;

            ime = nazivArtikla.Text;
            Int32.TryParse(idArtikla.Text, out id);
            Double.TryParse(cijenaDonjaArtikla.Text, out cijenaDonja);
            Double.TryParse(cijenaGornjaArtikla.Text, out cijenaGornja);
            Int32.TryParse(naStanjuDonja.Text, out donjeStanje);
            Int32.TryParse(naStanjuGornja.Text, out gornjeStanje);
            Double.TryParse(kolicinaArtikla.Text, out velicina);

            var lista = (from a in artikli

                         where (id == 0 || id == a.ID) &&
                         (velicina == 0 || velicina == a.Kolicina) &&
                         ((cijenaDonja == 0 && cijenaGornja == 0) || (cijenaDonja <= a.Cijena && cijenaGornja >= a.Cijena) || (cijenaDonja < a.Cijena && cijenaGornja == 0)) &&
                         ((donjeStanje == 0 && gornjeStanje == 0) || (donjeStanje <= a.NaStanju && gornjeStanje >= a.NaStanju) || (donjeStanje < a.NaStanju && gornjeStanje == 0)) &&
                         (ime == String.Empty || ime == " " || a.Naziv.ToLower().Contains(ime.ToLower()))

                         select a).ToList();

            tabelaArtikli.ItemsSource = lista;
        }
        private void PotvrdaUnosaArtikal(object sender, RoutedEventArgs e) //Provjeriti za dodavanja slike
        {
            if(noviArtikalkolicina.Text.Length == 0 || noviArtikalNaziv.Text.Length == 0 || noviArtikalStanje.Text.Length == 0 || noviArtikalCijena.Text.Length == 0)
            {
                statusArtikal.ItemsSource = ("Morate popuniti sva polja!").ToList();
                return;
            }

            double cijenaArtikal = 0, velicina = 0;
            int stanje = 0;
            Int32.TryParse(noviArtikalStanje.Text, out stanje);
            Double.TryParse(noviArtikalkolicina.Text, out velicina);
            Double.TryParse(noviArtikalCijena.Text, out cijenaArtikal);

            if(cijenaArtikal == 0 || velicina == 0)
            {
                statusArtikal.ItemsSource = ("Neispravan unos!");
                return;
            }

            if (MessageBox.Show("Da li želite potvrditi unos?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            byte[] niz = new byte[1];
            try
            {
                niz = getJPGFromImageControl(slika.Source as BitmapImage); 
            }
            catch(Exception) {}

            if(Int32.Parse(noviArtikalId.Text) <= artikli.Last().ID)
            {
                Artikal artikal = artikli.Where(m => m.ID == Int32.Parse(noviArtikalId.Text)).First();
                artikal.Kolicina = velicina;
                artikal.Naziv = noviArtikalNaziv.Text;
                artikal.Slika = niz;
                artikal.NaStanju = stanje;
                artikal.Cijena = cijenaArtikal;
                MessageBox.Show("Izmjene su sačuvane", "", MessageBoxButton.OK, MessageBoxImage.Information);
                OcistiPolja();
                PonistiPretragUArtikalaButtonClick(sender, e);
                PretragaArtikli(sender, e);
                return;
            }
            Artikal a = new Artikal { ID = Int32.Parse(noviArtikalId.Text), NaStanju = stanje, Cijena = cijenaArtikal, Naziv = noviArtikalNaziv.Text, Kolicina = velicina, Slika = niz };
            artikli.Add(a);

            MessageBox.Show("Uspješno je unijet novi artikal!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            OcistiPolja();
        }
        private void OcistiPolja()
        {
            noviArtikalCijena.Clear();
            noviArtikalId.Clear();
            noviArtikalkolicina.Clear();
            noviArtikalNaziv.Clear();
            noviArtikalStanje.Clear(); 
            slika.Source = null;
        }
        private void OdabirSlikeArtikal(object sender, RoutedEventArgs e)
        {
            OpenFileDialog prozor = new OpenFileDialog();
            var rezultat = prozor.ShowDialog();

            if (rezultat == true)
            {
                prozor.Filter = "JPEG FIles(*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
                try
                {
                    slika.Source = new BitmapImage(new Uri(prozor.FileName));
                }
                catch (Exception)
                {
                    statusArtikal.ItemsSource = ("Pogrešan format!").ToList();
                }
                return;
            }
        }
        private void GroupBox_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Int32.Parse(noviArtikalId.Text) <= artikli.Last().ID)
                    return;
            }
            catch (Exception) { }

            if (artikli.Count == 0)
                noviArtikalId.Text = Convert.ToString(1);
            else
                noviArtikalId.Text = Convert.ToString(artikli.Last().ID + 1);
        }
        private void EditovanjeArtiklaButtonClick(object sender, RoutedEventArgs e)
        {
            if(tabelaArtikli.SelectedIndex == -1)
                return;

            Artikal a = tabelaArtikli.SelectedItem as Artikal;
            noviArtikalCijena.Text = Convert.ToString(a.Cijena);
            noviArtikalId.Text = Convert.ToString(a.ID);
            noviArtikalkolicina.Text = Convert.ToString(a.Kolicina);
            noviArtikalNaziv.Text = a.Naziv;
            noviArtikalStanje.Text = Convert.ToString(a.NaStanju);
            try
            {
                slika.Source = LoadImage(a.Slika);
            }
            catch (Exception) { }
        }
        #endregion
        #region Metode za obradu korisnika

        private void PonistiPretragu(object sender, RoutedEventArgs e)
        {
            korisnikIdPretraga.Clear();
            korisnikImePretraga.Clear();
            korisnikPravaPristupaPretraga.SelectedIndex = -1;
            korisnikPrezimePretraga.Clear();
            korisnikSpolPretraga.SelectedIndex = -1;
            korisnikUsernamePretraga.Clear();

            tabelaKorisnici.ItemsSource = korisnici;
        }
        private void PretragaKorisnikButtonClick(object sender, RoutedEventArgs e)
        {
            int id = 0;
            string ime = korisnikImePretraga.Text, prezime = korisnikPrezimePretraga.Text, spol = String.Empty, prava = String.Empty, username = korisnikUsernamePretraga.Text;
            Int32.TryParse(korisnikIdPretraga.Text, out id);

            if (korisnikSpolPretraga.SelectedIndex != -1)
                spol = korisnikSpolPretraga.SelectedItem.ToString();
            if (korisnikPravaPristupaPretraga.SelectedIndex != -1)
                prava = korisnikPravaPristupaPretraga.SelectedItem.ToString();

            var lista = (from k in korisnici  

                         where (id == 0 || k.ID == id) &&
                         (ime == " " || ime == String.Empty || k.Ime.ToLower().Contains(ime.ToLower())) &&
                         (prezime == " " || prezime == String.Empty || k.Prezime.ToLower().Contains(prezime.ToLower())) &&
                         (spol == String.Empty || spol == k.Spol) &&
                         (prava == String.Empty || prava == k.TipKorisnika) &&
                         (username == " " || username == String.Empty || k.Username.ToLower().Contains(username.ToLower()))

                         select k).ToList();

            tabelaKorisnici.ItemsSource = lista;
        }
        private void korisnikPravaPristupaPretraga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PretragaKorisnikButtonClick(sender, e);
        }
        private void BrisanjeKorisnika(object sender, RoutedEventArgs e)
        {
            if(tabelaKorisnici.SelectedIndex != -1 && MessageBox.Show("Da li želite potvrditi?", "Brisanje korisnika", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Korisnik temp = tabelaKorisnici.SelectedItem as Korisnik;
                for (int i = 0; i < korisnici.Count; i++)
                {
                    if(korisnici[i].ID == temp.ID)
                    {
                        korisnici.RemoveAt(i);
                        break;
                    }
                }
                    MessageBox.Show("Uspješno ste izbrisali korisnika sistema", "Brisanje uspješno", MessageBoxButton.OK, MessageBoxImage.Information);
                PonistiPretragu(sender, e);
                PretragaKorisnikButtonClick(sender, e);
                return;
            }
        }
        private void IzmjenaKorisnika(object sender, RoutedEventArgs e)
        {
            if (tabelaKorisnici.SelectedIndex == -1)
                return;

            Korisnik temp = tabelaKorisnici.SelectedItem as Korisnik;
            UnosKorisnika f = new UnosKorisnika(korisnici, false, temp);
            this.Hide();
            f.ShowDialog();
            PonistiPretragu(sender, e);
            this.ShowDialog();
        }
        private void NoviKorisnikUnos(object sender, RoutedEventArgs e)
        {
            var f = new UnosKorisnika(korisnici, true, new Korisnik());
            this.Hide();
            f.ShowDialog();
            PonistiPretragu(sender, e);
            this.ShowDialog();
        }
        #endregion
        #region Pomoćne metode
        private void PozivFormeZaKreiranjeRasporeda(object sender, RoutedEventArgs e)
        {
            var prozor = new KreiranjeSedmicnogRasporeda();
            this.Hide();
            prozor.ShowDialog();
            this.ShowDialog();
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
        private byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();

        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        #endregion
    }
}
