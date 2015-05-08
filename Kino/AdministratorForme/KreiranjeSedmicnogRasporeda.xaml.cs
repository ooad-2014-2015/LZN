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
using Kino;

namespace AdministratorForme
{
    /// <summary>
    /// Interaction logic for KreiranjeSedmicnogRasporeda.xaml
    /// </summary>
    public partial class KreiranjeSedmicnogRasporeda : Window
    {
        List<Film> filmovi; //izbrisati
        public KreiranjeSedmicnogRasporeda()
        {
            InitializeComponent();
            CjenovnikCekiran();
            filmovi = new List<Film> {
                new Film{ID = 1, Naziv = "Titanik", GodinaIzdavanja = 1997, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Kate Winslet", "Leonardo Di Caprio"}, Reziser = "James Cameron", Sinospis = "Neki opis", Slika = "Zasad nema", Username ="dzemal", VrijemeTrajanja = 145},
                new Film{ID = 2, Naziv = "Život je lijep", GodinaIzdavanja = 1995, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Roberto Beninni"}, Reziser = "Ne znam", Sinospis = "Neki opis", Slika = "Nema slike", Username ="dzemal", VrijemeTrajanja = 115}
            };
            var projekcije = new List<string> { "premijera", "pretpremijera", "obična projekcija"};
            PopuniTabele();
            PopuniTipProjekcije(projekcije);
        }
        #region metodeZaCjenovnikCheckBox
        private void CjenovnikCekiran() //Mijenja ReadOnly property TextBoxova iz cjenovnika
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(cjenovnikGrid); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(cjenovnikGrid, i);
                if (kontrola is TextBox)
                {
                    TextBox t = kontrola as TextBox;
                    t.IsReadOnly = !(t.IsReadOnly);
                }
            }
        }
        private void postojeciCjenovnik_Unchecked(object sender, RoutedEventArgs e)
        {
           CjenovnikCekiran();
        }

        private void postojeciCjenovnik_Checked(object sender, RoutedEventArgs e)
        {
            CjenovnikCekiran();
            //Vratiti pocetne vrijednosti
        }
        #endregion
        #region metodeZaPunjenjeKontrolaPodacima
        
        private void PopuniTipProjekcije(List<string> projekcije)
        {
            ponedjeljakProjekcije1.ItemsSource = projekcije;
            ponedjeljakProjekcije2.ItemsSource = projekcije;
            ponedjeljakProjekcije3.ItemsSource = projekcije;

            utorakProjekcije1.ItemsSource = projekcije;
            utorakProjekcije2.ItemsSource = projekcije;
            utorakProjekcije3.ItemsSource = projekcije;

            srijedaProjekcije1.ItemsSource = projekcije;
            srijedaProjekcije2.ItemsSource = projekcije;
            srijedaProjekcije3.ItemsSource = projekcije;

            cetvrtakProjekcije1.ItemsSource = projekcije;
            cetvrtakProjekcije2.ItemsSource = projekcije;
            cetvrtakProjekcije3.ItemsSource = projekcije;

            petakProjekcije1.ItemsSource = projekcije;
            petakProjekcije2.ItemsSource = projekcije;
            petakProjekcije3.ItemsSource = projekcije;

            subotaProjekcije1.ItemsSource = projekcije;
            subotaProjekcije2.ItemsSource = projekcije;
            subotaProjekcije3.ItemsSource = projekcije;

            nedjeljaProjekcije1.ItemsSource = projekcije;
            nedjeljaProjekcije2.ItemsSource = projekcije;
            nedjeljaProjekcije3.ItemsSource = projekcije;
            
        }
        private void PopuniTabele()
        {
            ponedjeljakTabela1.ItemsSource = filmovi;
            ponedjeljakTabela2.ItemsSource = filmovi;
            ponedjeljakTabela3.ItemsSource = filmovi;

            utorakTabela1.ItemsSource = filmovi;
            utorakTabela2.ItemsSource = filmovi;
            utorakTabela3.ItemsSource = filmovi;

            srijedaTabela1.ItemsSource = filmovi;
            srijedaTabela2.ItemsSource = filmovi;
            srijedaTabela3.ItemsSource = filmovi;

            cetvrtakTabela1.ItemsSource = filmovi;
            cetvrtakTabela2.ItemsSource = filmovi;
            cetvrtakTabela3.ItemsSource = filmovi;

            petakTabela1.ItemsSource = filmovi;
            petakTabela2.ItemsSource = filmovi;
            petakTabela3.ItemsSource = filmovi;

            subotaTabela1.ItemsSource = filmovi;
            subotaTabela2.ItemsSource = filmovi;
            subotaTabela3.ItemsSource = filmovi;

            nedjeljaTabela1.ItemsSource = filmovi;
            nedjeljaTabela2.ItemsSource = filmovi;
            nedjeljaTabela3.ItemsSource = filmovi;
        }
        #endregion

        #region metodeZaOdabirFilmaButtonClick

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ponedjeljakTabela1.SelectedIndex == -1)
                return;

            ponedjeljakFilm1.Text = filmovi[ponedjeljakTabela1.SelectedIndex].Naziv;
        }
        #endregion

        #region metodeZaPonistavanjePretrage

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ponedjeljakTabela1.ItemsSource = filmovi;
        }
        #endregion
    }
}
