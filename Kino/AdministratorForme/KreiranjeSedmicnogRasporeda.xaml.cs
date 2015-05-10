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
        Cjenovnik cjenovnik;
        List<Sala> sale;
        List<Projekcija> kreiraneProjekcije;
        SedmicniRaspored raspored;
        int ukupanBrojGresaka = 0;

        public KreiranjeSedmicnogRasporeda()
        {
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
            kreiraneProjekcije = new List<Projekcija>();
            raspored = new SedmicniRaspored();
            InitializeComponent();
            CjenovnikCekiran();
            filmovi = new List<Film> {
                new Film{ID = 1, Naziv = "Titanik", GodinaIzdavanja = 1997, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Kate Winslet", "Leonardo Di Caprio"}, Reziser = "James Cameron", Sinospis = "Neki opis", Slika = "Zasad nema", Username ="dzemal", VrijemeTrajanja = 145},
                new Film{ID = 2, Naziv = "Život je lijep", GodinaIzdavanja = 1995, Zanr = "drama", DatumPosljednjeIzmjene = DateTime.Now, DatumUnosa = DateTime.Now,
                Glumci = new List<string>{"Roberto Beninni"}, Reziser = "Ne znam", Sinospis = "Neki opis", Slika = "Nema slike", Username ="dzemal", VrijemeTrajanja = 115}
            };
            var projekcije = new List<string> { "Premijera", "Pretpremijera", "Obična projekcija"};
            sale = new List<Sala>{
                new Sala{ID = 1, NazivSale = "Kino sala", BrojLjubavnihSjedista = 8, BrojObicnihSjedista = 80, BrojVipSjedista = 4, UkupanBrojMijesta = 92},
                new Sala{ID = 2, NazivSale = "B", BrojLjubavnihSjedista = 10, BrojObicnihSjedista = 60, BrojVipSjedista = 0, UkupanBrojMijesta = 70},
                new Sala{ID = 3, NazivSale = "C", BrojLjubavnihSjedista = 0, BrojObicnihSjedista = 85, BrojVipSjedista = 15, UkupanBrojMijesta = 100},
                new Sala{ID = 2, NazivSale = "D", BrojLjubavnihSjedista = 14, BrojObicnihSjedista = 55, BrojVipSjedista = 0, UkupanBrojMijesta = 69}
            };

            PopuniCjenovnik(cjenovnik);
            PopuniTabele();
            PopuniTipProjekcije(projekcije);
            PopuniSale(sale);
        }
        #region Medote za kreiranje i validaciju rasporeda

        private int DajId(string film)
        {
            foreach(var item in filmovi)
            {
                if (item.Naziv == film)
                    return item.ID;
            }
            return -1;
        }
        private string OdrediDimenzionalnost(GroupBox g)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(g); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(g, i);
                if (kontrola is Grid)
                {
                    Grid grid = kontrola as Grid;
                    for (int j = 0; j < VisualTreeHelper.GetChildrenCount(grid); j++)
                    {
                        Visual control = (Visual)VisualTreeHelper.GetChild(grid, j);
                        if (control is RadioButton)
                        {
                            RadioButton r = control as RadioButton;
                            if(r.Name.Contains("2D") && r.IsChecked == true)
                            {
                                return "2D";
                            }
                            else if (r.Name.Contains("3D") && r.IsChecked == true)
                            {
                                return "3D";
                            }
                        }
                    }
                }
            }
            return string.Empty;
        }
        private DateTime OdrediVrijemeProjekcije(GroupBox g, Grid grid)
        {
            int sati = 0;

            if (g.Header.ToString().Contains("14")) 
                sati = 14;
            else if (g.Header.ToString().Contains("17"))
                sati = 17;
            else
                sati = 21;

            int dan = pocetak.SelectedDate.Value.Day;

            if (grid.Name.Contains("utorak"))
                dan += 1;
            else if (grid.Name.Contains("srijeda")) 
                dan += 2;
            else if (grid.Name.Contains("cetvrtak"))
                dan += 3;
            else if (grid.Name.Contains("petak"))
                dan += 4;
            else if (grid.Name.Contains("subota"))
                dan += 5;
            else if (grid.Name.Contains("nedjelja")) 
                dan += 6;

            return new DateTime(pocetak.SelectedDate.Value.Year, pocetak.SelectedDate.Value.Month, dan, sati, 0, 0, 0);
                
        } //Ne radi kako treba
        private void ValidirajGroupBox(Grid grid, DateTime vrijemeProjekcije)
        {
            string  projekcija = String.Empty, dimenzionalnost = String.Empty;
            int filmFK = 0, brojGresaka = 0, SalaFk = 0;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(grid); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(grid, i);
                if (kontrola is TextBox)
                {
                    TextBox g = kontrola as TextBox;
                    if(g.Text.Length > 0)
                    {
                        filmFK = DajId(g.Text);
                        g.BorderBrush = Brushes.Green;
                    }
                    else
                    {
                        g.BorderBrush = Brushes.Red;
                        brojGresaka++;
                    }
                }
                else if(kontrola is ComboBox)
                {
                    ComboBox c = kontrola as ComboBox;
                    if(c.Name.Contains("Sale")) //Ako je Sala
                    {
                        if(c.SelectedIndex == -1)
                        {
                            c.BorderBrush = Brushes.Red;
                            brojGresaka++;
                        }
                        else
                        {
                            SalaFk = sale[c.SelectedIndex].ID;
                            c.BorderBrush = Brushes.Green;
                        }
                    }
                    else if (c.Name.Contains("Projekcije")) //Ako je projekcija
                    {
                        if (c.SelectedIndex == -1)
                        {
                            c.BorderBrush = Brushes.Red;
                            brojGresaka++;
                        }
                        else
                        {
                            projekcija = c.SelectedItem.ToString(); //Ovo je mozda greska
                            c.BorderBrush = Brushes.Green; //Ovo raditi naknadno
                        }
                    }
                }
                else if(kontrola is CheckBox)
                {
                    CheckBox box = kontrola as CheckBox;
                    if (box.IsChecked == false)
                        return;
                }
                else if(kontrola is GroupBox)
                {
                    GroupBox g = kontrola as GroupBox;
                    dimenzionalnost = OdrediDimenzionalnost(g);
                }
            }
            ukupanBrojGresaka += brojGresaka;
            raspored.Projekcije.Add(new Projekcija(SalaFk, vrijemeProjekcije, dimenzionalnost, filmFK, projekcija, 1, cjenovnik.ID)); //Zadnja 2 parametra obavezno izmjeniti
        }
        private void IzdvojiGroupBpx(Grid grid)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(grid); i++)  
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(grid, i);
                if (kontrola is GroupBox)
                {
                    GroupBox g = kontrola as GroupBox; 
                    DateTime vrijemeProjekcije = OdrediVrijemeProjekcije(g, grid);
                    for (int j = 0; j < VisualTreeHelper.GetChildrenCount(g); j++)
                    {
                        Visual control = (Visual)VisualTreeHelper.GetChild(g, j);
                        if (control is Grid)
                        {
                            Grid box = control as Grid;
                            ValidirajGroupBox(box, vrijemeProjekcije);
                            //break;
                        }
                    }
                }
            }
        }
        private void KreirajRaspored(object sender, RoutedEventArgs e)
        {
            if (!pocetak.SelectedDate.HasValue)
            {
                MessageBox.Show("Morate odabrati datum poečtka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Izbaciti metodu izdovji groupBox, i prosljeđivati 21 grid direktno umjesto 7 sadasnjih. Trebace i izmjene za određivanje 2D/3D

            IzdvojiGroupBpx(ponedjeljakGrid);
            IzdvojiGroupBpx(ponedjeljakGrid);
            IzdvojiGroupBpx(srijedaGrid);
            IzdvojiGroupBpx(cetvrtakGrid);
            IzdvojiGroupBpx(petakGrid);
            IzdvojiGroupBpx(subotaGrid);
            IzdvojiGroupBpx(nedjeljaGrid);

            raspored.ID = 1; //Ovo obavezno izmjeniti;
            raspored.DatumPocetka = pocetak.SelectedDate.Value;
            //dodati datum zavrsetka 

            if(ukupanBrojGresaka == 0)
            {
                MessageBox.Show("Uspješno ste kreirali sedmični raspored"); //ispraviti u false
                //spasiti raspored u bazu
            }
            else
            {
                MessageBox.Show("Imate ukupno " + Convert.ToString(ukupanBrojGresaka) + " grešaka"); //Staviti status bar
                ukupanBrojGresaka = 0;
            }
        }
        #endregion
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
            PopuniCjenovnik(cjenovnik);
        }
        #endregion
        #region metodeZaPunjenjeKontrolaPodacima

        private void PopuniCjenovnik(Cjenovnik cjenovnik)
        {
            cjenovnikOsnova.Text = Convert.ToString(cjenovnik.Osnova);
            cjenovnik3D.Text = Convert.ToString(cjenovnik.DodatakZa3D);
            cjenovnikFilmDuziOd120Min.Text = Convert.ToString(cjenovnik.DodatakZaFilmoveDuzeOd120Min);
            cjenovnikLjubavna.Text = Convert.ToString(cjenovnik.DodatakZaLjubavnaMjesta);
            cjenovnikNocnaProjekcija.Text = Convert.ToString(cjenovnik.DodatakZaNocneProjekcije);
            cjenovnikPopustRodjendan.Text = Convert.ToString(cjenovnik.PopustZaRodjendaskePakete);
            cjenovnikPopustVIP.Text = Convert.ToString(cjenovnik.PopustZaVipKorisnike);
            cjenovnikPremijera.Text = Convert.ToString(cjenovnik.DodatakZaPremijere);
            cjenovnikPretpremijera.Text = Convert.ToString(cjenovnik.DodatakZaPretpremijere);
            cjenovnikVIP.Text = Convert.ToString(cjenovnik.DodatakZaVip);
        }
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
