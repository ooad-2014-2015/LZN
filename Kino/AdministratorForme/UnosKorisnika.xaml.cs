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
    /// Interaction logic for UnosKorisnika.xaml
    /// </summary>
    public partial class UnosKorisnika : Window
    {
        bool unos;
        private Korisnik k;

        public UnosKorisnika(List<Korisnik> f, bool daLiJeUnos, Korisnik korisnik)
        {
            InitializeComponent();
            unos = daLiJeUnos;
            k = korisnik;
            korisnikSpol.ItemsSource = new List<string> { "Žensko", "Muško" };
            korisnikPravaPristupa.ItemsSource = new List<string> { "Blagajnik", "Finansijski menadžer", "Administrator sistema" };

            using (Baza db = new Baza())
            {
                var korisnici = db.Korisnici.ToList();
                if (korisnici.Count == 0)
                    korisnikId.Text = Convert.ToString(1);
                else if (unos)
                    korisnikId.Text = Convert.ToString(korisnici.Last().ID + 1);
                else
                {
                    korisnikId.Text = Convert.ToString(k.ID);
                    korisnikIme.Text = k.Ime;
                    korisnikPrezime.Text = k.Prezime;
                    korisnikUsername.Text = k.Username;
                    korisnikSpol.SelectedItem = k.Spol;
                    korisnikPravaPristupa.SelectedItem = k.TipKorisnika;
                }
            }
        }
        private void PotvrdiUnosButtonClick(object sender, RoutedEventArgs e)
        {
            if(korisnikIme.Text.Length == 0 || korisnikPravaPristupa.SelectedIndex == -1 || korisnikPrezime.Text.Length == 0 || 
                korisnikSpol.SelectedIndex == -1 ||korisnikUsername.Text.Length == -1)
            {
                status.ItemsSource = ("Morate popuniti sva polja!").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                nit.Start();
                return;
            }

            if (MessageBox.Show("Da li želite potvrditi unos?", "Unos korisnika", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;

            if(unos)
            {
                if (korisnikPw.Password != korisnikPwPotvrda.Password)
                {
                    status.ItemsSource = ("Passwordi se ne podudaraju").ToList();
                    Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                    nit.Start();
                    return;
                }
                using (Baza db = new Baza())
                {
                    db.Korisnici.Add(new Korisnik(korisnikIme.Text, korisnikPrezime.Text, Int32.Parse(korisnikId.Text), korisnikUsername.Text, korisnikPravaPristupa.SelectedItem.ToString(), korisnikPw.Password.GetHashCode().ToString(), korisnikSpol.SelectedItem.ToString()));
                    db.SaveChanges();
                }
                MessageBox.Show("Novi korisnik uspješno registrovan", "Uspješna registracija", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                return;
            }

            if ((korisnikPw.Password != korisnikPwPotvrda.Password))
            {
                status.ItemsSource = ("Passwordi se ne podudaraju").ToList();
                Thread nit = new Thread(m => IzmjeniBojuStatusBar());
                nit.Start();
                return;
            }
            using (Baza db = new Baza())
            {
                var korisnici = db.Korisnici.ToList();
                for (int i = 0; i < korisnici.Count; i++)
                {
                    if (korisnici[i].ID == Int32.Parse(korisnikId.Text))
                    {
                        Korisnik temp = db.Korisnici.Where(m => m.ID == k.ID).FirstOrDefault();
                        temp.Ime = korisnikIme.Text;
                        temp.Prezime = korisnikPrezime.Text;
                        temp.Username = korisnikUsername.Text;
                        temp.TipKorisnika = korisnikPravaPristupa.SelectedItem.ToString();
                        temp.Password = korisnikPw.Password.GetHashCode().ToString();
                        temp.Spol = korisnikSpol.SelectedItem.ToString();
                        db.SaveChanges();
                        break;
                    }
                }
            }
                MessageBox.Show("Izmjene su spašene uspješno", "Izmjene", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        private void IzmjeniBojuStatusBar()
        {
            Brush boja = Brushes.Red;
            Dispatcher.BeginInvoke((Action)(() => boja = status.Background));

            for (int i = 1; i <= 3; i++)
            {
                Dispatcher.BeginInvoke((Action)(() => status.Background = Brushes.Red));
                Thread.Sleep(800);

                Dispatcher.BeginInvoke((Action)(() => status.Background = boja));
                Thread.Sleep(800);
            }
        }
    }
}
