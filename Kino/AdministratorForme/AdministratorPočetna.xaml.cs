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
    /// Interaction logic for AdministratorPočetna.xaml
    /// </summary>
    public partial class AdministratorPočetna : Window
    {
        List<Film> filmovi;
        public AdministratorPočetna()
        {
            InitializeComponent();
            filmovi = new List<Film> { //Filmove i sale obrisati
                new Film{ID = 1, Naziv = "Titanik", GodinaIzdavanja = 1997, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Kate Winslet", "Leonardo Di Caprio"}, Reziser = "James Cameron", Sinopsis = "Neki opis", Slika = null, KorisnikKojiJeKreiraoFIlm ="dzemal", VrijemeTrajanja = 145, KorisnikKojiJeNapravioPosljednjeIzmjene = "dzemal"},
                new Film{ID = 2, Naziv = "Život je lijep", GodinaIzdavanja = 1995, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Roberto Beninni"}, Reziser = "Ne znam", Sinopsis = "Neki opis", Slika = null, KorisnikKojiJeKreiraoFIlm ="dzemal", VrijemeTrajanja = 115, KorisnikKojiJeNapravioPosljednjeIzmjene = "dzemal"}
            };
            tabela.ItemsSource = filmovi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var prozor = new KreiranjeSedmicnogRasporeda();
            //this.Hide();
            prozor.ShowDialog();
            //this.ShowDialog();
        }

        private void PozivFormeZaUnosFilmaButtonClick(object sender, RoutedEventArgs e)
        {
            //pozivforme
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
                tabela.ItemsSource = filmovi;
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
    }
}
