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
using System.Collections;
using System.Threading;

namespace AdministratorForme
{
    /// <summary>
    /// Interaction logic for KreiranjeSedmicnogRasporeda.xaml
    /// </summary>
    public partial class KreiranjeSedmicnogRasporeda : Window 
    {
        Cjenovnik cjen;
        List<Film> filmoviClick;
        List<Projekcija> kreiraneProjekcije;
        SedmicniRaspored raspored;
        Korisnik korisnik;
        int ukupanBrojGresaka = 0, projekcijaPoRedu = 0;

        public KreiranjeSedmicnogRasporeda(Korisnik k)
        {
            InitializeComponent();
            kreiraneProjekcije = new List<Projekcija>();
            raspored = new SedmicniRaspored();
            pocetak.DisplayDateStart = DateTime.Today;
            Baza db = new Baza();
            cjen = db.Cjenovnici.ToList()[0];
            filmoviClick = db.Filmovi.ToList();
            korisnik = k;
            PopuniCjenovnik();
            PopuniTabele();
            PopuniTipProjekcije();
            PopuniSale();
        }

        #region Metode za punjenje kotrola podacima

        private void PopuniCjenovnik() 
        {
            Baza db = new Baza();
            var cjenovnik = db.Cjenovnici.ToList()[0];

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
            a.SelectedIndex = 0;
        }        
        private void PopuniSale()
        {
            Baza db = new Baza();
            var sale = db.Sale.ToList();

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
        private void PopuniTipProjekcije()
        {
            var projekcije = new List<string> { "Premijera", "Pretpremijera", "Obična projekcija" };

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
            Baza db = new Baza();
            var filmoviii = db.Filmovi.ToList();

            ponedjeljakTabela1.ItemsSource = filmoviii;
            ponedjeljakTabela2.ItemsSource = filmoviii;
            ponedjeljakTabela3.ItemsSource = filmoviii;

            utorakTabela1.ItemsSource = filmoviii;
            utorakTabela2.ItemsSource = filmoviii;
            utorakTabela3.ItemsSource = filmoviii;

            srijedaTabela1.ItemsSource = filmoviii;
            srijedaTabela2.ItemsSource = filmoviii;
            srijedaTabela3.ItemsSource = filmoviii;

            cetvrtakTabela1.ItemsSource = filmoviii;
            cetvrtakTabela2.ItemsSource = filmoviii;
            cetvrtakTabela3.ItemsSource = filmoviii;

            petakTabela1.ItemsSource = filmoviii;
            petakTabela2.ItemsSource = filmoviii;
            petakTabela3.ItemsSource = filmoviii;

            subotaTabela1.ItemsSource = filmoviii;
            subotaTabela2.ItemsSource = filmoviii;
            subotaTabela3.ItemsSource = filmoviii;

            nedjeljaTabela1.ItemsSource = filmoviii;
            nedjeljaTabela2.ItemsSource = filmoviii;
            nedjeljaTabela3.ItemsSource = filmoviii;
        }
        #endregion
        #region Metode za kreiranje i validaciju rasporeda

        private bool UzmiVrijednostCjenovnik()
        {
            double osnova = 0;
            int dimenzionalnost = 0, duzinaVecaOd120 = 0, ljubavna = 0, premijera = 0, pretpremijera = 0, VIP = 0, popustVIP = 0, popustRodjendan = 0, nocnaProjekcija = 0;

            try
            {
                osnova = Double.Parse(cjenovnikOsnova.Text);
                duzinaVecaOd120 = Int32.Parse(cjenovnikFilmDuziOd120Min.Text);
                ljubavna = Int32.Parse(cjenovnikLjubavna.Text);
                premijera = Int32.Parse(cjenovnikPremijera.Text);
                pretpremijera = Int32.Parse(cjenovnikPretpremijera.Text);
                VIP = Int32.Parse(cjenovnikVIP.Text);
                popustVIP = Int32.Parse(cjenovnikPopustVIP.Text);
                dimenzionalnost = Int32.Parse(cjenovnik3D.Text);
                popustRodjendan = Int32.Parse(cjenovnikPopustRodjendan.Text);
                nocnaProjekcija = Int32.Parse(cjenovnikNocnaProjekcija.Text);
            }
            catch (Exception)
            {
                status.ItemsSource = ("Neispravan unos polja cjenovnika");
                Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                nit.Start();
                return false;
            }
            Baza db = new Baza();
            Cjenovnik novi = new Cjenovnik(osnova, nocnaProjekcija, ljubavna, VIP, premijera, dimenzionalnost, popustVIP, popustRodjendan, duzinaVecaOd120, pretpremijera, DateTime.Now, korisnik, db.Cjenovnici.Last().ID + 1);
            cjen = novi; 
            return true;
        }
        private bool ValidirajCjenovnik()
        {
            if (postojeciCjenovnik.IsChecked == true)
                return true;;


            if ( 
            cjenovnikOsnova.Text.Length == 0 ||
            cjenovnik3D.Text.Length == 0 ||
            cjenovnikFilmDuziOd120Min.Text.Length == 0 ||
            cjenovnikLjubavna.Text.Length == 0 ||
            cjenovnikNocnaProjekcija.Text.Length == 0 ||
            cjenovnikPopustRodjendan.Text.Length == 0 ||
            cjenovnikPopustVIP.Text.Length == 0 ||
            cjenovnikPremijera.Text.Length == 0 ||
            cjenovnikPretpremijera.Text.Length == 0 ||
            cjenovnikVIP.Text.Length == 0)
            {
                status.ItemsSource = ("Morate popuniti sva polja cjenovnika!").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                nit.Start();
                return false;
            }

            return UzmiVrijednostCjenovnik();
        }
        private DateTime OdrediDatumZavrsetka(DateTime datumPocetka)
        {
            int dan = datumPocetka.Day + 6;
            return new DateTime(datumPocetka.Year, datumPocetka.Month, dan, 0, 0, 0, 0);
        }
        private DateTime OdrediVrijemeProjekcije(Grid grid, int sati)
        {
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
                
        }
        private void ObojiKontrole(ArrayList crvene, ArrayList zelene)
        {
            foreach(var item in crvene)
            {
                if(item is TextBox)
                {
                    TextBox t = item as TextBox;
                    t.BorderThickness = new Thickness(2, 2, 2, 2);
                    t.BorderBrush = Brushes.Red;
                }
                else if(item is ComboBox)
                {
                    ComboBox c = item as ComboBox;
                    c.BorderThickness = new Thickness(2, 2, 2, 2);
                    c.BorderBrush = Brushes.Red;
                }
            }

            foreach(var item in zelene)
            {
                if (item is TextBox)
                {
                    TextBox t = item as TextBox;
                    t.BorderThickness = new Thickness(2, 2, 2, 2);
                    t.BorderBrush = Brushes.ForestGreen;
                }
                else if (item is ComboBox)
                {
                    ComboBox c = item as ComboBox;
                    c.BorderThickness = new Thickness(2, 2, 2, 2);
                    c.BorderBrush = Brushes.ForestGreen;
                }
            }
        }
        private void ValidirajGroupBox(Grid grid)
        {
            DateTime vrijemeProjekcije = DateTime.Now;
            if (projekcijaPoRedu % 3 == 0)
                vrijemeProjekcije = OdrediVrijemeProjekcije(grid, 14);
            else if (projekcijaPoRedu % 3 == 1)
                vrijemeProjekcije = OdrediVrijemeProjekcije(grid, 17);
            else
                vrijemeProjekcije = OdrediVrijemeProjekcije(grid, 21);

            projekcijaPoRedu++;
            string  projekcija = String.Empty, dimenzionalnost = String.Empty;
            int brojGresaka = 0;
            Sala SalaFk = new Sala();
            Film filmFK = new Film();

            ArrayList crvene = new ArrayList();
            ArrayList zelene = new ArrayList();

            using (Baza db = new Baza())
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(grid); i++)
                {
                    Visual kontrola = (Visual)VisualTreeHelper.GetChild(grid, i);
                    if (kontrola is TextBox)
                    {
                        TextBox g = kontrola as TextBox;
                        if (g.Text.Length > 0)
                        {
                            filmFK = db.Filmovi.Where(f => f.Naziv == g.Text) as Film;
                            zelene.Add(g);
                        }
                        else
                        {
                            crvene.Add(g);
                            brojGresaka++;
                        }
                    }
                    else if (kontrola is ComboBox)
                    {
                        ComboBox c = kontrola as ComboBox;
                        if (c.Name.Contains("Sale")) //Ako je Sala
                        {
                            if (c.SelectedIndex == -1)
                            {
                                crvene.Add(c);
                                brojGresaka++;
                            }
                            else
                            {
                                SalaFk = db.Sale.ToList()[c.SelectedIndex];
                                zelene.Add(c);
                            }
                        }
                        else if (c.Name.Contains("Projekcije")) //Ako je projekcija
                        {
                            if (c.SelectedIndex == -1)
                            {
                                crvene.Add(c);
                                brojGresaka++;
                            }
                            else
                            {
                                projekcija = c.SelectedItem.ToString();
                                zelene.Add(c);
                            }
                        }
                    }
                    else if (kontrola is CheckBox)
                    {
                        CheckBox box = kontrola as CheckBox;
                        if (box.IsChecked == false)
                            return;
                    }
                    else if (kontrola is RadioButton)
                    {
                        RadioButton r = kontrola as RadioButton;
                        if (r.Name.Contains("2D") && r.IsChecked == true)
                        {
                            dimenzionalnost = "2D";
                        }
                        else if (r.Name.Contains("3D") && r.IsChecked == true)
                        {
                            dimenzionalnost = "3D";
                        }
                    }
                }
            }
            ObojiKontrole(crvene, zelene);
            ukupanBrojGresaka += brojGresaka;
            Baza baza = new Baza();
            int id;
            if (baza.Projekcije.ToList().Count != 0)
                id = baza.Projekcije.Last().ID + 1;
            else
                id = 1;
            raspored.Projekcije.Add(new Projekcija(SalaFk, vrijemeProjekcije, dimenzionalnost, filmFK, projekcija, id, cjen)); 
        }
        private void KreirajRaspored(object sender, RoutedEventArgs e) //Nije gotovo;
        {
            if (!pocetak.SelectedDate.HasValue)
            {
                MessageBox.Show("Morate odabrati datum poečtka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(pocetak.SelectedDate.Value.Date.DayOfWeek != DayOfWeek.Monday)
            {
                MessageBox.Show("Prvi dan rasporeda mora biti ponedjeljak!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                DateTime t = pocetak.SelectedDate.Value;
                Baza db = new Baza();
                foreach(var item in db.SedmicniRasporedi)
                {
                    if(t == item.DatumPocetka)
                    {
                        MessageBox.Show("Već postoji raspored za trenutno odabrani datum\nMorate odabrati novi datum početka", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            if(ValidirajCjenovnik() == false)
            {
                return;
            }

            ProslijediSveDataGridove();
            using (Baza db = new Baza())
            {
                if (db.SedmicniRasporedi.ToList().Count != 0)
                    raspored.ID = db.SedmicniRasporedi.Last().ID + 1;
                else
                    raspored.ID = 1;
                raspored.DatumPocetka = pocetak.SelectedDate.Value;
                raspored.DatumZavrsetka = OdrediDatumZavrsetka(pocetak.SelectedDate.Value);

                if (ukupanBrojGresaka == 0)
                {
                    if (MessageBox.Show("Izabrali ste " + Convert.ToString(raspored.Projekcije.Count) + "/21 mogućih projekcija\nDa li želite potvrditi odabrane projekcije?",
                        "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;

                    raspored.Projekcije = kreiraneProjekcije;
                    db.SedmicniRasporedi.Add(raspored);
                    db.SaveChanges();

                    MessageBox.Show("Uspješno ste kreirali sedmični raspored", "Uspješno kreiranje", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    return;
                }
                else
                {
                    string poruka = "Imate ukupno " + Convert.ToString(ukupanBrojGresaka) + " grešaka. Morate popuniti sva polja prije kreiranja rasporeda!";
                    status.ItemsSource = poruka.ToList();
                    ukupanBrojGresaka = 0;
                    projekcijaPoRedu = 0;
                    raspored.Projekcije.Clear(); //???????

                    Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                    nit.Start();
                }
            }
        }
        private void IzmjeniBojuStatusBar()
        {
            Brush boja = Brushes.Red;
            Dispatcher.BeginInvoke((Action)(() => boja = status.Background));

            for (int i = 1; i <= 5; i++)
            {
                Dispatcher.BeginInvoke((Action)(() => status.Background = Brushes.Red));
                Thread.Sleep(800);

                Dispatcher.BeginInvoke((Action)(() => status.Background = boja));
                Thread.Sleep(800);
            }
        }
        private void ProslijediSveDataGridove()
        {
            ValidirajGroupBox(ponedjeljakGrid1);
            ValidirajGroupBox(ponedjeljakGrid2);
            ValidirajGroupBox(ponedjeljakGrid3);

            ValidirajGroupBox(utorakGrid1);
            ValidirajGroupBox(utorakGrid2);
            ValidirajGroupBox(utorakGrid3);

            ValidirajGroupBox(srijedaGrid1);
            ValidirajGroupBox(srijedaGrid2);
            ValidirajGroupBox(srijedaGrid3);

            ValidirajGroupBox(cetvrtakGrid1);
            ValidirajGroupBox(cetvrtakGrid2);
            ValidirajGroupBox(cetvrtakGrid3);

            ValidirajGroupBox(petakGrid1);
            ValidirajGroupBox(petakGrid2);
            ValidirajGroupBox(petakGrid3);

            ValidirajGroupBox(subotaGrid1);
            ValidirajGroupBox(subotaGrid2);
            ValidirajGroupBox(subotaGrid3);

            ValidirajGroupBox(nedjeljaGrid1);
            ValidirajGroupBox(nedjeljaGrid2);
            ValidirajGroupBox(nedjeljaGrid3);
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
            PopuniCjenovnik();
        }
        #endregion
        #region Metode Za Odabir Filma ButtonClick 

        private void NedjeljaOdabirFilmaClick3(object sender, RoutedEventArgs e) //Ovo izbrisati!!!!!!!!!!!!!!!!!
        {
            if (nedjeljaTabela3.SelectedIndex == -1 || nedjeljaTabela3.SelectedIndex >= filmoviClick.Count)
                return;

            nedjeljaFilm3.Text = filmoviClick[nedjeljaTabela3.SelectedIndex].Naziv;
        }
        private void NedjeljaOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (nedjeljaTabela2.SelectedIndex == -1 || nedjeljaTabela2.SelectedIndex >= filmoviClick.Count)
                return;

            nedjeljaFilm2.Text = filmoviClick[nedjeljaTabela2.SelectedIndex].Naziv;
        }
        private void NedjeljaOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (nedjeljaTabela1.SelectedIndex == -1 || nedjeljaTabela1.SelectedIndex >= filmoviClick.Count)
                return;

            nedjeljaFilm1.Text = filmoviClick[nedjeljaTabela1.SelectedIndex].Naziv;
        }
        private void SubotaOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (subotaTabela3.SelectedIndex == -1 || subotaTabela3.SelectedIndex >= filmoviClick.Count)
                return;

            subotaFilm3.Text = filmoviClick[subotaTabela3.SelectedIndex].Naziv;
        }
        private void SubotaOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (subotaTabela2.SelectedIndex == -1 || subotaTabela2.SelectedIndex >= filmoviClick.Count)
                return;

            subotaFilm2.Text = filmoviClick[subotaTabela2.SelectedIndex].Naziv;
        }
        private void SubotaOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (subotaTabela1.SelectedIndex == -1 || subotaTabela1.SelectedIndex >= filmoviClick.Count)
                return;

            subotaFilm1.Text = filmoviClick[subotaTabela1.SelectedIndex].Naziv;
        }
        private void PetakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (petakTabela3.SelectedIndex == -1 || petakTabela3.SelectedIndex >= filmoviClick.Count)
                return;

            petakFilm3.Text = filmoviClick[petakTabela3.SelectedIndex].Naziv;
        }
        private void PetakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (petakTabela2.SelectedIndex == -1 || petakTabela2.SelectedIndex >= filmoviClick.Count)
                return;

            petakFilm2.Text = filmoviClick[petakTabela2.SelectedIndex].Naziv;
        }
        private void PetakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (petakTabela1.SelectedIndex == -1 || petakTabela1.SelectedIndex >= filmoviClick.Count)
                return;

            petakFilm1.Text = filmoviClick[petakTabela1.SelectedIndex].Naziv;
        }
        private void CetvrtakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (cetvrtakTabela1.SelectedIndex == -1 || cetvrtakTabela1.SelectedIndex >= filmoviClick.Count)
                return;

            cetvrtakFilm1.Text = filmoviClick[cetvrtakTabela1.SelectedIndex].Naziv;
        }
        private void CetvrtakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (cetvrtakTabela3.SelectedIndex == -1 || cetvrtakTabela3.SelectedIndex >= filmoviClick.Count)
                return;

            cetvrtakFilm3.Text = filmoviClick[cetvrtakTabela3.SelectedIndex].Naziv;
        }
        private void CetvrtakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (cetvrtakTabela2.SelectedIndex == -1 || cetvrtakTabela2.SelectedIndex >= filmoviClick.Count)
                return;

            cetvrtakFilm2.Text = filmoviClick[cetvrtakTabela2.SelectedIndex].Naziv;
        }
        private void SrijedaOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (srijedaTabela3.SelectedIndex == -1 || srijedaTabela3.SelectedIndex >= filmoviClick.Count)
                return;

            srijedaFilm3.Text = filmoviClick[srijedaTabela3.SelectedIndex].Naziv;
        }
        private void SrijedaOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (srijedaTabela2.SelectedIndex == -1 || srijedaTabela2.SelectedIndex >= filmoviClick.Count)
                return;

            srijedaFilm2.Text = filmoviClick[srijedaTabela2.SelectedIndex].Naziv;
        }
        private void SrijedaOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (srijedaTabela1.SelectedIndex == -1 || srijedaTabela1.SelectedIndex >= filmoviClick.Count)
                return;

            srijedaFilm1.Text = filmoviClick[srijedaTabela1.SelectedIndex].Naziv;
        }
        private void UtorakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (utorakTabela3.SelectedIndex == -1 || utorakTabela3.SelectedIndex >= filmoviClick.Count)
                return;

            utorakFilm3.Text = filmoviClick[utorakTabela3.SelectedIndex].Naziv;
        }
        private void UtorakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (utorakTabela2.SelectedIndex == -1 || utorakTabela2.SelectedIndex >= filmoviClick.Count)
                return;

            utorakFilm2.Text = filmoviClick[utorakTabela2.SelectedIndex].Naziv;
        }
        private void UtorakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (utorakTabela1.SelectedIndex == -1 || utorakTabela1.SelectedIndex >= filmoviClick.Count)
                return;

            utorakFilm1.Text = filmoviClick[utorakTabela1.SelectedIndex].Naziv;
        }
        private void PonedjeljakOdabirFilmaClick1(object sender, RoutedEventArgs e)
        {
            if (ponedjeljakTabela1.SelectedIndex == -1 || ponedjeljakTabela1.SelectedIndex >= filmoviClick.Count)
                return;

            ponedjeljakFilm1.Text = filmoviClick[ponedjeljakTabela1.SelectedIndex].Naziv;
        }
        private void PonedjeljakOdabirFilmaClick2(object sender, RoutedEventArgs e)
        {
            if (ponedjeljakTabela2.SelectedIndex == -1 || ponedjeljakTabela2.SelectedIndex >= filmoviClick.Count)
                return;

            ponedjeljakFilm2.Text = filmoviClick[ponedjeljakTabela2.SelectedIndex].Naziv;
        }
        private void PonedjeljakOdabirFilmaClick3(object sender, RoutedEventArgs e)
        {
            if (ponedjeljakTabela3.SelectedIndex == -1 || ponedjeljakTabela3.SelectedIndex >= filmoviClick.Count)
                return;

            ponedjeljakFilm3.Text = filmoviClick[ponedjeljakTabela3.SelectedIndex].Naziv;
        }
        #endregion
        #region Metode za prikaz detalja filma, poništavanje pretrage i pretragu ButtonClick

        private List<Film> Pretraga(int id, string naziv, int godinaIzdavanja, string zanr)
        {
            Baza db = new Baza();
            var filmovi = db.Filmovi.ToList();
            List<Film> lista = (from f in filmovi

                                where (id == 0 || f.ID == id) &&
                                (f.Naziv.ToLower().Contains(naziv.ToLower()) || naziv == " " || naziv == String.Empty) &&
                                (godinaIzdavanja == 0 || godinaIzdavanja == f.GodinaIzdavanja) &&
                                (f.Zanr.ToLower().Contains(zanr.ToLower()) || zanr == " " || zanr == String.Empty)

                                select f).ToList();

            return lista;
        }
        private void PretraziClick(object sender, RoutedEventArgs e) 
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
                            MessageBox.Show("Neispravan unos ID-a filma. ID mora biti unesen kao cijeli broj!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
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
                            MessageBox.Show("Neispravan unos godine izdavanja filma. Godina mora biti unesena kao cijeli broj!", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
            }

            tabela.ItemsSource = Pretraga(id, naziv, godinaIzdavanja, zanr);
        }
        private void PonistiPretragu(object sender, RoutedEventArgs e)
        {
            FrameworkElement roditelj = (FrameworkElement)((Button)sender).Parent;
            Baza db = new Baza();
            var filmovi = db.Filmovi.ToList();
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
        private void PrikazDetaljaFilma(object sender, RoutedEventArgs e)
        {
            FrameworkElement roditelj = (FrameworkElement)((Button)sender).Parent;
            Baza db = new Baza();
            var filmovi = db.Filmovi.ToList();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(roditelj); i++)
            {
                Visual kontrola = (Visual)VisualTreeHelper.GetChild(roditelj, i);
                if (kontrola is DataGrid)
                {
                    DataGrid tabela = kontrola as DataGrid;
                    if (tabela.SelectedIndex == -1 || tabela.SelectedIndex >= tabela.Items.Count)
                        return;

                    var prozor = new PrikazEditovanjeFilma(tabela.SelectedItem as Film, korisnik, true);
                    prozor.ShowDialog();
                    return;
                }
            }
        }
        #endregion

    }
}
