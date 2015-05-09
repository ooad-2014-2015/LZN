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
            var projekcije = new List<string> { "Premijera", "Pretpremijera", "Obična projekcija"};
            List<Sala> sale = new List<Sala>{
                new Sala{ID = 1, NazivSale = "Kino sala", BrojLjubavnihSjedista = 8, BrojObicnihSjedista = 80, BrojVipSjedista = 4, UkupanBrojMijesta = 92},
                new Sala{ID = 2, NazivSale = "B", BrojLjubavnihSjedista = 10, BrojObicnihSjedista = 60, BrojVipSjedista = 0, UkupanBrojMijesta = 70},
                new Sala{ID = 3, NazivSale = "C", BrojLjubavnihSjedista = 0, BrojObicnihSjedista = 85, BrojVipSjedista = 15, UkupanBrojMijesta = 100},
                new Sala{ID = 2, NazivSale = "D", BrojLjubavnihSjedista = 14, BrojObicnihSjedista = 55, BrojVipSjedista = 0, UkupanBrojMijesta = 69}
            };
            PopuniTabele();
            PopuniTipProjekcije(projekcije);
            PopuniSale(sale);
        }
        #region metodeZaCjenovnikCheckBox //NijeZavrsena
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

        private void PopuniSalePomocna(List<Sala> sale, ComboBox a)
        {
            foreach(Sala item in sale)
            {
                a.Items.Add(item.NazivSale + " (" + Convert.ToString(item.UkupanBrojMijesta) + " mijesta)");
            }
        }
        
        private void PopuniSale(List<Sala> sale)
        {
            PopuniSalePomocna(sale, ponedjeljakSale1);
            PopuniSalePomocna(sale, ponedjeljakSale2);
            PopuniSalePomocna(sale, ponedjeljakSale3);

            PopuniSalePomocna(sale, utorakSale1);
            PopuniSalePomocna(sale, utorakSale2);
            PopuniSalePomocna(sale, utorakSale3);

            PopuniSalePomocna(sale, srijedaSale1);
            PopuniSalePomocna(sale, srijedaSale2);
            PopuniSalePomocna(sale, srijedaSale3);

            PopuniSalePomocna(sale, cetvrtakSale1);
            PopuniSalePomocna(sale, cetvrtakSale2);
            PopuniSalePomocna(sale, cetvrtakSale3);

            PopuniSalePomocna(sale, petakSale1);
            PopuniSalePomocna(sale, petakSale2);
            PopuniSalePomocna(sale, petakSale3);

            PopuniSalePomocna(sale, subotaSale1);
            PopuniSalePomocna(sale, subotaSale2);
            PopuniSalePomocna(sale, subotaSale3);

            PopuniSalePomocna(sale, nedjeljaSale1);
            PopuniSalePomocna(sale, nedjeljaSale2);
            PopuniSalePomocna(sale, nedjeljaSale3);
        }
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
        #region Metode Za Odabir Filma ButtonClick

        private void NedjeljaOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (nedjeljaTabela3.SelectedIndex == -1 || nedjeljaTabela3.SelectedIndex >= filmovi.Count)
                return;

            nedjeljaFilm3.Text = filmovi[nedjeljaTabela3.SelectedIndex].Naziv;
        }
        private void NedjeljaOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (nedjeljaTabela2.SelectedIndex == -1 || nedjeljaTabela2.SelectedIndex >= filmovi.Count)
                return;

            nedjeljaFilm2.Text = filmovi[nedjeljaTabela2.SelectedIndex].Naziv;
        }
        private void NedjeljaOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (nedjeljaTabela1.SelectedIndex == -1 || nedjeljaTabela1.SelectedIndex >= filmovi.Count)
                return;

            nedjeljaFilm1.Text = filmovi[nedjeljaTabela1.SelectedIndex].Naziv;
        }
        private void SubotaOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (subotaTabela3.SelectedIndex == -1 || subotaTabela3.SelectedIndex >= filmovi.Count)
                return;

            subotaFilm3.Text = filmovi[subotaTabela3.SelectedIndex].Naziv;
        }
        private void SubotaOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (subotaTabela2.SelectedIndex == -1 || subotaTabela2.SelectedIndex >= filmovi.Count)
                return;

            subotaFilm2.Text = filmovi[subotaTabela2.SelectedIndex].Naziv;
        }
        private void SubotaOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (subotaTabela1.SelectedIndex == -1 || subotaTabela1.SelectedIndex >= filmovi.Count)
                return;

            subotaFilm1.Text = filmovi[subotaTabela1.SelectedIndex].Naziv;
        }
        private void PetakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (petakTabela3.SelectedIndex == -1 || petakTabela3.SelectedIndex >= filmovi.Count)
                return;

            petakFilm3.Text = filmovi[petakTabela3.SelectedIndex].Naziv;
        }
        private void PetakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (petakTabela2.SelectedIndex == -1 || petakTabela2.SelectedIndex >= filmovi.Count)
                return;

            petakFilm2.Text = filmovi[petakTabela2.SelectedIndex].Naziv;
        }
        private void PetakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (petakTabela1.SelectedIndex == -1 || petakTabela1.SelectedIndex >= filmovi.Count)
                return;

            petakFilm1.Text = filmovi[petakTabela1.SelectedIndex].Naziv;
        }
        private void CetvrtakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (cetvrtakTabela1.SelectedIndex == -1 || cetvrtakTabela1.SelectedIndex >= filmovi.Count)
                return;

            cetvrtakFilm1.Text = filmovi[cetvrtakTabela1.SelectedIndex].Naziv;
        }
        private void CetvrtakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (cetvrtakTabela3.SelectedIndex == -1 || cetvrtakTabela3.SelectedIndex >= filmovi.Count)
                return;

            cetvrtakFilm3.Text = filmovi[cetvrtakTabela3.SelectedIndex].Naziv;
        }
        private void CetvrtakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (cetvrtakTabela2.SelectedIndex == -1 || cetvrtakTabela2.SelectedIndex >= filmovi.Count)
                return;

            cetvrtakFilm2.Text = filmovi[cetvrtakTabela2.SelectedIndex].Naziv;
        }
        private void SrijedaOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (srijedaTabela3.SelectedIndex == -1 || srijedaTabela3.SelectedIndex >= filmovi.Count)
                return;

            srijedaFilm3.Text = filmovi[srijedaTabela3.SelectedIndex].Naziv;
        }
        private void SrijedaOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (srijedaTabela2.SelectedIndex == -1 || srijedaTabela2.SelectedIndex >= filmovi.Count)
                return;

            srijedaFilm2.Text = filmovi[srijedaTabela2.SelectedIndex].Naziv;
        }
        private void SrijedaOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (srijedaTabela1.SelectedIndex == -1 || srijedaTabela1.SelectedIndex >= filmovi.Count)
                return;

            srijedaFilm1.Text = filmovi[srijedaTabela1.SelectedIndex].Naziv;
        }
        private void UtorakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (utorakTabela3.SelectedIndex == -1 || utorakTabela3.SelectedIndex >= filmovi.Count)
                return;

            utorakFilm3.Text = filmovi[utorakTabela3.SelectedIndex].Naziv;
        }
        private void UtorakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (utorakTabela2.SelectedIndex == -1 || utorakTabela2.SelectedIndex >= filmovi.Count)
                return;

            utorakFilm2.Text = filmovi[utorakTabela2.SelectedIndex].Naziv;
        }
        private void UtorakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (utorakTabela1.SelectedIndex == -1 || utorakTabela1.SelectedIndex >= filmovi.Count)
                return;

            utorakFilm1.Text = filmovi[utorakTabela1.SelectedIndex].Naziv;
        }
        private void PonedjeljakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (ponedjeljakTabela1.SelectedIndex == -1 || ponedjeljakTabela1.SelectedIndex >= filmovi.Count)
                return;

            ponedjeljakFilm1.Text = filmovi[ponedjeljakTabela1.SelectedIndex].Naziv;
        }
        private void PonedjeljakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (ponedjeljakTabela2.SelectedIndex == -1 || ponedjeljakTabela2.SelectedIndex >= filmovi.Count)
                return;

            ponedjeljakFilm2.Text = filmovi[ponedjeljakTabela2.SelectedIndex].Naziv;
        }
        private void PonedjeljakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (ponedjeljakTabela3.SelectedIndex == -1 || ponedjeljakTabela3.SelectedIndex >= filmovi.Count)
                return;

            ponedjeljakFilm3.Text = filmovi[ponedjeljakTabela3.SelectedIndex].Naziv;
        }
        #endregion
        #region Metode za prikaz detalja filma, poništavanje pretrage i pretragu ButtonClick

        private List<Film> Pretraga(int id, string naziv, int godinaIzdavanja, string zanr)
        {
            List<Film> lista = (from f in filmovi

                                where (id == 0 || f.ID == id) &&
                                (f.Naziv.ToLower().Contains(naziv.ToLower()) || naziv == " " || naziv == String.Empty) &&
                                (godinaIzdavanja == 0 || godinaIzdavanja == f.GodinaIzdavanja) &&
                                (f.Zanr.ToLower().Contains(zanr.ToLower()) || zanr == " " || zanr == String.Empty)

                                select f).ToList();

            return lista;
        }
        private void PretraziClick(object sender, RoutedEventArgs e)//Nije zavrseno
        {
            FrameworkElement roditelj = (FrameworkElement)((Button)sender).Parent;
            DataGrid tabela = new DataGrid();
            string naziv = String.Empty, zanr = String.Empty; 
            int id = 0, godinaIzdavanja = 0;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(roditelj); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(roditelj, i);
                if (kontrola is DataGrid)
                {
                    tabela = kontrola as DataGrid;
                }
                else if (kontrola is TextBox)
                {
                    TextBox a = kontrola as TextBox;
                    if(a.Name.Contains("Id"))
                    {
                        Int32.TryParse(a.Text, out id);

                        if (a.Text.Length > 0 && id == 0)
                        {
                            //Prijavi gresku i zavrsi
                        }
                        
                    }
                    else if(a.Name.Contains("Naziv"))
                    {
                        naziv = a.Text;
                    }
                    else if(a.Name.Contains("Zanr"))
                    {
                        zanr = a.Text;
                    }
                    else if(a.Name.Contains("Godina"))
                    {
                        Int32.TryParse(a.Text, out godinaIzdavanja);

                        if(a.Text.Length > 0 && godinaIzdavanja == 0)
                        {
                            //Prijavi gresku i zavrsi
                        }
                    }
                }
            }

            tabela.ItemsSource = Pretraga(id, naziv, godinaIzdavanja, zanr);
        }
        private void PonistiPretragu(object sender, RoutedEventArgs e)
        {
            FrameworkElement roditelj = (FrameworkElement)((Button)sender).Parent;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(roditelj); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(roditelj, i);
                if (kontrola is DataGrid)
                {
                    DataGrid tabela = kontrola as DataGrid;
                    tabela.ItemsSource = filmovi;
                }
                else  if (kontrola is TextBox)
                {
                    TextBox a = kontrola as TextBox;
                    a.Clear();
                }
            }
        }
        private void PrikazDetaljaFilma(object sender, RoutedEventArgs e) //Nije zavrsena
        {
            FrameworkElement roditelj = (FrameworkElement)((Button)sender).Parent;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(roditelj); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(roditelj, i);
                if (kontrola is DataGrid)
                {
                    DataGrid tabela = kontrola as DataGrid;
                    if (tabela.SelectedIndex == -1 || tabela.SelectedIndex >= filmovi.Count)
                        return;

                    //Poziv forme za prikaz detalja filma
                    MessageBox.Show(tabela.Name);
                    return;
                }
            }
        }
        #endregion
    }
}
